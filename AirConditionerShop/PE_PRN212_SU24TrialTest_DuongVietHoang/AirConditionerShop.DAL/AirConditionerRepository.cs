using AirConditionerShop.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerShop.DAL
{
    public class AirConditionerRepository
    {
        private AirConditionerShop2024DbContext? _context;
        public List<AirConditioner> GetAirConditioners()
        {
            _context = new AirConditionerShop2024DbContext();
            _context = new();
            return _context.AirConditioners
                 .Include(b => b.Supplier) // Eager loading of BookCategory
                 .ToList();
        }

        public AirConditioner? GetAirConditionerById(int id)
        {
            _context = new AirConditionerShop2024DbContext();
            return _context.AirConditioners
                           .Include(ac => ac.Supplier) 
                           .FirstOrDefault(ac => ac.AirConditionerId == id);
        }

        public void AddAirConditioner(AirConditioner airConditioner)
        {
            _context = new();
            _context.AirConditioners.Add(airConditioner);
            _context.SaveChanges();
        }
        public void UpdateAirConditioner(AirConditioner airConditioner)
        {
            _context = new();
            _context.AirConditioners.Update(airConditioner);
            _context.SaveChanges();
        }


        public void DeleteAirConditioner(AirConditioner airConditioner)
        {
            _context = new();
            _context.AirConditioners.Remove(airConditioner);
            _context.SaveChanges();
        }


    }
}
