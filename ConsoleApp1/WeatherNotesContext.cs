using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    public class WeatherNotesContext : DbContext
    {
        public DbSet<WeatherNote> WeatherNotes { get; set; }

        public WeatherNotesContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=weatherdb;Trusted_Connection=True;");
            //base.OnConfiguring(optionsBuilder);
        }
    }
}
