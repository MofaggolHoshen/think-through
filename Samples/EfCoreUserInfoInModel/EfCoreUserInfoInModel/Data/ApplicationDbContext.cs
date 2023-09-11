using EfCoreUserInfoInModel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EfCoreUserInfoInModel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly HttpContext context;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor context)
            : base(options)
        {
            this.context=context.HttpContext;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Institution>()
            //       .Property(e => e.LongInUserId)
            //       .HasValueGenerator();

        }
        public DbSet<Institution> Institutions { get; set; }
    }
}