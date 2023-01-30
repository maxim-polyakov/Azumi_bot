using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Bridge;

namespace Bot_package
{
    public class AToken : IToken
    {
        private static IDB_Communication bridge = new DB_Communication();
        public void add_token(string token)
        {
            throw new NotImplementedException();
        }

        public string get_token(string select)
        {
            return bridge.get_token(select);
        }
    }
}
