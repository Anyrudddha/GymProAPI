using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using GymPro.Interfaces;
using GymPro.Models;
namespace GymPro.DataLogic
{
    public  class GymCustomer:IGymCustomer
    {
         static List<Gym_Customer> GymCoustomers =  new List<Gym_Customer>();
        string conString = @"Data Source=DESKTOP-CMLCI7G\Lenovo,49172;Initial Catalog=GymPro;User ID=ayush;Password=ayush";
        public  List<Gym_Customer> GetAllCoustomers(string gymId)
        {
            GymCoustomers.Clear();
            SqlDataReader rdr = null;
            
        using (SqlConnection connection = new SqlConnection(conString))
        {
            connection.Open();

                SqlCommand command = new SqlCommand("getallGymCustomers", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GymId", gymId);
                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    GymCoustomers.Add(new Gym_Customer() {
                        userId = rdr[0].ToString(),
                        gymId = rdr[1].ToString(),
                        Customer_name = rdr[2].ToString(),
                        User_Joining_date = rdr[3].ToString(),
                        Pending_Fees = Convert.ToDouble(rdr[4]),
                        Paid_Fees = Convert.ToDouble(rdr[5]),
                        Gym_Subscription_Type = rdr[6].ToString(),
                        Gym_Service_Type = rdr[7].ToString(),
                        Subs_Status = Convert.ToInt32(rdr[8]),

                    });
                }

                connection.Close();

            }
            return GymCoustomers;
        }
       public  int ChangeStatus(string gymId, string userId,string status)
        {
            
           // SqlDataReader rdr = null;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("UpdateGymcoustomerstatus", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GymId", gymId);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@status",Convert.ToInt32(status));
                int val =command.ExecuteNonQuery();
                if(val==1)
                {
                    connection.Close();
                    return 1;
                }else
                {
                    connection.Close();
                    return 0;
                }
                
            }
           
                 
        }
    }
}
