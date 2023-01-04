using DB_Bridge;
using Microsoft.Data.Analysis;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System;

namespace Answer_package
{
    public class RandomAnswer:IAnswer
    {
        static DB_Communication DB_Communication= new DB_Communication();
        public string answer() 
        {
            Dictionary<int, string> txt = DB_Communication.get_data("SELECT * FROM answer_sets.hianswer");

            var r = new Random();
            var idx = r.Next(0, txt.Count);
            return txt[idx];
        }
    }
}