using NLP_package;

namespace Answer_package {
    public class QuestionAnswer : IAnswer {
        private string text;
        private static IGpt gpt = new Gpt();

        public QuestionAnswer(string text)
        {
            this.text = text;
        }
        
        public string answer()
        {
           return gpt.generate(this.text);
        }
    }
}