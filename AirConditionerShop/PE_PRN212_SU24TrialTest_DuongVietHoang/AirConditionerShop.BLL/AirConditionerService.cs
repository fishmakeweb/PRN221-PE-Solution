using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL;
using AirConditionerShop.DAL.Models;

namespace AirConditionerShop.BLL
{
    public class AirConditionerService
    {
        private AirConditionerRepository _repo = new AirConditionerRepository();

        public List<AirConditioner> GetAllAirConditioners()
        {
            return _repo.GetAirConditioners();
        }

        public void AddAirConditionerFromUI(AirConditioner airConditioner)
        {
            _repo.AddAirConditioner(airConditioner);
        }

        public void UpdateAirConditionerFromUI(AirConditioner airConditioner)
        {
            _repo.UpdateAirConditioner(airConditioner);
        }

        public void DeleteAirConditionerFromUI(AirConditioner airConditioner)
        {
            _repo.DeleteAirConditioner(airConditioner);
        }

    }
}
