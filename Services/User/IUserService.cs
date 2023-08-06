using Data.Models;
using Schema;
using Services.Generic;

namespace Services;

public interface IUserService : IGenericService<User, UserRequest, UserResponse>
{
}
