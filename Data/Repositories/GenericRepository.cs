using Base.BaseModel;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : BaseModel
{
    protected readonly SipayDbContext sipayDbContext;
    public GenericRepository(SipayDbContext sipayDbContext)
    {
        this.sipayDbContext = sipayDbContext;
    }

    public void Create(Entity entity)
    {
        sipayDbContext.Set<Entity>().Add(entity);
    }

    public void Delete(Entity entity)
    {
        sipayDbContext.Set<Entity>().Remove(entity);
    }

    public void DeleteById(int id)
    {
        var entity = sipayDbContext.Set<Entity>().Find(id);
        Delete(entity);
    }

    public void Update(Entity entity)
    {
        sipayDbContext.Set<Entity>().Update(entity);
    }

    public List<Entity> GetAll()
    {
        return sipayDbContext.Set<Entity>().AsNoTracking().ToList();
    }

    public IQueryable<Entity> GetAllAsQueryable()
    {
        return sipayDbContext.Set<Entity>().AsQueryable();
    }

    public Entity GetById(int id)
    {
        var entity = sipayDbContext.Set<Entity>().Find(id);
        return entity;
    }

    public void Save()
    {
        sipayDbContext.SaveChanges();
    }

    public IEnumerable<Entity> Where(Expression<Func<Entity, bool>> expression)
    {
        return sipayDbContext.Set<Entity>().Where(expression).AsQueryable();
    }
}
