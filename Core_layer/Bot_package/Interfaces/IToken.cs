using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_package
{
    public interface IToken
    {
        void add_token(string token);

        string get_token(string select);
    }
}
