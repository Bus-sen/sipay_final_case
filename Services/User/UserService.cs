﻿using AutoMapper;
using Data.Models;
using Data.Uow;
using Schema;
using Services.Generic;

namespace Services;

public class UserService : GenericService<User, UserRequest, UserResponse>, IUserService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UserService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
}