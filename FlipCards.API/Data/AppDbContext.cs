using FlipCards.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FlipCards.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<FlipCard> FlipCards => Set<FlipCard>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
