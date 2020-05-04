using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Translate.TranslateApi;

namespace Translate
{
    public class JsonTranslator
    {
        private BingTranslate _translator;
        public JsonTranslator()
        {
            _translator = new BingTranslate();
        }

        public async Task TranslateFile(string language, string sourceFile, string destFile)
        {
            string json = await File.ReadAllTextAsync(sourceFile);

            JObject englishFile = JObject.Parse(json);

            Dictionary<string, string> nodes = new Dictionary<string, string>();
            TranslateJson(englishFile, nodes, language);

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

            File.WriteAllText(destFile, englishFile.ToString());
        }

        private void MakeValue(string value, JArray jr)
        {
            var results = value.Split("|");

            foreach (var item in results)
            {
                jr.Add(item);
            }
        }

        private bool TranslateJson(JToken token, Dictionary<string, string> nodes, string lang, string parentLocation = "")
        {


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
                string translatedValue = _translator.TranslateText(lang, token.ToString()).GetAwaiter().GetResult().First().Translations[0].Text;
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
