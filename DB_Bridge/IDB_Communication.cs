using Microsoft.Data.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Bridge
{
    public interface IDB_Communication
    {
        void insert_to(string insert, string tablename);
        DataFrame get_data();
        Dictionary<int, string> get_data(string select);
        bool checkcommands(string input_string);
    }
}
