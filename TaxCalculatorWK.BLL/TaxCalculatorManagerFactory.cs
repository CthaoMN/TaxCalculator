using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculatorWK.Data;

namespace TaxCalculatorWK.BLL
{
    /// <summary>
    /// AppConfig will determine which class to make, this allows for extensibility
    /// </summary>
    public class TaxCalculatorWKManagerFactory
    {
        public static TaxCalculatorWKManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new TaxCalculatorWKManager(new MemoryRepo());
                //  case "Live":
                //    return new TaxCalculatorWKManager(new LiveDatabaseRepo());

                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }



    }
}
