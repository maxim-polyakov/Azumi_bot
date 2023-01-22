using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_package
{
    public interface ITranslator
    {
        public string translate(string translate);

        public string translate(string dataselect, string insertdtname);
    }
}
