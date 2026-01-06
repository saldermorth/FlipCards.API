
using FlipCards.API.Data;
using Microsoft.EntityFrameworkCore;

namespace FlipCards.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<AppDbContext>(o =>
              o.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

            builder.Services.AddCors(o =>
              o.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            var app = builder.Build();

        
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();

                // Apply migrations if needed
                context.Database.Migrate();

                // Seed data
                Seed.SeedFlipCards(context);
            }

            app.UseCors();

            app.MapGet("/api/flipcards",
                async (AppDbContext db) => await db.FlipCards.ToListAsync());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
