using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymPro.Models
{
    public class User
    {
     
        public string User_Profile { get; set; }
        public string User_Name { get; set; }
        public string User_Mail_Id { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Contact_Number { get; set; }
        public DateTime DateOfBIrth { get; set; }
        public string city { get; set; }
        public string pincode { get; set; }
        public string longitude { get; set; }
        public DateTime latitude { get; set; }
        public string status { get; set; }
        public string user_age { get; set; }

    }
}
