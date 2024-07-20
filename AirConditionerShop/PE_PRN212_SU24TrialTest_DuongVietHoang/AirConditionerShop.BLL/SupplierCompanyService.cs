using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL;
using AirConditionerShop.DAL.Models;


namespace AirConditionerShop.BLL
{
    public class SupplierCompanyService
    {
        private SupplierCompanyRepository _repo = new();

        public List<SupplierCompany> GetAllSupplierCompanies()
        {
            return _repo.GetSupplierCompanies();
        }
    }
}
