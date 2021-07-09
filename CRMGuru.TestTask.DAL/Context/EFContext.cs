using CRMGuru.TestTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMGuru.TestTask.DAL.Context
{
    public class EFContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Country> Countries { get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base (options) { }
    }
}
