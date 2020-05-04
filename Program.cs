using System.Net;
using System.Threading.Tasks.Dataflow;
using System.Runtime.InteropServices;
using System.Threading;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using QuickType;
using System.Reflection;

namespace TranslateTextSample
{
    /// <summary>
    /// The C# classes that represents the JSON returned by the Translator Text API.
    /// </summary>
    public class TranslationResult
    {
        public DetectedLanguage DetectedLanguage { get; set; }
        public TextResult SourceText { get; set; }
        public Translation[] Translations { get; set; }
    }

    public class DetectedLanguage
    {
        public string Language { get; set; }
        public float Score { get; set; }
    }

    public class TextResult
    {
        public string Text { get; set; }
        public string Script { get; set; }
    }

    public class Translation
    {
        public string Text { get; set; }
        public TextResult Transliteration { get; set; }
        public string To { get; set; }
        public Alignment Alignment { get; set; }
        public SentenceLength SentLen { get; set; }
    }

    public class Alignment
    {
        public string Proj { get; set; }
    }

    public class SentenceLength
    {
        public int[] SrcSentLen { get; set; }
        public int[] TransSentLen { get; set; }
    }

    class Program
    {

        private static readonly string subscriptionKey = "80f79452eb464d6e9fc0f4a5859e5c7b";
        private static readonly string endpoint = "  https://api.cognitive.microsofttranslator.com";

        // Async call to the Translator Text API
        static public async Task<TranslationResult[]> TranslateTextRequest(string subscriptionKey, string endpoint, string route, string inputText)
        {
            object[] body = new object[] { new { Text = inputText } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // Build the request.
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                // Send the request and get response.
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                // Read response as a string.
                string result = await response.Content.ReadAsStringAsync();
                TranslationResult[] deserializedOutput = JsonConvert.DeserializeObject<TranslationResult[]>(result);

                return deserializedOutput;
            }
        }
        static async Task Main(string[] args)
        {
            // This is our main function.
            // Output languages are defined in the route.
            // For a complete list of options, see API reference.
            // https://docs.microsoft.com/azure/cognitive-services/translator/reference/v3-0-translate
            //https://docs.microsoft.com/en-us/azure/cognitive-services/Translator/quickstart-translate?pivots=programming-language-csharp
            //https://docs.microsoft.com/en-us/azure/cognitive-services/translator/translator-text-how-to-signup
            //https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-reference
            //https://portal.azure.com/#@vsimonescor.onmicrosoft.com/resource/subscriptions/4274513d-d20d-43aa-a723-c12ca2557952/resourcegroups/Default-SQL-EastUS/providers/Microsoft.CognitiveServices/accounts/VSTranslator/cskeys
            string lang = "ja";


            // Prompts you for text to translate. If you'd prefer, you can
            // provide a string as textToTranslate.

            //var moo = await TranslateTextRequest(subscriptionKey, endpoint, route, "HELLO WORLD");
            string json = await File.ReadAllTextAsync(@"D:\VS2019\PlayGround\FAC\FAC\Scor.Facultative.Web.Angular\ClientApp\src\assets\i18n\en.json");

            JObject englishFile = JObject.Parse(json);

            // var one = (JObject)englishFile["languageParameters"];
            // var two = (JObject)one["calendar"];
            // //var three = (JObject)two["dayNames"];
            // two["dayNames"] = "[one, two, three]";

            // Console.WriteLine(englishFile.ToString());

            Dictionary<string, string> nodes = new Dictionary<string, string>();
            TranslateJson(englishFile, nodes, lang);

            foreach (var node in nodes)
            {
                var levels = node.Key.Split(".");
                int numOfLevels = levels.Count();
                var currentLevel = (JObject)englishFile[levels[0]];

                for (int x = 1; x < numOfLevels - 1; x++)
                {
                    currentLevel = (JObject)currentLevel[levels[x]];
                }

                if (!node.Value.Contains("|"))
                {
                    currentLevel[levels[levels.Count() - 1]] = node.Value;
                }
                else
                {
                    JArray jr = (JArray)currentLevel[levels[levels.Count() - 1]];
                    jr.Clear();

                    MakeValue(node.Value, jr);
                }

            }

            File.WriteAllText($"{lang}.json", englishFile.ToString());
        }

        static void MakeValue(string value, JArray jr)
        {
            var results = value.Split("|");

            foreach (var item in results)
            {
                jr.Add(item);
            }
        }

        static bool TranslateJson(JToken token, Dictionary<string, string> nodes, string lang, string parentLocation = "")
        {
            string route = $"/translate?api-version=3.0&to={lang}";

            if (token.HasValues)
            {
                foreach (JToken child in token.Children())
                {
                    if (token.Type == JTokenType.Property)
                    {
                        if (parentLocation == "")
                        {
                            parentLocation = ((JProperty)token).Name;
                        }
                        else
                        {
                            parentLocation += "." + ((JProperty)token).Name;
                        }
                    }

                    TranslateJson(child, nodes, lang, parentLocation);
                }

                // we are done parsing and this is a parent node
                return true;
            }
            else
            {
                string translatedValue = TranslateTextRequest(subscriptionKey, endpoint, route, token.ToString()).GetAwaiter().GetResult().First().Translations[0].Text;
                // leaf of the tree
                if (nodes.ContainsKey(parentLocation))
                {
                    // this was an array
                    nodes[parentLocation] += "|" + translatedValue;
                }
                else
                {
                    // this was a single property
                    nodes.Add(parentLocation, translatedValue);

                }

                return false;
            }
        }
    }

}