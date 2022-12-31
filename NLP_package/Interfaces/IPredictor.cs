using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP_package
{
    public interface IPredictor
    {
        string predict(string chat_text_message, string model_name, Dictionary<bool,string> map);
    }
}
