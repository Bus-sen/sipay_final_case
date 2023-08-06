using AutoMapper;
using Base.Response;
using Data;
using Data.Uow;
using Schema;
using Services.Generic;

namespace Services;

public class BillService : GenericService<Bill, BillRequest, BillResponse>, IBillService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public BillService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public ApiResponse<List<BillResponse>> GetAll()
    {
        try
        {
            var entityList = unitOfWork.BillRepository.GetAll();
            var mapped = mapper.Map<List<Bill>, List<BillResponse>>(entityList);
            return new ApiResponse<List<BillResponse>>(mapped);

        }
        catch (Exception ex)
        {
            return new ApiResponse<List<BillResponse>>(ex.Message);
        }
    }

    public ApiResponse<BillResponse> GetById(int id)
    {
        try
        {
            var entity = unitOfWork.BillRepository.GetById(id);
            var mapped = mapper.Map<Bill, BillResponse>(entity);
            return new ApiResponse<BillResponse>(mapped);

        }
        catch (Exception ex)
        {
            return new ApiResponse<BillResponse>(ex.Message);
        }
    }
}
