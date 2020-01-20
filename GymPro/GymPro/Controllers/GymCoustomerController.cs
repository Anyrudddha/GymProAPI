using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GymPro.DataLogic;
using GymPro.Models;
namespace GymPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class GymCoustomerController : ControllerBase
    {
        GymCustomer g = new GymCustomer();
        // GET api/values
        [HttpGet("{GymId}/{UserId}/{status}")]
        public int  Get(string GymId,string UserId,string status)
        {
            return  g.ChangeStatus(GymId,UserId,status) ;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<Gym_Customer> Get(String id)
        {
            return g.GetAllCoustomers(id); 
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}