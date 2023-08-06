using AutoMapper;
using Base.Response;
using Data.Models;
using Data.Uow;
using Schema;
using Services.Generic;

namespace Services;

public class UserLogService : GenericService<UserLog, UserLogRequest, UserLogResponse>, IUserLogService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UserLogService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public ApiResponse<List<UserLogResponse>> GetByUserSession(string username)
    {
        var list = unitOfWork.UserLogRepository.Where(x => x.UserName == username).ToList();
        var mapped = mapper.Map<List<UserLogResponse>>(list);
        return new ApiResponse<List<UserLogResponse>>(mapped);
    }
}
