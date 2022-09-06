using HospitalDBervice;
using HospitalDbService.Core.Interfaces.IService;
using HospitalDbService.Core.Interfaces.IUnitOfWork;
using HospitalDBService;

namespace HospitalDbService.Core.Services
{
  public class DoctorService : IDoctorService
  {

    private readonly IUnitOfWork _unitOfWork;

    public DoctorService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<bool> DeleteDoctor(int Id)
    {

      try
      {
        await _unitOfWork.DoctorRepository.Delete(Id);
        await _unitOfWork.SaveChangesAsync();

      }
      catch (Exception)
      {
        return false;
      }

      return true;
    }

    public bool DoctorExists(int Id)
    {
      return _unitOfWork.DoctorRepository.EntityExists(Id);
    }

    public async Task<IEnumerable<DoctorModel>> GetDoctors()
    {
      return await _unitOfWork.DoctorRepository.GetAll();
    }

    public async Task<DoctorModel> GetDoctorById(int Id)
    {
      return await _unitOfWork.DoctorRepository.GetById(Id);
    }
    public async Task<DoctorModel> Post(DoctorModel doctorModel)
    {
      try
      {
        await _unitOfWork.DoctorRepository.Insert(doctorModel);
        await _unitOfWork.SaveChangesAsync();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

      return doctorModel;
    }
    public async Task<DoctorModel> Put(DoctorModel doctorModel)
    {
      try
      {
        await _unitOfWork.DoctorRepository.Update(doctorModel);
        await _unitOfWork.SaveChangesAsync();

        return doctorModel;
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }
    public bool EntityExists(int id)
    {
      return _unitOfWork.DoctorRepository.EntityExists(id);
    }
  }
}
