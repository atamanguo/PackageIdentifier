using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageIdentifier.Common;

namespace PackageIdentifier.BLL
{
    public class Multiplier : IPackageIdentifier
    {
        #region IPackageIdentifier Members

        /// <summary>
        /// To implement package identifier with multiplier strategy
        /// </summary>
        /// <param name="startNumber"></param>
        /// <param name="endNumer"></param>
        /// <returns></returns>
        public Dictionary<int, string> GetPackageIdentifier(int startNumber, int endNumer)
        {
            var identifier = string.Empty;
            var dicIdentifier = new Dictionary<int, string>();
            for (int i = startNumber; i <= endNumer; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    identifier = Constants.returnDelivery;
                }
                else if (i % 3 == 0) 
                {
                    identifier = Constants.idtReturn;
                }
                else if (i % 5 == 0)
                {
                    identifier = Constants.idtDelivery;
                }
                else 
                {
                    identifier = i.ToString();
                }
                dicIdentifier.Add(i, identifier);
            }
            return dicIdentifier;
        }

        #endregion
    }
}
