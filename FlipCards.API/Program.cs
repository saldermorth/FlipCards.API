using Azure.Messaging.ServiceBus;
using Azure.Storage.Blobs;
using FlipCards.API.Data;
using FlipCards.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Configuration

var sqlConn = builder.Configuration.GetConnectionString("Sql");
var storageConn = builder.Configuration.GetConnectionString("Storage");
var sbConn = builder.Configuration.GetConnectionString("ServiceBus");

// Services
builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlServer(sqlConn));

builder.Services.AddSingleton(_ =>
    new BlobServiceClient(storageConn));

builder.Services.AddSingleton(_ =>
    new ServiceBusClient(sbConn));

builder.Services.AddCors(o =>
    o.AddDefaultPolicy(p =>
        p.AllowAnyOrigin()
         .AllowAnyHeader()
         .AllowAnyMethod()));

builder.Services.AddOpenApi();

// App
var app = builder.Build();

// Database init
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    Seed.SeedFlipCards(db);
}

// Middleware
app.UseCors();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Endpoints
app.MapGet("/api/flipcards",
    async (AppDbContext db) =>
        await db.FlipCards.ToListAsync());

app.MapPost("/api/text", async (
    TextRequest req,
    BlobServiceClient blobClient) =>
{
    var container = blobClient.GetBlobContainerClient("results");
    await container.CreateIfNotExistsAsync();

    var blob = container.GetBlobClient($"{Guid.NewGuid()}.txt");
    using var ms = new MemoryStream(Encoding.UTF8.GetBytes(req.Text));
    await blob.UploadAsync(ms, overwrite: true);

    return Results.Ok();
});

app.MapPost("/api/queue/send", async (
    MessageRequest req,
    ServiceBusClient sbClient) =>
{
    var sender = sbClient.CreateSender("processing-queue");
    await sender.SendMessageAsync(
        new ServiceBusMessage(req.Message));

    return Results.Ok();
});

app.MapGet("/api/queue/receive", async (
    ServiceBusClient sbClient) =>
{
    var receiver = sbClient.CreateReceiver("processing-queue");

    var msg = await receiver.ReceiveMessageAsync(
        TimeSpan.FromSeconds(5));

    if (msg == null)
        return Results.NoContent();

    var body = msg.Body.ToString();
    await receiver.CompleteMessageAsync(msg);

    return Results.Ok(body);
});

app.Run();
