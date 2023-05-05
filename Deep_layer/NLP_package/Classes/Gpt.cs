using LostTech.TensorFlow.GPT;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Globalization;

namespace NLP_package
{
    public class Gpt : IGpt
    {
        private string classify_question(string chosen_item)
        {
            string outstring = string.Empty;

            Dictionary<string, string> info_dict = new Dictionary<string, string>()
            {
                {"Дело", "Я в порядке. "},
                {"Погода", "Погода норм. "},
                {"Треш", "Просьба, оставить неприличные высказывания при себе. "}
            };

            info_dict.TryGetValue(chosen_item, out outstring);
            return outstring;
        }

        //
        private static string callOpenAI(int tokens, string input, string engine,
          double temperature, int topP, int frequencyPenalty, int presencePenalty)
        {
            var openAiKey = "API_KEY";
            var apiCall = "https://api.openai.com/v1/engines/" + engine + "/completions";

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), apiCall))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + openAiKey);
                    request.Content = new StringContent("{\n  \"prompt\": \"" + input + "\",\n  \"temperature\": " +
                                                            temperature.ToString(CultureInfo.GetCultureInfo("ru-RU")) +
                                                             ",\n  \"max_tokens\": " + tokens + ",\n  \"top_p\": " + topP +
                                                            ",\n  \"frequency_penalty\": " + frequencyPenalty +
                                                             ",\n  \"presence_penalty\": " + presencePenalty + "\n}");
                        
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = httpClient.SendAsync(request).Result;
                    var json = response.Content.ReadAsStringAsync().Result;

                    dynamic dynObj = JsonConvert.DeserializeObject(json);

                    if (dynObj != null)
                    {
                        return dynObj.choices[0].text.ToString();
                    }
                }
            }            
            return null;
        }

        public string generate(string input)
        {     
            return this.classify_question(input);
        }
    }
}