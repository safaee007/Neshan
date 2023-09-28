using Microsoft.EntityFrameworkCore;
using Neshan.Domain.Entities;

namespace Neshan.Infrastructure.DatabaseContext
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options): base(options) 
        { 
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder
        //        .UseSqlServer("");
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<ShortUrl> ShortURLs { get; set; }
        public DbSet<RequestUrl> RequestUrls { get; set; }
    }
}
