using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_package
{
    public abstract class Monitor:IMonitor
    {
        public abstract String monitor(string content);
    }
}
