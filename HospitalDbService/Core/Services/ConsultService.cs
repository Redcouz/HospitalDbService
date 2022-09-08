using HospitalDbService.Core.Models;
using HospitalDbService.Core.Interfaces.IService;
using HospitalDbService.Core.Interfaces.IUnitOfWork;

namespace HospitalDbService.Core.Services
{
  public class ConsultService : IConsultService
  {

    private readonly IUnitOfWork _unitOfWork;

    public ConsultService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<bool> DeleteConsult(int Id)
    {

      try
      {
        await _unitOfWork.ConsultRepository.Delete(Id);
        await _unitOfWork.SaveChangesAsync();

      }
      catch (Exception)
      {
        return false;
      }

      return true;
    }

    public bool ConsultExists(int Id)
    {
      return _unitOfWork.ConsultRepository.EntityExists(Id);
    }

    public async Task<IEnumerable<ConsultModel>> GetConsults()
    {
      return await _unitOfWork.ConsultRepository.GetAll();
    }

    public async Task<ConsultModel> GetConsultById(int Id)
    {
      return await _unitOfWork.ConsultRepository.GetById(Id);
    }

    public async Task<ConsultModel> Post(ConsultModel consultModel)
    {
      try
      {
        await _unitOfWork.ConsultRepository.Insert(consultModel);
        await _unitOfWork.SaveChangesAsync();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

      return consultModel;
    }

    public async Task<ConsultModel> Put(ConsultModel consultModel)
    {
      try
      {
        await _unitOfWork.ConsultRepository.Update(consultModel);
        await _unitOfWork.SaveChangesAsync();

        return consultModel;
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }
    public bool EntityExists(int id)
    {
      return _unitOfWork.ConsultRepository.EntityExists(id);
    }
  }
}
