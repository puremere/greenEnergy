using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;

namespace greenEnergy.Classes
{
    public static class methods
    {
        private static string baseServer = System.Configuration.ConfigurationManager.AppSettings["baseurl"];//"https://localhost:44394/api/app";
        public static string RandomString(int number)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, number)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public static async  Task<T2>  PostData<T,T2> (T model, T2 model2,string url, string token) 
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseServer +url);
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
                string content = model != null ? JsonConvert.SerializeObject(model) : "";
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var rsp = await client.PostAsync("", byteContent).ConfigureAwait(false);
                string final =  await rsp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T2>(final);
            }
        }
        public static async Task<string> removenull(string main, string sub)
        {
            //{ "nav":{"sample":null, "title":"titlesrt","color":"colorsrt" , "leading":leadsrt, "trailing":trailsrt},"viewID": "viewMetaIDsrt", "view":childMetaString}
            string srt = main;
            try
            {
                string example = sub;// "bottom2bottomsrt";
                int index = srt.IndexOf(example);

                int firstIndex = -1;
                int more = 0;

                if (srt[index - 1].ToString() == "\"")
                {
                    more = 1;
                }
                for (int i = index; i > 0; i--)
                {
                    string ddd = srt[i].ToString();


                    if (ddd == ",")
                    {
                        firstIndex = i;
                        break;
                    }
                }
                string removesrt = srt.Substring(firstIndex, (index - firstIndex) + example.Length + more);
                srt = srt.Replace(removesrt, "");
            }
            catch (Exception)
            {

                throw;
            }
             // "{'viewID':'ViewIDsrt','top2top':top2topsrt,'bottom2bottom':bottom2bottomsrt,'lead2lead':lead2leadsrt,'trail2trail':trail2trailsrt,'top2bottom':top2bottomsrt,'bottom2top':bottom2topsrt,'trail2lead':trail2leadsrt,'lead2trail':lead2trailsrt,'centerX':centerXsrt,'centerY':centerYsrt}";

            

            return srt;
        }

        public static object InvokeMethodWithParameters(object instance, string methodName, object[] parameters)
        {
            var method = instance.GetType().GetMethod(methodName);
            return method.Invoke(instance, parameters);
        }

    }
}