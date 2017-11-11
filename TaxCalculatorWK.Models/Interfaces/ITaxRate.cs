using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorWK.Models.Interfaces
{
    /// <summary>
    /// Could incorporate differenet ways of getting tax in the future
    /// </summary>
    public interface ITaxRate
    {
        decimal Tax { get; }
    }
}
