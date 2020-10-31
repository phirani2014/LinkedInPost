using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Configuration;
using Newtonsoft.Json;

namespace SharePostsTutorial
{
    class Program
    {
        static void Main(string[] args)
        {

            PutPost();
            Environment.Exit(0);
        }
        public static void PutPost()
        {
            Task<string> task = GetQuote();
            task.Wait();
            var x = task.Result;
            string quote = x;
            string json = @"{
                ""author"": ""urn:li:person:PERSONID"",
                ""lifecycleState"": ""PUBLISHED"",
                ""specificContent"": {
                ""com.linkedin.ugc.ShareContent"": {
                ""shareCommentary"": {
                ""text"": ""POSTDATA""
                  },
                ""shareMediaCategory"": ""NONE""
                }
                },
                ""visibility"": {
                ""com.linkedin.ugc.MemberNetworkVisibility"": ""PUBLIC""
                 }
                }";

            string jsonupdate = json.Replace("POSTDATA", quote);
            string jsonupdate1 = jsonupdate.Replace("PERSONID", Properties.Settings.Default.LinkedinAuthor.ToString());
            task.Dispose();

            Task<string> tasks = PutQuotes(jsonupdate1);
            tasks.Wait();
            var xx = tasks.Result;
            task.Dispose();

        }

        public static string TranslateText(string code, string text)
        {

            string url = String.Format
            ("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
             "en", code.ToString(), Uri.EscapeUriString(text.ToString()));
            HttpClient httpClient = new HttpClient();
            string result = httpClient.GetStringAsync(url).Result;
            var jsonData = new JavaScriptSerializer().Deserialize<List<dynamic>>(result);
            var translationItems = jsonData[0];
            string translation = "";
            foreach (object item in translationItems)
            {

                IEnumerable translationLineObject = item as IEnumerable;
                IEnumerator translationLineString = translationLineObject.GetEnumerator();
                translationLineString.MoveNext();
                translation += string.Format(" {0}", Convert.ToString(translationLineString.Current));
            }


            if (translation.Length > 1) { translation = translation.Substring(1); };
            return translation;
        }

        public class Root
        {
            public string q { get; set; }
            public string a { get; set; }
            public string h { get; set; }
        }

        static async Task<string> PutQuotes(string jsonupdate)
        {
            Newtonsoft.Json.Linq.JObject o1 = JObject.Parse(jsonupdate);
            var contents = o1;

            var jsonContent = JsonConvert.SerializeObject(contents);

            string baseUrl = "https://api.linkedin.com/v2/ugcPosts";

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, baseUrl);

            requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            requestMessage.Headers.Add("Authorization", "Bearer " + Properties.Settings.Default.LinkedinToken.ToString());


            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

            string responseAsString = await responseMessage.Content.ReadAsStringAsync();
            if (responseAsString != null)
            {
                Console.WriteLine(responseAsString);
            }
            return responseAsString;
        }


        static async Task<string> GetQuote()
        {

            GoogleLang g = new GoogleLang();
            string code = g.codelist();
            string ConvertedEndMessage = g.getcode(code);
            string Post = "";
            string baseUrl = "https://zenquotes.io/api/random";
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, baseUrl);
            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);
            var responseAsString = await responseMessage.Content.ReadAsStringAsync();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Root[] quoteResponse = js.Deserialize<Root[]>(responseAsString);
            string quote = quoteResponse[0].q.TrimEnd();
            string author = quoteResponse[0].a;
            string GoogleTranslate = "";
            TimeSpan time = DateTime.Now.TimeOfDay;


            string EndMessage = "";
            if (time > new TimeSpan(00, 00, 01)
             && time < new TimeSpan(12, 00, 00))
            {
                EndMessage = Properties.Settings.Default.Morning.ToString();
                GoogleTranslate = TranslateText(code, EndMessage);

            }
            if (time > new TimeSpan(12, 00, 00)
          && time < new TimeSpan(18, 00, 00))
            {
                EndMessage = Properties.Settings.Default.Noon.ToString();
                GoogleTranslate = TranslateText(code, EndMessage);

            }
            if (time > new TimeSpan(18, 00, 00)
      )
            {
                EndMessage = Properties.Settings.Default.Evening.ToString();
                GoogleTranslate = TranslateText(code, EndMessage);

            }
            if (EndMessage == "")
            {
                EndMessage = "Have a great day all -";
            }
            if (GoogleTranslate != "")
            {

                Post = ("'" + quote + "'" + "\n" + "\n" + author + "\n" + "\n" + "#" + ConvertedEndMessage + " - " + GoogleTranslate + " " + " - (" + EndMessage + ")" + "\n" + "\n" + "#Learn" + ConvertedEndMessage + Properties.Settings.Default.HashTags);

            }
            else Post = ("'" + quote + "'" + "\n" + "\n"  + author + "\n" + "\n" + EndMessage + "\n" + "\n" + Properties.Settings.Default.HashTags);
            return Post;



        }

    }
}
