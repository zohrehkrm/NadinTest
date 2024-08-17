using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using NadinTest.Core.Models.Base;
using NadinTest.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static NadinTest.Core.Models.Users.Role;


namespace NadinTest.Data
{
    public class ApplicationDbContext :  IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Product> Products {  get; set; }
        public DbSet<User> Users {  get; set; }
        public DbSet<Role> Roles {  get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

          

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration( new UserConfiguration());
            modelBuilder.ApplyConfiguration( new RoleConfiguration());

            base.OnModelCreating(modelBuilder);

        }

    }
    public class BlogginContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionBuilder.UseSqlServer("Data Source=.;Initial Catalog=NadinDb;Integrated Security=true ;Trusted_Connection=True;TrustServerCertificate=True;");


            return new ApplicationDbContext(optionBuilder.Options);
        }

    }
}
