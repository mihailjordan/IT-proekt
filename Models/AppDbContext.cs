using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INS_FInal.Models
{
    public class AppDbContext : IdentityDbContext<AplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }

        public DbSet<File> Files { get; set; }
        public DbSet<FilePermition> FilePermitions { get; set; }
        public DbSet<Department> Departments { get; set; }

        public Models.File AddFile(Models.File file)
        {
            Files.Add(file);
            this.SaveChanges();
            return file;
        }

        public void AddFilePermition(FilePermition fileP)
        {
            FilePermitions.Add(fileP);
            this.SaveChanges();
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
