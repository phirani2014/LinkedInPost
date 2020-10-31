using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePostsTutorial
{
    class GoogleLang
    {
        public string codelist()
        {
            var Code = new List<string>();
            Code.Add("af");
            Code.Add("ga");
            Code.Add("sq");
            Code.Add("it");

            Code.Add("ja");

            Code.Add("kn");
            Code.Add("eu");
            Code.Add("ko");
            Code.Add("bn");
            Code.Add("la");
            Code.Add("be");
            Code.Add("lv");
            Code.Add("bg");
            Code.Add("lt");
            Code.Add("ca");
            Code.Add("mk");
            Code.Add("zh-CN");
            Code.Add("ms");
            Code.Add("zh-TW");
            Code.Add("mt");
            Code.Add("hr");
            Code.Add("no");
            Code.Add("cs");
            Code.Add("fa");
            Code.Add("da");
            Code.Add("pl");
            Code.Add("nl");
            Code.Add("pt");
            
            Code.Add("ro");
            Code.Add("eo");
            Code.Add("ru");
            Code.Add("et");
            Code.Add("sr");
            Code.Add("tl");
            Code.Add("sk");
            Code.Add("fi");
            Code.Add("sl");
            Code.Add("fr");
            Code.Add("es");
            Code.Add("gl");
            Code.Add("sw");
            Code.Add("ka");
            Code.Add("sv");
            Code.Add("de");
            Code.Add("ta");
            Code.Add("el");
            Code.Add("te");
            Code.Add("gu");
            Code.Add("th");
            Code.Add("ht");
            Code.Add("tr");
            Code.Add("iw");
            Code.Add("uk");
            Code.Add("hi");

            Code.Add("hu");
            Code.Add("vi");
            Code.Add("is");
            Code.Add("cy");
            Code.Add("id");
            Code.Add("yi");

            Random rand = new Random();
            int index = rand.Next(Code.Count);
            string c = (Code[index]);
            return c;
        }
        public string getcode(string code)
        {

            Dictionary<string, string> Languages = new Dictionary<string, string>();
            Languages.Add("af", "Afrikaans");
            Languages.Add("ga", "Irish");
            Languages.Add("sq", "Albanian");
            Languages.Add("it", "Italian");

            Languages.Add("ja", "Japanese");

            Languages.Add("kn", "Kannada");
            Languages.Add("eu", "Basque");
            Languages.Add("ko", "Korean");
            Languages.Add("bn", "Bengali");
            Languages.Add("la", "Latin");
            Languages.Add("be", "Belarusian");
            Languages.Add("lv", "Latvian");
            Languages.Add("bg", "Bulgarian");
            Languages.Add("lt", "Lithuanian");
            Languages.Add("ca", "Catalan");
            Languages.Add("mk", "Macedonian");
            Languages.Add("zh-CN", "ChineseSimplified");
            Languages.Add("ms", "Malay");
            Languages.Add("zh-TW", "ChineseTraditional");
            Languages.Add("mt", "Maltese");
            Languages.Add("hr", "Croatian");
            Languages.Add("no", "Norwegian");
            Languages.Add("cs", "Czech");
            Languages.Add("fa", "Persian");
            Languages.Add("da", "Danish");
            Languages.Add("pl", "Polish");
            Languages.Add("nl", "Dutch");
            Languages.Add("pt", "Portuguese");
            
            Languages.Add("ro", "Romanian");
            Languages.Add("eo", "Esperanto");
            Languages.Add("ru", "Russian");
            Languages.Add("et", "Estonian");
            Languages.Add("sr", "Serbian");
            Languages.Add("tl", "Filipino");
            Languages.Add("sk", "Slovak");
            Languages.Add("fi", "Finnish");
            Languages.Add("sl", "Slovenian");
            Languages.Add("fr", "French");
            Languages.Add("es", "Spanish");
            Languages.Add("gl", "Galician");
            Languages.Add("sw", "Swahili");
            Languages.Add("ka", "Georgian");
            Languages.Add("sv", "Swedish");
            Languages.Add("de", "German");
            Languages.Add("ta", "Tamil");
            Languages.Add("el", "Greek");
            Languages.Add("te", "Telugu");
            Languages.Add("gu", "Gujarati");
            Languages.Add("th", "Thai");
            Languages.Add("ht", "HaitianCreole");
            Languages.Add("tr", "Turkish");
            Languages.Add("iw", "Hebrew");
            Languages.Add("uk", "Ukrainian");
            Languages.Add("hi", "Hindi");

            Languages.Add("hu", "Hungarian");
            Languages.Add("vi", "Vietnamese");
            Languages.Add("is", "Icelandic");
            Languages.Add("cy", "Welsh");
            Languages.Add("id", "Indonesian");
            Languages.Add("yi", "Yiddish");


            string xmlfile = Languages[code.ToString()];
            code = xmlfile;
            return code;
        }
    }
}
