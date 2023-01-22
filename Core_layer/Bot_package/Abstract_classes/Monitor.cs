using DB_Bridge;
using NLP_package;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Answer_package;

namespace Bot_package
{
    public abstract class Monitor : IMonitor
    {
        private static IPredictor predictor = new Predictor();
        private static Maps map = new Maps();
        private static IDB_Communication bridge = new DB_Communication();
        private static IAnswer answ = new RandomAnswer();
        protected string content { get; set; }

        private string classify(string chosen_item)
        {
            string outstring = string.Empty;

            Dictionary<string, string> info_dict = new Dictionary<string, string>()
            {
                { "Приветствие", answ.answer()}
            };
            info_dict.TryGetValue(chosen_item, out outstring);
            return outstring;
        }

        private List<string> decision(string hipredict, string thpredict, string businesspredict, string weatherpredict, string trashpredict)
        {
            string tmp_classification = classify(hipredict);
            List<string> outlist = new List<string>();
            outlist.Add(tmp_classification);
            outlist.Add(classify(thpredict));
            outlist.Add(classify(businesspredict));
            outlist.Add(classify(trashpredict));
            return outlist;
        }

        protected List<string> neurodesc(string content)
        {
            string fullPath = "C:\\Users\\maxim\\Documents\\GitHub\\Azumi_bot\\";

            List<string[]> modelPahths = new List<string[]>();
            modelPahths.Add(Directory.GetFiles(fullPath, "himodel.zip", SearchOption.AllDirectories));
            modelPahths.Add(Directory.GetFiles(fullPath, "thmodel.zip", SearchOption.AllDirectories));
            modelPahths.Add(Directory.GetFiles(fullPath, "businessmodel.zip", SearchOption.AllDirectories));
            modelPahths.Add(Directory.GetFiles(fullPath, "weathermodel.zip", SearchOption.AllDirectories));
            modelPahths.Add(Directory.GetFiles(fullPath, "trashmodel.zip", SearchOption.AllDirectories));

            string hipredict = predictor.predict(content, modelPahths[0][0], map.himap),
                   thpredict = predictor.predict(content, modelPahths[1][0], map.thmap),
                   businesspredict = predictor.predict(content, modelPahths[2][0], map.businessmap),
                   weatherpredict = predictor.predict(content, modelPahths[3][0], map.businessmap),
                   trashpredict = predictor.predict(content, modelPahths[4][0], map.trashmap);

            List<string> messagelist = this.decision(hipredict, thpredict, businesspredict, weatherpredict, trashpredict);
            return messagelist;
        }

        public string monitor()
        {
            bridge.insert_to(content, "messtorage.storage");

            string outputmessage = string.Empty;

            List<string> messagelist = this.neurodesc(content);

            foreach (string mesage in messagelist)
            {
                outputmessage += mesage;
            }

            return outputmessage;
        }
    }
}
