using AutoMapper;
using Data;
using Data.Models;

namespace Schema.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<HouseholderRequest, Householder>();
        CreateMap<Householder, HouseholderResponse>();

        CreateMap<HouseDetailRequest, HouseDetail>();
        CreateMap<HouseDetail, HouseDetailResponse>();

        CreateMap<BillRequest, Bill>();
        CreateMap<Bill, BillResponse>();

        CreateMap<UserRequest, User>();
        CreateMap<User, UserResponse>();

        CreateMap<UserLogRequest, User>();
        CreateMap<User, UserLogResponse>();
    }
}
