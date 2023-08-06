﻿using Base.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schema;
using Services;
using System.Security.Claims;

namespace sipay_final_case.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLogController : ControllerBase
    {
        private readonly IUserLogService service;
        public UserLogController(IUserLogService service)
        {
            this.service = service;
        }


        [HttpGet]
        public ApiResponse<List<UserLogResponse>> GetAll()
        {
            var username = User.Claims.Where(x => x.Type == "UserName")?.FirstOrDefault();
            var userid = (User.Identity as ClaimsIdentity).FindFirst("UserId")?.Value;
            var response = service.GetByUserSession(username?.Value);
            return response;
        }

        [HttpGet("{id}")]
        public ApiResponse<UserLogResponse> Get(int id)
        {
            var response = service.GetById(id);
            return response;
        }


        [HttpPost]
        public ApiResponse Post([FromBody] UserLogRequest request)
        {
            var response = service.Insert(request);
            return response;
        }

        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] UserLogRequest request)
        {

            var response = service.Update(id, request);
            return response;
        }


        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            var response = service.Delete(id);
            return response;
        }
    }
}
