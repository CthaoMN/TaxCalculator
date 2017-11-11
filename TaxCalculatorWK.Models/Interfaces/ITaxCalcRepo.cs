using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorWK.Models.Interfaces
{
    /// <summary>
    /// Used for factory...
    /// </summary>
    public interface ITaxCalcRepo
    {
        List<IBasket> LoadData();
    }
}
