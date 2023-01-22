using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_package.Finders
{
    public interface IFinder
    {
        public string find(string message);
    }
}
