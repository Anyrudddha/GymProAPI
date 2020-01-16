using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymPro.Models
{
    public class Gym_Customer
    {
        public string Gym_Id { get; set; }
        public string User_Id { get; set; }
        public string User_Joining_date { get; set; }
        public double Pending_Fees { get; set; }
        public double Paid_Fees { get; set; }
        public string Gym_Subscription_Type { get; set; }
        public string Gym_Service_Type { get; set; }
        public bool Subs_Status { get; set; }
    }
}
