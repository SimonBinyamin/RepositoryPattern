using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern_BOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern_Core
{
    public class RepositoryPatternDbContext : IdentityDbContext<RepositoryPattern_BOL.ApplicationUser>
    {
        public RepositoryPatternDbContext(DbContextOptions<RepositoryPatternDbContext> options) : base(options)
        {
             EnsureDatabaseCreatedAsync();

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<UserFile>()
                    .HasKey(uf => new { uf.FileID, uf.ApplicationUserID });

            builder.Entity<UserFile>()
                    .HasOne(uf => uf.ApplicationUser)
                    .WithMany(f => f.UserFiles)
                    .HasForeignKey(uf => uf.ApplicationUserID);


            base.OnModelCreating(builder);

        }

        public void EnsureDatabaseCreatedAsync()
        {
            if (this.Database.EnsureCreated())
            {
                this.SaveChanges();
            }
        }


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }

    }
}
