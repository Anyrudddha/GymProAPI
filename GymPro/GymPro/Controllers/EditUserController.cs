using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using GymPro.DataLogic;
using GymPro.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditUserController : ControllerBase
    {
        
        EditUserProfile ed = new EditUserProfile();
        EditUserProfiles eps = new EditUserProfiles();
        List<EditUserProfile> ep = new List<EditUserProfile>();

        // GET: api/EditUser
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EditUser/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EditUser
        [HttpPost]
        [Route("api/EditUser/EditUserProfile")]
        public void Post(string value)
        {
           

        }

        // PUT: api/EditUser/5
        [HttpPut("{id}")]
        public void Put(string id)
        {

            eps.UpdateUserProfile(id);
             //return ep;


        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
