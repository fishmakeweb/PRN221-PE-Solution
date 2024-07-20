using AirConditionerShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerShop.DAL
{
    public class SupplierCompanyRepository
    {
        private AirConditionerShop2024DbContext? _context;
        public List<SupplierCompany> GetSupplierCompanies()
        {
            _context = new();
            return _context.SupplierCompanies.ToList();
        }
    }
}
