using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using PackageIdentifier.BLL;

namespace PackageIdentifier
{
    class Program
    {
        static void Main(string[] args)
        {                                    
            try
            {
                Tuple<bool, string, int, int> tuple = Validation.ValidateInputArgs(args);
                bool isValidInput = tuple.Item1;
                if (!isValidInput)
                {
                    string errorMsg = tuple.Item2;
                    Console.WriteLine(errorMsg);
                    return;
                }

                IPackageIdentifier obj = Helpers.GetIdentifier();
                Dictionary<int, string> dicIdentifier = obj.GetPackageIdentifier(tuple.Item3, tuple.Item4);

                Console.WriteLine("Number,  Identifier");
                Console.WriteLine("-------------------------------");
                foreach (var kvp in dicIdentifier)
                {
                    Console.WriteLine("{0},      {1}", kvp.Key, kvp.Value);
                }
            }
            catch (Exception ex)
            {
                //logging exception
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadKey();
        }
    }

    public class Helpers
    {
        public static IPackageIdentifier GetIdentifier()
        {
            IPackageIdentifier obj = null;
            string strategy = ConfigurationManager.AppSettings.Get("IdentifierStrategy");
            if (strategy.Equals("Multiplier"))
            {
                obj = new Multiplier();
            }
            //else if (strategy.Equals("XXXX"))
            //{
            //    obj = new XXXX;
            //}
            return obj;
        }
    }
}
