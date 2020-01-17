using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymPro.DataLogic;
using GymPro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GymPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        UserDataLogic logic = new UserDataLogic();
        [HttpPost]
        public void Post(string UserData )
        {

            User user = new User();
            user = JsonConvert.DeserializeObject<User>(UserData);
            logic.AddUser(user.User_Profile,user.User_Name,user.User_Mail_Id,user.Password);
            
            //return new string[] { "value1", "value2" };
        }
        public void Post()
        {
            // logic.
          //  return new string[] { "value1", "value2" };
        }



    }
}