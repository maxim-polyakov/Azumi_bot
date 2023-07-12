using System.Collections.Generic;

namespace NLP_package
{
    public interface IPredictor {
        string predict(string chat_text_message, string model_name, Dictionary<bool, string> map);
    }
}
