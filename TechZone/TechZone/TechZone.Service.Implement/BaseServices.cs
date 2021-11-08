using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechZone.Service.Implement
{
    public class BaseServices
    {
        private readonly IConfiguration configuration;
        protected IDbConnection connect;
        public BaseServices(IConfiguration configuration)
        {
            connect = new SqlConnection(configuration.GetConnectionString("EmployeesManagementDbConnection"));
            this.configuration = configuration;
        }
    }
}
