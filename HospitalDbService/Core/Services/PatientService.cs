using HospitalDBervice;
using HospitalDbService.Core.Interfaces.IService;
using HospitalDbService.Core.Interfaces.IUnitOfWork;
using HospitalDBService;

namespace HospitalDbService.Core.Services
{
  public class PatientService : IPatientService
  {

    private readonly IUnitOfWork _unitOfWork;

    public PatientService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<bool> DeletePatient(int Id)
    {

      try
      {
        await _unitOfWork.PatientRepository.Delete(Id);
        await _unitOfWork.SaveChangesAsync();

      }
      catch (Exception)
      {
        return false;
      }

      return true;
    }

    public bool PatientExists(int Id)
    {
      return _unitOfWork.PatientRepository.EntityExists(Id);
    }

    public async Task<IEnumerable<PatientModel>> GetPatients()
    {
      return await _unitOfWork.PatientRepository.GetAll();
    }

    public async Task<PatientModel> GetPatientById(int Id)
    {
      return await _unitOfWork.PatientRepository.GetById(Id);
    }

    public async Task<PatientModel> Post(PatientModel patientModel)
    {
      try
      {
        await _unitOfWork.PatientRepository.Insert(patientModel);
        await _unitOfWork.SaveChangesAsync();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

      return patientModel;
    }

    public async Task<PatientModel> Put(PatientModel patientModel)
    {
      try
      {
        await _unitOfWork.PatientRepository.Update(patientModel);
        await _unitOfWork.SaveChangesAsync();

        return patientModel;
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }
    public bool EntityExists(int id)
    {
      return _unitOfWork.PatientRepository.EntityExists(id);
    }
  }
}
