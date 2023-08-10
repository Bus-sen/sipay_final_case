using AutoMapper;
using Data;

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

    }
}
