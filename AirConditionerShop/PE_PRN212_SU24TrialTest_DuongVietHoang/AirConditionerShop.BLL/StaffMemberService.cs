using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL;
using AirConditionerShop.DAL.Models;


namespace AirConditionerShop.BLL
{
    public class StaffMemberService
    {
        private StaffMemberRepository _repo = new();

        public StaffMember? CheckLogin(string email, string password)
        {
            return _repo.GetAccount(email, password);
        }
    }
}
