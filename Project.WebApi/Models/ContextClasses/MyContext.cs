using Microsoft.EntityFrameworkCore;
using NetCoreBank.Models.SeedHandling;
using Project.WebApi.Models.Entities;

namespace Project.WebApi.Models.ContextClasses
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            UserCardInfoSeed.SeedUserCard(modelBuilder);
        }

        public DbSet<UserCardInfo> CardInfoes { get; set; }
    }
}
