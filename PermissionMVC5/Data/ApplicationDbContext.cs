using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PermissionMVC5.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext():base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBTest;Integrated Security=True;Connect Timeout=30;")
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new MenuMap());
        }
    }
}