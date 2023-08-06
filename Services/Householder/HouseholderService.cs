using AutoMapper;
using Base.Response;
using Data;
using Data.Uow;
using Schema;
using Services.Generic;

namespace Services;

public class HouseholderService : GenericService<Householder, HouseholderRequest, HouseholderResponse>, IHouseholderService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public HouseholderService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public int GetNextHouseholderNumber()
    {
        int householderNumber = 100;
        var lastHouseholderNumber = unitOfWork.HouseholderRepository.GetAllAsQueryable().OrderByDescending(x => x.HouseholderNumber).FirstOrDefault();
        if (lastHouseholderNumber == null)
        {
            return householderNumber;
        }
        return lastHouseholderNumber.HouseholderNumber + 1;
    }

    public override ApiResponse Insert(HouseholderRequest request)
    {
        request.HouseholderNumber = GetNextHouseholderNumber();
        return base.Insert(request);
    }

    public override ApiResponse<List<HouseholderResponse>> GetAll()
    {
        try
        {
            var entityList = unitOfWork.HouseholderRepository.GetAll();
            var mapped = mapper.Map<List<Householder>, List<HouseholderResponse>>(entityList);
            return new ApiResponse<List<HouseholderResponse>>(mapped);

        }
        catch (Exception ex)
        {
            return new ApiResponse<List<HouseholderResponse>>(ex.Message);
        }
    }

    public ApiResponse<HouseholderResponse> GetById(int id)
    {
        try
        {
            var entity = unitOfWork.HouseholderRepository.GetById(id);
            var mapped = mapper.Map<Householder, HouseholderResponse>(entity);
            return new ApiResponse<HouseholderResponse>(mapped);

        }
        catch (Exception ex)
        {
            return new ApiResponse<HouseholderResponse>(ex.Message);
        }
    }
}
