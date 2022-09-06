using HospitalDBervice;
using HospitalDBService;

namespace HospitalDbService.Core.Interfaces.IService
{
  public interface IConsultService
  {
    public Task<bool> DeleteConsult(int Id);
    public Task<IEnumerable<ConsultModel>> GetConsults();
    public Task<ConsultModel> GetConsultById(int Id);
    public Task<ConsultModel> Post(ConsultModel consultModel);
    public Task<ConsultModel> Put(ConsultModel consultUpdate);
    public bool EntityExists(int id);
  }
}
