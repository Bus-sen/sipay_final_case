﻿using Base.Response;
using Microsoft.AspNetCore.Mvc;
using Schema;
using Services;

namespace sipay_final_case.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService service;

        public BillController(IBillService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ApiResponse<List<BillResponse>> GetAll()
        {
            var entityList = service.GetAll();
            return entityList;
        }

        [HttpGet("{id}")]
        public ApiResponse<BillResponse> Get(int id)
        {
            var entity = service.GetById(id);
            return entity;
        }

        [HttpPost]
        public ApiResponse Post([FromBody] BillRequest request)
        {
            var response = service.Insert(request);
            return response;
        }

        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] BillRequest request)
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
