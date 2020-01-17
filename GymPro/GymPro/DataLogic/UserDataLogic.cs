using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
//using System.Data.SqlClient;

namespace GymPro.DataLogic
{
    public class UserDataLogic
    {
        string str = @"Data Source=DESKTOP-CMLCI7G\Lenovo,49172;Initial Catalog=GymPro;User ID=ayush;Password=ayush";

        public void AddUser(string User_Profile,string User_Name,string User_Email, string Password)
        {
            int User_Id=1;
            Random random = new Random();

            random.Next(0, 1000);

            string uid= Convert.ToString("U-"+User_Id);

            SqlConnection con = new SqlConnection(str);


            SqlCommand cmd = new SqlCommand("insert into tbl_UserRegistration(User_Id,User_Profile,User_Name,User_Email,User_Password,User_Status) values('" +uid+"','" + User_Profile + "','" + User_Name + "','" + User_Email + "','"+ Password+"',1)",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
          
        }
    }
    
}
