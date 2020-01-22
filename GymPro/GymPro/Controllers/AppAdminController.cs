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
        public string addAdmin(string AdminData)
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

        [HttpGet]
        [Route("AllgymUsersGet")]
        public string AllgymUsersGet(string allUsers)
        {
            
            List<GymUsers> gymuserlist = logic.getAllGymUsers();
            return JsonConvert.SerializeObject(gymuserlist);
  
        }


        [HttpGet]
        [Route("getgymowners")]
        public string getgymowners(string allGymOwners)
        {

            List<GymOwners> gymownerlist = logic.getAllGymOwner();
            return JsonConvert.SerializeObject(gymownerlist);

        }

        [HttpGet]
        [Route("getAppAdminInfo/{Adminemail}")]
        public string getAppAdminInfo(string Adminemail)
        {

            List<Application_Admin> admindata = logic.AppAdminInfo(Adminemail);
            return JsonConvert.SerializeObject(admindata);

        }

        

         [HttpGet]
        [Route("getAllContactMessage")]
        public string getAllContactMessage()
        {

            List<ContactUsMessege> admindata = logic.getAllContactMessage();
            return JsonConvert.SerializeObject(admindata);

        }

        [HttpGet]
        [Route("getNotifications")]
        public string getNotifications()
        {
            List<Notification> notifications = logic.getNotifications();
            return JsonConvert.SerializeObject(notifications);
        }

    }
}