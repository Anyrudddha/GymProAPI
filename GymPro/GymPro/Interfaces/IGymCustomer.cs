using GymPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymPro.Interfaces
{
   public interface IGymCustomer
    {
         List<Gym_Customer> GetAllCoustomers(string gymId);
          void ChangeStatus(string  gymId,string userId);

    }
}
