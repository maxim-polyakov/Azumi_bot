using DB_Bridge;
using NLP_package;
using Answer_package;
using Command_package;

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
                { "Приветствие", answ.answer() + ". "},
                { "Благодарность","Не за что."},
                { "Дело","Утверждение про дела. "},
                {"Погода","Утверждение про погоду. "},
                {"Треш", "Просьба, оставить неприличные высказывания при себе. "}
            };
            info_dict.TryGetValue(chosen_item, out outstring);
            return outstring;
        }

        private string classify_question(string chosen_item)
        {
            string outstring = string.Empty;

            Dictionary<string, string> info_dict = new Dictionary<string, string>()
            {
                {"Дело", "Я в порядке. "},
                {"Погода", "Погода норм. "}
            };
            info_dict.TryGetValue(chosen_item, out outstring);
            return outstring;
        }

        private List<string> decision(string text_message, ICommandAnalyzer command, string hipredict, string thpredict, string businesspredict, string weatherpredict, string trashpredict)
        {
            List<string> outlist = new List<string>();

            outlist.Add(classify(hipredict));
            outlist.Add(classify(thpredict));

            if (bridge.checkcommands(text_message))
            {
                outlist.Add(command.commandanalyse(text_message));
            }
            else if(text_message.Contains('?'))
            {
                outlist.Add(classify_question(businesspredict));
                outlist.Add(classify_question(weatherpredict));
            }
            else
            {
                outlist.Add(classify(businesspredict));
                outlist.Add(classify(weatherpredict));
            }
            outlist.Add(classify(trashpredict));

            return outlist;
        }

        protected List<string> neurodesc(string content, ICommandAnalyzer command)
        {
            string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\GitHub\\Azumi_bot\\";

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

            List<string> messagelist = this.decision(content, command, hipredict, thpredict, businesspredict, weatherpredict, trashpredict);
            return messagelist;
        }

        public string monitor()
        {
            ICommandAnalyzer command = new CommandAnalyzer(this.content);
            bridge.insert_to(content, "messtorage.storage");
            string outputmessage = string.Empty;

            List<string> messagelist = this.neurodesc(content, command);

            foreach (string mesage in messagelist)
            {
                outputmessage += mesage;
            }
            return outputmessage + "|";
        }
    }
}
