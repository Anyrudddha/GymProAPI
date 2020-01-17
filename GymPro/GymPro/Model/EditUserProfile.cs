using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymPro.Model
{
    public class EditUserProfile
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string Usercontact { get; set; }
        public int UserAge { get; set; }
        public string UserAddress { get; set; }
    }

}
