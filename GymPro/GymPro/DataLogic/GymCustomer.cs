using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using GymPro.Interfaces;
using GymPro.Models;
namespace GymPro.DataLogic
{
    public  class GymCustomer:IGymCustomer
    {
        public static List<Gym_Customer> GymCoustomers =  new List<Gym_Customer>();
        public  List<Gym_Customer> GetAllCoustomers(string gymId)
        {
            SqlDataReader rdr = null;
            string conString = @"Data Source=DESKTOP-CMLCI7G\Lenovo,49172;Initial Catalog=GymPro;User ID=ayush;Password=ayush";
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
                        Gym_Id = rdr[0].ToString(),
                        User_Id = rdr[1].ToString(),
                        User_Joining_date = rdr[2].ToString(),
                        Pending_Fees = Convert.ToDouble(rdr[3]),
                        Paid_Fees = Convert.ToDouble(rdr[4]),
                        Gym_Subscription_Type = rdr[5].ToString(),
                        Gym_Service_Type = rdr[6].ToString(),
                        Subs_Status = Convert.ToBoolean(rdr[7])
                    });
                }



            }
            return GymCoustomers;
        }
       public  void ChangeStatus(string gymId, string userId)
        {

        }
    }
}
