
using Microsoft.EntityFrameworkCore;
using SmartMedicinesTestAPi.Models;

namespace SmartMedicinesTestAPi.Context
{
    public class MedicineDataContext : DbContext
    {

        public MedicineDataContext(DbContextOptions<MedicineDataContext> options)
            : base(options) => Database.EnsureCreated();

        public DbSet<Medicine> Medicine { get; set; } = null!;

    }
}