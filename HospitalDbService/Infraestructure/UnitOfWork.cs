using HospitalDBervice;
using HospitalDbService.Core.Interfaces.IRepository;
using HospitalDbService.Core.Interfaces.IUnitOfWork;
using HospitalDbService.Infraestructure.Data;
using HospitalDbService.Infraestructure.Repositories;
using HospitalDBService;
using Microsoft.EntityFrameworkCore;

namespace HospitalDbService.Infraestructure
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly HospitalDbContext _context;

    public UnitOfWork(HospitalDbContext context)
    {
      _context = context;
    }
    private readonly IBaseRepository<PatientModel> _patientRepository;
    public IBaseRepository<PatientModel> PatientRepository => _patientRepository ?? new BaseRepository<PatientModel>(_context);

    private readonly IBaseRepository<ConsultModel> _consultRepository;
    public IBaseRepository<ConsultModel> ConsultRepository => _consultRepository ?? new BaseRepository<ConsultModel>(_context);

    private readonly IBaseRepository<DoctorModel> _doctorRepository;
    public IBaseRepository<DoctorModel> DoctorRepository => _doctorRepository ?? new BaseRepository<DoctorModel>(_context);


    public void Dispose()
    {
      if (_context != null)
      {
        _context.Dispose();
      }
    }
    public void SaveChanges()
    {
      _context.SaveChanges();
    }
    public async Task SaveChangesAsync()
    {
      await _context.SaveChangesAsync();
    }
  }
}
