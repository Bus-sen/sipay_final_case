using AutoMapper;
using Base.Response;
using Data;
using Data.Uow;
using Schema;
using Services.Generic;

namespace Services;

public class HouseDetailService : GenericService<HouseDetail, HouseDetailRequest, HouseDetailResponse>, IHouseDetailService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public HouseDetailService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }


    public override ApiResponse<List<HouseDetailResponse>> GetAll()
    {
        try
        {
            var entityList = unitOfWork.HouseDetailRepository.GetAll();
            var mapped = mapper.Map<List<HouseDetail>, List<HouseDetailResponse>>(entityList);
            return new ApiResponse<List<HouseDetailResponse>>(mapped);

        }
        catch (Exception ex)
        {
            return new ApiResponse<List<HouseDetailResponse>>(ex.Message);
        }
    }

    public override ApiResponse<HouseDetailResponse> GetById(int id)
    {
        try
        {
            var entity = unitOfWork.HouseDetailRepository.GetById(id);
            var mapped = mapper.Map<HouseDetail, HouseDetailResponse>(entity);
            return new ApiResponse<HouseDetailResponse>(mapped);

        }
        catch (Exception ex)
        {
            return new ApiResponse<HouseDetailResponse>(ex.Message);
        }
    }
}
