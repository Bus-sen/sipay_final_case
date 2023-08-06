using System.Linq.Expressions;

namespace Data.Repositories;

public interface IGenericRepository<Entity> where Entity : class
{
    void Save();
    List<Entity> GetAll();
    Entity GetById(int id);
    IQueryable<Entity> GetAllAsQueryable();
    void Create(Entity entity);
    void Update(Entity entity);
    void Delete(Entity entity);
    void DeleteById(int id);
    IEnumerable<Entity> Where(Expression<Func<Entity, bool>> expression);
}
