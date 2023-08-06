using Base.Response;
using Data.Models;
using Schema;
using Services.Generic;

namespace Services;

public interface IUserLogService : IGenericService<UserLog, UserLogRequest, UserLogResponse>
{
    ApiResponse<List<UserLogResponse>> GetByUserSession(string username);
}
