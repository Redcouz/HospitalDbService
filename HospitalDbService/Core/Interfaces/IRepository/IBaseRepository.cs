using HospitalDbService.Core.Models;

namespace HospitalDbService.Core.Interfaces.IRepository
{
  public interface IBaseRepository<T> where T : EntityBase
  {

    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task Insert(T entity);
    Task Update(T entity);
    Task Delete(int id);
    bool EntityExists(int id);
  }
}
