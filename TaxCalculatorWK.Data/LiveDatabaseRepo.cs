using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculatorWK.Models.Interfaces;
using TaxCalculatorWK.Models.Models;

namespace TaxCalculatorWK.Data
{
    /// <summary>
    /// for future implementation of live repository
    /// </summary>
    public class LiveDatabaseRepo : ITaxCalcRepo
    {
        public List<IBasket> LoadData()
        {
            throw new NotImplementedException();
        }
    }
}
