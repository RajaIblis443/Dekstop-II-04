using Dapper;
using Dekatop_II_04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekatop_II_04.DataAccess
{
    public class ParticipantDal
    {
        private Database database;
        public ParticipantDal()
        {
            database = new Database();
        }

        public bool AddUser(Participant participant)
        {
            try
            {
                if (participant == null)
                {
                    MessageBox.Show("Masukan Data");
                    return false;
                }
                using (var conn = database.GetConnection())
                {
                    const string sql = @"INSERT INTO Participants (EventId, Name, Age, Speed) VALUES (@EventId, @Name, @Age,@Speed)";

                    var dp = new DynamicParameters();
                    dp.Add("@EventId", participant.EventId);
                    dp.Add("@Name", participant.Name);
                    dp.Add("@Age", participant.Age);
                    dp.Add("@Speed", participant.Speed);


                    var result = conn.Execute(sql, dp);

                    if (result <= 0)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error : {ex.Message}");
                return false;
            }
        }

        public Participant? getUserById(int id)
        {
            if (id <= 0)
            {
                MessageBox.Show("Participant Not Found");
                return null ;
            }
            try
            {
                using(var conn = database.GetConnection())
                {
                    const string sql = @"SELECT * FROM Participants WHERE ParticipantId = @ParticipantId";

                    var dp = new DynamicParameters();
                    dp.Add("@ParticipantId", id);

                    var result = conn.QueryFirstOrDefault<Participant>(sql, dp);
                    if (result == null)
                    {
                        return null;
                    }
                    return result;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
                return null;
            }
        }

        public bool UpdateUser(Participant participant)
        {
            try
            {
                if (participant == null)
                {
                    MessageBox.Show("Masukan Data");
                    return false;
                }
                using (var conn = database.GetConnection())
                {
                    const string sql = @"UPDATE Participants SET Name = @Name, Age = @Age, Speed = @Speed WHERE ParticipantId = @Id";
                     
                    var dp = new DynamicParameters();
                    dp.Add("@Id", participant.ParticipantId);
                    dp.Add("@Name", participant.Name);
                    dp.Add("@Age", participant.Age);
                    dp.Add("@Speed", participant.Speed);

                    var result = conn.Execute(sql, dp);

                    if (result <= 0)
                    {
                        MessageBox.Show($"{participant.ParticipantId}");
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
                return false;
            }
        }

        public bool deleteUser(int id)
        {
            try
            {
                if (id <= 0)
                {
                    MessageBox.Show("User Not Found");
                    return false;
                }
                using (var conn = database.GetConnection()) 
                {
                    const string sql = @"DELETE FROM Participants WHERE ParticipantId = @Id";
                    var dp = new DynamicParameters();
                    dp.Add("@Id", id);

                    var result = conn.Execute(sql, dp);
                    if (result <= 0)
                    {
                        MessageBox.Show("User Not Found");
                        return false;
                    }
                    MessageBox.Show("Delete Successfuly");
                    return true;
                }
            }
            catch( Exception ex ) 
            {
                MessageBox.Show($"Error : {ex.Message}");
                return false;
            }
        }
    }
}
