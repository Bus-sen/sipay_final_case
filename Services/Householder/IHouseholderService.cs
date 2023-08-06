using Data;
using Schema;
using Services.Generic;

namespace Services;

public interface IHouseholderService : IGenericService<Householder, HouseholderRequest, HouseholderResponse>
{
    int GetNextHouseholderNumber();
}
