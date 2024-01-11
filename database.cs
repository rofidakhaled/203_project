using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication9.Models
{
    public class database
    {
        public SqlConnection con = new SqlConnection();

        public database()
        {
            string conSTR = " Data Source=localhost;Initial Catalog=Listo; User id=sa ;Password=Rehab123;";
            con = new SqlConnection(conSTR);
        }

        public void AddHabit(int User,int habitID,string habitName,DateTime date)
        {
            DataTable dt = new DataTable();
            string Query = $"Insert into Habits(habit_id,userID,habit_name,HabitStatus,completeDate) VALUES (@HABITid,@USERid,@HABITname,'Uncomlete',@Date)";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@HABITid", habitID);
                cmd.Parameters.AddWithValue("@USERid", User);
                cmd.Parameters.AddWithValue("HABITname", habitName);
                cmd.Parameters.AddWithValue("Date", date);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public void CheckedHabit(int userid,int habitID, DateTime date)
        {
            DataTable dt = new DataTable();
            string Query = $"Insert into Habits(userID,habit_id,compeletedate,status)Values(@userId,@HabitID,@date)";
            try
            {
              con.Open();
              SqlCommand cmd = new SqlCommand(Query, con);
              cmd.Parameters.AddWithValue("@userid", userid);
              cmd.Parameters.AddWithValue("@HabitID", habitID);
              cmd.Parameters.AddWithValue("@date", date);
              cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public string? addUser(string Email, string password, string username)
        {
            string answer=null;
            string query =
                "INSERT INTO users(User_Email,User_Password,User_Name,User_ID) VALUES(@email,@PASSWORD,@USERNAME,(select count(*) from users)+1)";
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("PASSWORD", password);
                cmd.Parameters.AddWithValue("USERNAME", username);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                answer = e.Message;
            }
            finally
            {
                con.Close();
            }

            return answer;
        }

        public string? AddEvent(string occassion, int year, int month,int day)
        {
            string insertion=null;
            string query =
                "INSERT INTO calender(event_id,event_name,timeslot) VALUES((SELECT count(*) from calender)+1,@Name,DATEFROMPARTS(@year,@month,@day))";
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", occassion);
                cmd.Parameters.AddWithValue("@year",year );
                cmd.Parameters.AddWithValue("@month",month );
                cmd.Parameters.AddWithValue("@day",day );

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                insertion = e.Message;
            }
            finally
            {
                con.Close();
            }

            return insertion;
        }

        public int returnID(string Email)
        {
            int ID;
            DataTable dt = new DataTable();
            string Query = $"SELECT USER_ID from users where User_Email={Email}";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                ID = (int)cmd.ExecuteScalar();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                con.Close();
            }

            return ID;
        }

    }
}

