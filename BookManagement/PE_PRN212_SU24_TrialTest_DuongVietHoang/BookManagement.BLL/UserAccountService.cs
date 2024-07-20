using BookManagement.DAL.Models;
using BookManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.BLL
{
    public class UserAccountService
    {
        private UserAccountRepository _repo = new();

        public UserAccount? CheckLogin(string email, string password)
        {
            return _repo.GetAccount(email, password);
        }
    }
}
