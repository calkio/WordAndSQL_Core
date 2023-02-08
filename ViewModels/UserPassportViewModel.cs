using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAndSQL_Core.Entity;

namespace WordAndSQL_Core.ViewModels
{
    class UserPassportViewModel
    {
        public List<Users> GetDataUsers()
        {
            using (var connection = new SqlConnection("Data Source=CALKIO\\MSSQLSERVER01;Initial Catalog=WordAndSQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var sql = "SELECT * FROM Users";

                var users = connection.Query<Users>(sql).ToList();

                return users;
            }
        }
    }
}
