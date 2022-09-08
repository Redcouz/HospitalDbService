using HospitalDbService.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalDbService.Infraestructure.Data
{
  public class HospitalDbContext : DbContext
  {
    public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)// Crée la migration
    {
      modelBuilder.Entity<ConsultModel>().Property(c => c.Price).HasColumnType("decimal(18,4)");
      modelBuilder.Entity<ConsultModel>().Property(c => c.MaterialsCost).HasColumnType("decimal(18,4)");
    }
    public DbSet<ConsultModel> Consults { get; set; }
    public DbSet<DoctorModel> Doctors { get; set; }
    public DbSet<PatientModel> Patients { get; set; }
  }
}
