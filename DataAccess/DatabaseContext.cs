using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Personel> personels { get; set; }
        public DbSet<Departman> departmans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DRANA\\SQLEXPRESS;database=WEBAPIEXAMPLEDB;integrated security=true");
        }
    }
}
