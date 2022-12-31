using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using NLP_package;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.FileProviders;
using DB_Bridge;

namespace Bot_package
{
    public class MessageMonitor : Monitor
    {

        private static IPredictor predictor = new Predictor();
        private static Maps map = new Maps();
        protected static IDB_Communication bridge = new DB_Communication();

        private string classify(string chosen_item)
        {
            string outstring = string.Empty;

            Dictionary<string, string> info_dict = new Dictionary<string, string>()
            {
                { "Приветствие","Здарова" }
            };
            info_dict.TryGetValue(chosen_item, out outstring);
            return outstring;
        }
        protected List<string> decision(string hipredict, string thpredict, string businesspredict, string weatherpredict,string trashpredict)
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
            List<string[]> modelPahths = new List<string[]>();

            string fullPath = Path.Combine("C:\\Users\\maxim\\Documents", "\\GitHub\\Azumi_bot\\");

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



        public override String monitor(string content)
        {
            return "";
        }
    }
}
