using HospitalDbService.Core.Models;

namespace HospitalDbService.Core.Interfaces.IService
{
  public interface IPatientService
  {
    public Task<bool> DeletePatient(int Id);
    public Task<IEnumerable<PatientModel>> GetPatients();
    public Task<PatientModel> GetPatientById(int Id);
    public Task<PatientModel> Post(PatientModel patientModel);
    public Task<PatientModel> Put(PatientModel patientUpdate);
    public bool EntityExists(int id);
  }
}
