using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymPro.Models
{
    public class Notification
    {
        public string userId { get; set; }
        public string Subscription_Id { get; set; }
        public string Subcription_start_date { get; set; }
        public string Subsription_end_date { get; set; }
        public string Subscription_amount_paid { get; set; }
    }
}
