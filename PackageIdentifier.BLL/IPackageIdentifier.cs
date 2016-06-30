using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageIdentifier.BLL
{
    public interface IPackageIdentifier
    {
        Dictionary<int, string> GetPackageIdentifier(int startNumber, int endNumer);

    }
    
}
