OpenAI_API

namespace Answer_package
{
    public class QuestionAnswer:IAnswer
    {
        public string answer()
        {
            var api = new OpenAI_API.OpenAIAPI("YOUR_API_KEY");
            var result = await api.Completions.GetCompletion("One Two Three One Two");
            //Console.WriteLine(result);
        }
    }
}