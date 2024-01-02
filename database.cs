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

        public void AddHabit(int User,int habitID, int frequency,string habitName,DateTime stratdate,DateTime endDate)
        {
            DataTable dt = new DataTable();
            string Query = $"Insert into Habits(habit_id,userID,Frequency,habit_name,startDate,EndDate) VALUES (@HABITid,@USERid,@frequency,@HABITname,@StartDate,@endDate)";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@HABITid", habitID);
                cmd.Parameters.AddWithValue("@USERid", User);
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
                "INSERT INTO users(Email,user_Password,User_Name,User_ID) VALUES(@email,@PASSWORD,@USERNAME,(select count(*) from users)+1)";
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

    }
}

