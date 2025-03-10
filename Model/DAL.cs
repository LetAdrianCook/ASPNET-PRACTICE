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

    }
}
