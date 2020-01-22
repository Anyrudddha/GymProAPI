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
    public class AppAdminController : ControllerBase
    {

        AdminPostData logic = new AdminPostData();

       

        [HttpPost("{AdminData}")]
        public string Post(string AdminData)
        {

            Application_Admin Admin = new Application_Admin();
            Admin = JsonConvert.DeserializeObject<Application_Admin>(AdminData);

            logic.AddAdmin(Admin.Admin_Name,Admin.Admin_Email,Admin.Mobile_Number,Admin.Admin_Gender,Admin.Admin_Type,Admin.Admin_Password,Admin.Admin_Create_date);

            return new string("Added Successfuly");
        }
       // [Route("api/AppAdmin/login")]
        [HttpPost("{Loginemail}/{Loginpassword}")]
        public int Postlogin(string Loginemail,string Loginpassword)
        {
            int i = 0;
           i= logic.AppAddminLogin(Loginemail,Loginpassword);

            return i;
        }

        [HttpGet("{allUsers}")]
        public string Get(string allUsers)
        {
            
            List<GymUsers> gymuserlist = logic.getAllGymUsers();
            return JsonConvert.SerializeObject(gymuserlist);
  
        }


        [HttpGet("{allGymOwners}/{sds}")]
        public string getgymowners(string allGymOwners)
        {

            List<GymOwners> gymownerlist = logic.getAllGymOwner();
            return JsonConvert.SerializeObject(gymownerlist);

        }

    }
}