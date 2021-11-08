using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZone.Domain.Response;

namespace TechZone.Service.Interface
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDetail>> Get();
        Task<DepartmentDetail> GetById(int departementId);
        Task<CreateDepartement> CreateDepartment(DepartmentDetail departmentDetail);
        
    }
}
