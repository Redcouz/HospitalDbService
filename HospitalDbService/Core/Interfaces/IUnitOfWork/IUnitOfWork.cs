using HospitalDbService.Core.Interfaces.IRepository;
using HospitalDbService.Core.Models;

namespace HospitalDbService.Core.Interfaces.IUnitOfWork
{
  public interface IUnitOfWork : IDisposable
  {
    IBaseRepository<PatientModel> PatientRepository { get; }
    IBaseRepository<ConsultModel> ConsultRepository { get; }
    IBaseRepository<DoctorModel> DoctorRepository { get; }

    void SaveChanges();
    Task SaveChangesAsync();
  }
}
