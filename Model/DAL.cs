using Microsoft.Data.SqlClient;
using System.Data;

namespace ASPNET_PRACTICE.Model
{
    public class DAL
    {

        //first method to get the users sa database nko na user table
       public List<Users> GetUsers(IConfiguration _configuration)
        {
            List<Users> users = new List<Users>();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString()))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [User]", con); //reserverd word ang User mao gi sulod sa bracket
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Users user = new Users();
                        user.ID = Convert.ToString(dt.Rows[i]["ID"]);
                        user.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                        user.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                        users.Add(user);
                    }
                }
            }
            return users;
        }


        public int AddUser(Users user, IConfiguration _configuration) //method to add user sa database
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString()))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [User](FirstName,LastName) VALUES(@FirstName,@LastName)", con); //ayawg kalimot sa bracket kay reserved word daw ang User
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName); //wala nko gi manual butang sa sql command since pangit mag '" + user.FirstName + "' kay prone sa sql injection ana ang copilot
                con.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public Users GetUser(string id, IConfiguration _configuration)
        {
            Users user = new Users();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString()))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [User] WHERE ID = '" + id + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    user.ID = Convert.ToString(dt.Rows[0]["ID"]);
                    user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                    user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                }
            }
            return user;
        }

        public int UpdateUser(Users user, IConfiguration _configuration)
        {
            int i = 0;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString()))
            {
                SqlCommand cmd = new SqlCommand("Update [User] SET FirstName = '" + user.FirstName + "', LastName = '" + user.LastName + "' WHERE ID = '" + user.ID + "'", con);
                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return i;
        }

    }
}
