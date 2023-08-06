using Base.BaseModel;
using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Uow;

public class UnitOfWork : IUnitOfWork
{
    private readonly SipayDbContext sipayDbContext;
    public UnitOfWork (SipayDbContext sipayDbContext)
    {
        this.sipayDbContext = sipayDbContext;

        HouseholderRepository = new GenericRepository<Householder>(sipayDbContext);
        HouseDetailRepository = new GenericRepository<HouseDetail>(sipayDbContext);
        BillRepository = new GenericRepository<Bill>(sipayDbContext);
        UserRepository = new GenericRepository<User>(sipayDbContext);
        UserLogRepository = new GenericRepository<UserLog>(sipayDbContext);
    }

    public IGenericRepository<Householder> HouseholderRepository { get; private set; }

    public IGenericRepository<HouseDetail> HouseDetailRepository { get; private set; }

    public IGenericRepository<Bill> BillRepository { get; private set; }

    public IGenericRepository<User> UserRepository { get; private set; }
    public IGenericRepository<UserLog> UserLogRepository { get; private set; }

    public void Complete()
    {
        sipayDbContext.SaveChanges();
    }

    public IGenericRepository<Entity> DynamicRepository<Entity>() where Entity : BaseModel
    {
        return new GenericRepository<Entity>(sipayDbContext);
    }
}
