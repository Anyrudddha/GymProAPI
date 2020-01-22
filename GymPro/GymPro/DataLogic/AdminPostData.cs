using GymPro.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GymPro.DataLogic
{
    public class AdminPostData
    {
       // string str = ;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CMLCI7G\Lenovo,49172;Initial Catalog=GymPro;User ID=ayush;Password=ayush");
        public void AddAdmin(string name,string email,string mobile_num, string Gender, string type, string Password,string created_date)
        {
            DateTime crdate = Convert.ToDateTime(created_date);
            string status = "1";

            DateTime today = DateTime.Today;

           // SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("AddApplicationAdmin", con);
        
            cmd.Parameters.AddWithValue("@name",name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@mobile_num",mobile_num);
            cmd.Parameters.AddWithValue("@gender", Gender);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@password", Password);
            cmd.Parameters.AddWithValue("@status",status);
            cmd.Parameters.AddWithValue("@createdate",crdate);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int AppAddminLogin(string Loginemail, string Loginpassword)
        {
            int LoginCotrrect = 0;
            SqlCommand cmd = new SqlCommand("Select * from tbl_ApplicationAdmin WITH (NOLOCK) where adminEmail='" + Loginemail+ "' and adminPassword='"+Loginpassword+"'",con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                LoginCotrrect = 1;
            }
            con.Close();
            return LoginCotrrect;

        }

        public List<GymUsers> getAllGymUsers()
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_UserRegistration with(nolock)", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<GymUsers> gymUserslist = new List<GymUsers>();
            while (reader.Read())
            {
                GymUsers user = new GymUsers();


                user.User_Id = reader[0].ToString();
                user.user_profile_image = reader[1].ToString();
                user.User_Name= reader[2].ToString();
                user.User_Mail_Id= reader[3].ToString();
                user.Password= reader[4].ToString();
                user.Gender= reader[5].ToString();
                user.Contact_Number= reader[6].ToString();
                user.DateOfBIrth= reader[7].ToString();
                user.User_Age = reader[8].ToString();
                user.city= reader[9].ToString();
                user.Ragistration_date= reader[10].ToString();
                user.User_Location_Logitude= reader[11].ToString();
                user.User_Location_Latitude= reader[12].ToString();
                user.User_status= reader[13].ToString();
                user.pincode = reader[14].ToString();

                gymUserslist.Add(user);
            }
            reader.Close();
            con.Close();
            return gymUserslist;
        }

        public List<GymOwners> getAllGymOwner()
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_Gym_Registration with(nolock)", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<GymOwners> gymOwnerlist = new List<GymOwners>();
            while (reader.Read())
            {
                GymOwners gymowner = new GymOwners();

                gymowner.Gym_Id = reader[0].ToString();
                gymowner.Gym_Name = reader[1].ToString();
                gymowner.Gym_Owner_Name = reader[2].ToString();
                gymowner.Gym_Address = reader[3].ToString();
                gymowner.Gym_Pincode = reader[4].ToString();
                gymowner.PhoneNumber = reader[5].ToString();
                gymowner.Gym_Website = reader[6].ToString();
                gymowner.Gym_MailId = reader[7].ToString();
                gymowner.Gym_Registration_Date = reader[8].ToString();
                gymowner.Password = reader[9].ToString();
                gymowner.Gym_Certification_Number = reader[10].ToString();
                gymowner.Gym_Location_longitude = reader[11].ToString();
                gymowner.Gym_Location_latitude = reader[12].ToString();
                gymowner.Company_Registration_Date = reader[13].ToString();
                gymowner.Service_Tax_Number = reader[14].ToString();
                gymowner.GST_Number = reader[15].ToString();
                gymowner.status = reader[16].ToString();


                gymOwnerlist.Add(gymowner);
            }
            reader.Close();
            con.Close();
            return gymOwnerlist;
        }

        public List<Application_Admin> AppAdminInfo(string adminemail)
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_ApplicationAdmin with(nolock) where adminEmail='"+adminemail+"'", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Application_Admin> admindata = new List<Application_Admin>();
            while (reader.Read())
            {
                Application_Admin admin = new Application_Admin();

                admin.Admin_Id = reader[0].ToString();
                admin.Admin_Name = reader[1].ToString();
                admin.Admin_Email = reader[2].ToString();
                admin.Mobile_Number = reader[3].ToString();
                admin.Admin_Password= reader[4].ToString();
                admin.Admin_Gender = reader[5].ToString();
                admin.Admin_Type= reader[6].ToString();
                admin.Admin_Create_date = reader[7].ToString();
                admin.Status = reader[8].ToString();

                admindata.Add(admin);
            }
            reader.Close();
            con.Close();
            return admindata;
        }

        

            public List<ContactUsMessege> getAllContactMessage()
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_ContactUs with(nolock)", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<ContactUsMessege> contactUslist = new List<ContactUsMessege>();
            while (reader.Read())
            {
                ContactUsMessege contactUs = new ContactUsMessege();

                contactUs.ContactUs_Id = reader[0].ToString();
                contactUs.ContactUs_Name = reader[1].ToString();
                contactUs.ContactUs_Message = reader[2].ToString();
                contactUs.ContactUs_ContactNo = reader[3].ToString();
                contactUs.ContactUs_Email = reader[4].ToString();
                contactUs.ContactUs_Status = reader[5].ToString();
                contactUs.ContactUs_Date = reader[6].ToString();
               

                contactUslist.Add(contactUs);
            }
            reader.Close();
            con.Close();
            return contactUslist;
        }

        public List<Notification> getNotifications()
        {
            SqlCommand cmd = new SqlCommand("select * from tbl_SubcribedByGym with(nolock)  WHERE Subscription_end_date<=(SELECT GETDATE()+2) union select * from tbl_SubcribedByUser with(nolock) WHERE Subscription_end_date <= (SELECT GETDATE() + 2)", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Notification> notifications_list = new List<Notification>();
            while (reader.Read())
            {
                Notification notifications = new Notification();

                notifications.userId = reader[1].ToString();
                notifications.Subscription_Id = reader[2].ToString();
                notifications.Subcription_start_date = reader[3].ToString();
                notifications.Subsription_end_date = reader[4].ToString();
                notifications.Subscription_amount_paid = reader[5].ToString();

                notifications_list.Add(notifications);
            }
            reader.Close();
            con.Close();
            return notifications_list;
        }

    }
}
