using DB_package;
using NLP_package;

namespace Answer_package
{
    public class QuestionAnswer : IAnswer
    {
        static DB_Communication DB_Communication = new DB_Communication();

        string message;

        public QuestionAnswer(string message)
        {
            this.message = message;
        }

        //
        public string answer()
        {
            Gpt gpt = new Gpt();
            
            var generated_text = gpt.generate(this.message);

            return generated_text;            
        }
    }
}