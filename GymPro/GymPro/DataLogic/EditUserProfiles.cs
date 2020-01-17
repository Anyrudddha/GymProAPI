using GymPro.Interface;
using GymPro.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GymPro.DataLogic
{
    public class EditUserProfiles : IEditUserProfile
    {
        static string connectionstring = @"Data Source=DESKTOP-CMLCI7G\Lenovo,49172;Initial Catalog=GymPro;Persist Security Info=false;User ID=ayush;Password=ayush";
        SqlConnection con = new SqlConnection(connectionstring);
            

        EditUserProfile userProfile = new EditUserProfile();
        public void UpdateUserProfile( string id)
        {
            List<EditUserProfile> ep = new List<EditUserProfile>();


            SqlCommand cmd = new SqlCommand("select User_Name, User_Email, User_Password, User_Contact_number, User_Age,User_Address from tbl_UserRegistration where User_Id='" + id + "'", con);
            cmd.CommandType = CommandType.Text;

            con.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    EditUserProfile Profile = new EditUserProfile();
                    Profile.UserName = sdr[0].ToString();
                    Profile.UserEmail = sdr[1].ToString();
                    Profile.UserPassword = sdr[2].ToString();
                    Profile.Usercontact = sdr[3].ToString();
                    Profile.UserAge = Convert.ToInt32(sdr[4]);
                    Profile.UserAddress = sdr[5].ToString();
                    ep.Add(Profile);
                }
            }
            con.Close();

            //return (EP);
        }


    }
}


