using HospitalDbService.Core.Models;

namespace HospitalDbService.Core.Interfaces.IService
{
  public interface IDoctorService
  {
    public Task<bool> DeleteDoctor(int Id);
    public Task<IEnumerable<DoctorModel>> GetDoctors();
    public Task<DoctorModel> GetDoctorById(int Id);
    public Task<DoctorModel> Post(DoctorModel doctorModel);
    public Task<DoctorModel> Put(DoctorModel doctorUpdate);
    public bool EntityExists(int id);
  }
}
