using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using GymPro.Properties.Models;

namespace GymPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        List<GymDetails> gym = new List<GymDetails>();
        string ConnectionString = @"Data Source=DESKTOP-CMLCI7G\Lenovo,49172;Initial Catalog=GymPro;User ID=ayush;Password=ayush";

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
       [HttpGet("{id}")]
       [Route("/Getdata/")]
        public List<GymDetails> Get(string id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("GetDataById",con);
            cmd.Parameters.AddWithValue("@Gym_Id",id);

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    GymDetails gd = new GymDetails();
                    gd.Gym_Id = Convert.ToInt32(rd[0]);
                    gd.Gym_Name = rd[1].ToString();
                    gd.Gym_Owner_Name = rd[2].ToString();
                    gd.Gym_Address = rd[3].ToString();
                    gd.Gym_Pincode = rd[4].ToString();
                    gd.PhoneNumber = rd[5].ToString();
                    gd.Gym_Website = rd[6].ToString();
                    gd.Gym_MailId = rd[7].ToString();
                    gd.Registration_Date = rd[8].ToString();
                    gd.Password = rd[9].ToString();
                    gd.Gym_Certification_Number = rd[10].ToString();
                    gd.Gym_Location_logitude = rd[11].ToString();
                    gd.Gym_Location_latitude = rd[12].ToString();
                    gd.Company_Registration_Date = rd[13].ToString();
                    gd.Service_Tax_Number = rd[14].ToString();
                    gd.GST_Number = rd[15].ToString();
                    gd.Status = rd[16].ToString();

                    gym.Add(gd);
                    
                }
              
            }
            return gym;

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
