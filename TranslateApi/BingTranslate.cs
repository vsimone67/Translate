using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TranslateTextSample;

namespace Translate.TranslateApi
{

    // Output languages are defined in the route.
    // For a complete list of options, see API reference.
    // https://docs.microsoft.com/azure/cognitive-services/translator/reference/v3-0-translate
    //https://docs.microsoft.com/en-us/azure/cognitive-services/Translator/quickstart-translate?pivots=programming-language-csharp
    //https://docs.microsoft.com/en-us/azure/cognitive-services/translator/translator-text-how-to-signup
    //https://docs.microsoft.com/en-us/azure/cognitive-services/translator/reference/v3-0-reference
    //https://portal.azure.com/#@vsimonescor.onmicrosoft.com/resource/subscriptions/4274513d-d20d-43aa-a723-c12ca2557952/resourcegroups/Default-SQL-EastUS/providers/Microsoft.CognitiveServices/accounts/VSTranslator/cskeys

    public class BingTranslate
    {
        private readonly string subscriptionKey = "80f79452eb464d6e9fc0f4a5859e5c7b";
        private readonly string endpoint = "  https://api.cognitive.microsofttranslator.com";

        public async Task<TranslationResult[]> TranslateText(string language, string inputText)
        {
            string route = $"/translate?api-version=3.0&to={language}";
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


    }
}
