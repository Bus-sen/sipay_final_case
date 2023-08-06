using AutoMapper;
using Base.BaseModel;
using Base.Response;
using Data.Uow;

namespace Services.Generic;

public class GenericService<TEntity, TRequest, TResponse> : IGenericService<TEntity, TRequest, TResponse>
    where TEntity : BaseModel
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public GenericService (IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public virtual ApiResponse Delete(int Id)
    {
        try
        {
            var entity = unitOfWork.DynamicRepository<TEntity>().GetById(Id);
            if (entity == null)
            {
                return new ApiResponse("Record not found!");
            }

            unitOfWork.DynamicRepository<TEntity>().DeleteById(Id);
            unitOfWork.Complete();
            return new ApiResponse();
        }
        catch (Exception ex)
        {
            return new ApiResponse(ex.Message);
        }
    }

    public virtual ApiResponse<List<TResponse>> GetAll()
    {
        try
        {
            var entity = unitOfWork.DynamicRepository<TEntity>().GetAll();
            var mapped = mapper.Map<List<TEntity>, List<TResponse>>(entity);
            return new ApiResponse<List<TResponse>>(mapped);

        }
        catch (Exception ex)
        {
            return new ApiResponse<List<TResponse>>(ex.Message);
        }
    }

    public virtual ApiResponse<TResponse> GetById(int id)
    {
        try
        {
            var entity = unitOfWork.DynamicRepository<TEntity>().GetById(id);
            var mapped = mapper.Map<TEntity, TResponse>(entity);
            return new ApiResponse<TResponse>(mapped);
        }
        catch (Exception ex)
        {
            return new ApiResponse<TResponse>(ex.Message);
        }
    }

    public virtual ApiResponse Insert(TRequest request)
    {
        try
        {
            var entity = mapper.Map<TRequest, TEntity>(request);

            unitOfWork.DynamicRepository<TEntity>().Create(entity);
            unitOfWork.DynamicRepository<TEntity>().Save();

            return new ApiResponse();
        }
        catch (Exception ex)
        {
            return new ApiResponse(ex.Message);
        }
    }

    public virtual ApiResponse Update(int Id, TRequest request)
    {
        try
        {
            var exist = unitOfWork.DynamicRepository<TEntity>().GetById(Id);
            if (exist == null)
            {
                return new ApiResponse("Record not found!");
            }

            var entity = mapper.Map<TRequest, TEntity>(request);
            unitOfWork.DynamicRepository<TEntity>().Update(entity);
            unitOfWork.DynamicRepository<TEntity>().Save();

            return new ApiResponse();
        }
        catch (Exception ex)
        {
            return new ApiResponse(ex.Message);
        }
    }
}
