using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechZone.Domain.Response;
using TechZone.Service.Interface;

namespace TechZone.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DapperDepartementController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DapperDepartementController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet]
        public async Task<List<DepartmentDetail>> Get()
        {
            return await departmentService.Get();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<DepartmentDetail> GetById(int id)
        {
            return await departmentService.GetById(id);
        }

        [HttpPost]
        public async Task<CreateDepartement> CreateDepartment(DepartmentDetail departmentDetail)
        {
            return await departmentService.CreateDepartment(departmentDetail);
        }
    }
}
