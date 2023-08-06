using Base.Response;
using Data;
using Schema;
using Services.Generic;

namespace Services;

public interface IBillService : IGenericService<Bill, BillRequest, BillResponse>
{
    ApiResponse<List<BillResponse>> GetAll();
    ApiResponse<BillResponse> GetById(int id);
}
