using Dapper;
using Dekatop_II_04.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekatop_II_04.DataAccess
{
    public class EventDal
    {
        private readonly Database _database;
        public EventDal()
        {
            _database = new Database();
        }
        public Event GetEventById(int id)
        {
            try
            {
                using (var conn = _database.GetConnection())
                {
                    var query = "SELECT * FROM Events WHERE EventId = @Id";
                    return conn.QuerySingleOrDefault<Event>(query, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return null;
            }
        }

        public List<Event> GetAllEvent()
        {
            try
            {
                using (var conn = _database.GetConnection())
                {
                    var query = "SELECT * FROM Events";
                    return conn.Query<Event>(query).ToList();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error : {ex.Message}"); 
                return new List<Event>();
            }
        }

        public List<ParticipantEvent> GetEventWithParticipantsByEventId(int eventId)
        {
            using (var conn = _database.GetConnection())
            {
                var query = @"
            SELECT e.EventId AS Id, e.EventName, e.DistanceKm, 
                   p.ParticipantId, p.EventId, p.Name, p.Age, p.Speed
            FROM Events e
            INNER JOIN Participants p ON e.EventId = p.EventId
            WHERE e.EventId = @EventId";

                var dp = new DynamicParameters();
                dp.Add("@EventId", eventId);


                 var result = conn.Query<ParticipantEvent, Participant, ParticipantEvent>(
                     query,
                     (eventObj, participantObj) => 
                     {
                         eventObj.Participant.Add(participantObj);
                         return eventObj;
                     },
                     param: dp,
                     splitOn: "ParticipantId"
                     ).ToList(); 

                return result;

            }
        }
    }
}
