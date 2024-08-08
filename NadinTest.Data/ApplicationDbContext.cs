using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using NadinTest.Core.Models.Base;
using NadinTest.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NadinTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products {  get; set; }
        public DbSet<User> Users {  get; set; }
        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration( new UserConfiguration());
        }

    }
    public class BlogginContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionBuilder.UseSqlServer(@"");


                return new ApplicationDbContext(optionBuilder.Options);
        }

    }
}
