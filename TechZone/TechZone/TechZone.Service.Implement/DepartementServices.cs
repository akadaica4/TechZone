using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TechZone.Domain.Response;
using TechZone.Service.Interface;
using Twilio.TwiML.Voice;

namespace TechZone.Service.Implement
{
    public class DepartementServices : BaseServices, IDepartmentService
    {
        public DepartementServices(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<CreateDepartement> CreateDepartment(DepartmentDetail departmentDetail)
        {
            var result = new CreateDepartement()
            {
                Success = false,
                Message = "wrong"
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DepartmentName", departmentDetail.DepartmentName);
                parameters.Add("@DepartmentPhoneNumber", departmentDetail.DepartmentPhoneNumber);
                parameters.Add("@DepartmentLocation", departmentDetail.DepartmentLocation);
                var createResult = await SqlMapper.ExecuteScalarAsync<int>
                    (
                        cnn: connect,
                        sql: "Sp_CreateDepartmentId",
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );
                if (createResult > 0)
                {
                    result.Success = true;
                    result.Message = "Departement create successfully";
                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public async Task<List<DepartmentDetail>> Get()
        {
            var result = await SqlMapper.QueryAsync<DepartmentDetail>
                (cnn: connect, sql: "Sp_GetDepartement", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<DepartmentDetail> GetById(int departementId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", departementId);
            return await SqlMapper.QueryFirstOrDefaultAsync<DepartmentDetail>
                (
                cnn: connect, sql: "Sp_GetById", param: dynamicParameters, commandType: CommandType.StoredProcedure
                );
  
        }
    }
}
