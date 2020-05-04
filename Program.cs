using System.Threading.Tasks;
using Translate;

namespace TranslateTextSample
{

    class Program
    {

        static async Task Main(string[] args)
        {
            string lang = "fr";
            // Prompts you for text to translate. If you'd prefer, you can
            // provide a string as textToTranslate.

            JsonTranslator translator = new JsonTranslator();

            await translator.TranslateFile(lang,
                                     @"C:\VS2019\FAC\Scor.Facultative.Web.Angular\ClientApp\src\assets\i18n\en.json",
                                     $@"C:\VS2019\FAC\Scor.Facultative.Web.Angular\ClientApp\src\assets\i18n\{lang}.json");


        }
    }
}