using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageIdentifier
{
    public class Validation
    {
        /// <summary>
        /// To check input args and return conversion result or error message
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Tuple<bool, string, int, int> ValidateInputArgs(string[] args)
        {
            bool isValidInput = true;
            string errorMsg = string.Empty;
            int s = 1, e = 100;
            
            int len = args.Length;
            if (len > 0)
            {
                if (len == 1)
                {
                    isValidInput = false;
                    errorMsg = "Please provide both a start and end number for the application.";
                }
                else if (len > 2)
                {
                    isValidInput = false;
                    errorMsg = "Please only provide a start and end number for the application.";
                }
                else
                {
                    int a1, a2;
                    bool c1 = int.TryParse(args[0], out a1);
                    bool c2 = int.TryParse(args[1], out a2);
                    if (c1 == false || c2 == false || a1 < 0 || a2 < 0)
                    {
                        isValidInput = false;
                        errorMsg = "Please provide a positive integer for both the start and end numbers for the application.";
                    }
                    else
                    {
                        s = a1;
                        e = a2;
                    }
                }
            }
            var tuple = Tuple.Create<bool, string, int, int>(isValidInput, errorMsg, s, e);
            return tuple;
        }
    }
}
