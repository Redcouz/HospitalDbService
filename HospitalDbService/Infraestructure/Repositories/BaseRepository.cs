using HospitalDbService.Core.Interfaces.IRepository;
using HospitalDbService.Infraestructure.Data;
using HospitalDbService.Models;
using HospitalDBService;
using Microsoft.EntityFrameworkCore;

namespace HospitalDbService.Infraestructure.Repositories
{
  public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
  {
    private readonly HospitalDbContext _context;
    private DbSet<T> _entities;

    public BaseRepository(HospitalDbContext context)
    {
      _context = context;
      _entities = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
      var list = await _entities.ToListAsync();
      return list;
    }

    public async Task<T> GetById(int id)
    {
      return await _entities.FindAsync(id);
    }

    public async Task Insert(T entity)
    {
      entity.CreatedAt = DateTime.Now;
      await _entities.AddAsync(entity);
    }

    public async Task Update(T entity)
    {
      _entities.Update(entity);
    }

    public async Task Delete(int id)
    {
      var entity = await _entities.FindAsync(id);
      _context.Remove(entity);
    }

    public bool EntityExists(int id)
    {
      return _entities.Any(x => x.Id == id);
    }
  }
}
