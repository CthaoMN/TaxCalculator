using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculatorWK.Models.Interfaces;
using TaxCalculatorWK.Data;

namespace TaxCalculatorWK.BLL
{
    public class TaxCalculatorWKManager
    {
        private ITaxCalcRepo _taxCalcRepo;
        public TaxCalculatorWKManager(ITaxCalcRepo taxCalcRepo)
        {
            _taxCalcRepo = taxCalcRepo;
        }
        public List<IBasket> Load()
        {
            try
            {
                return _taxCalcRepo.LoadData();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed loading data", ex);
            }
        }
    }
}
