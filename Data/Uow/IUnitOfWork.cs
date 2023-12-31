﻿using Base.BaseModel;
using Data.Repositories;

namespace Data.Uow;

public interface IUnitOfWork
{
    void Complete();

    IGenericRepository<Entity> DynamicRepository<Entity>() where Entity : BaseModel;
    IGenericRepository<Householder> HouseholderRepository { get; }
    IGenericRepository<HouseDetail> HouseDetailRepository { get; }
    IGenericRepository<Bill> BillRepository { get; }
}
