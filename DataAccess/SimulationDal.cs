using Dapper;
using Dekatop_II_04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekatop_II_04.DataAccess
{
    public class SimulationDal
    {
        private readonly Database _database;
        public SimulationDal() 
        {
            _database = new Database();
        }

        public List<Participant> LoadParticipants(int eventId) 
        {
            using (var conn = _database.GetConnection())
            {
                string sql = @"SELECT * FROM Participants WHERE EventID = @EventID";

                var dp = new DynamicParameters();
                dp.Add("@EventID", eventId);

                return conn.Query<Participant>(sql, dp).ToList();
            }
        }
    }
}
