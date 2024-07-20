using AirConditionerShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerShop.DAL
{
    public class StaffMemberRepository
    {
        private AirConditionerShop2024DbContext? _context;
        public StaffMember? GetAccount(string email, string password)
        {
            _context = new();
            return _context.StaffMembers.FirstOrDefault(x => x.EmailAddress == email && x.Password == password);
        }
    }
}
