using NLP_package;
using Answer_package;
using Command_package;
using DB_package;
using System.Collections.Generic;
using System.IO;
using System;
using System.Collections;

namespace Bot_package
{
    public abstract class Monitor : IMonitor
    {
        private static IPredictor predictor = new Predictor();
        private static IDB_Communication bridge = new DB_Communication();
        private static IAnswer ransw = new RandomAnswer();
        private static ListMaps listMaps = new ListMaps();
        protected string content { get; set; }
        private string classify(string chosen_item)
        {
            string outstring = string.Empty;
            Dictionary<string, string> info_dict = new Dictionary<string, string>()
            {
                {"Приветствие", ransw.answer() + ". "},
                {"Благодарность","Не за что."},
                {"Дело","Утверждение про дела. "},
                {"Погода","Утверждение про погоду. "},
                {"Треш", "Просьба, оставить неприличные высказывания при себе. "}
            };
            info_dict.TryGetValue(chosen_item, out outstring);
            return outstring;
        }      

        private List<string> decision(string text_message, ICommandAnalyzer command, string[] predicts)
        {
            List<string> outlist = new List<string>();
            if (bridge.checkcommands(text_message))
            {
                outlist.Add(command.commandanalyse(text_message));
            }
            else if (text_message.Contains('?'))
            {
                IAnswer qansw = new QuestionAnswer(text_message);

                foreach (string predict in predicts)
                {
                    outlist.Add(qansw.answer());
                }
            }
            else
            {
                foreach (string predict in predicts)
                {
                    outlist.Add(classify(predict));
                }
            }
            return outlist;
        }

        protected List<string> neurodesc(string content, ICommandAnalyzer command)
        {            
            string fullPath = Environment.CurrentDirectory + "/Models";
            List<string> messagelist = new List<string>();
            if (System.IO.Directory.Exists(fullPath))
            {
                string[] predicts;
                List<string[]> modelPahths = new List<string[]>();
                int CountFiles = new DirectoryInfo(fullPath).GetFiles().Length;
                string[] models = Directory.GetFiles(fullPath);
                predicts = new string[CountFiles];
                int i = 0;
                List<Dictionary<bool, string>> maplist = listMaps.GetListMaps();
                foreach (string model in models)
                {
                    predicts[i] = predictor.predict(content, model, maplist[i]);
                    i++;
                }
                messagelist = this.decision(content, command, predicts);            
            }
            else
            {
                messagelist.Add("Нет классификации");
            }
            return messagelist;
        }

        public string monitor()
        {
            ICommandAnalyzer command = new CommandAnalyzer(this.content);
            bridge.insert_to(content, "messtorage.storage");
            string outputmessage = string.Empty;

            if ((this.content.ToLower()).Contains("азуми"))
            {
                content = content.Replace("азуми", "");
                
                List<string> messagelist = this.neurodesc(content, command);

                foreach (string mesage in messagelist)
                {
                    outputmessage += mesage;
                }
            }
            return outputmessage;
        }
    }
}
