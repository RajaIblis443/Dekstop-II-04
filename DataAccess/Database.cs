using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekatop_II_04.DataAccess
{
    public class Database
    {
        private readonly string _connectionString;

        public Database()
        {
            _connectionString = "Server = LAPTOP-HOMFNF2S\\SQLEXPRESS; Database=MarathonDB; Integrated Security=True; TrustServerCertificate=True;";

        }
        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
