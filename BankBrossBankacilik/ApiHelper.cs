using BankBrossBankacilik.Models;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Anonymous.FormsCrossCutting.Helpers
{
    public static class ApiHelper<T>
    {
        private static string baseURL = "https://bankbroscore.azurewebsites.net";
        public static ErrorViewer ErrView = new ErrorViewer(); 
        public static async Task<T> Get(string pathname, string token = "")
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", token);
                var userAgent = "d-fens HttpClient";
                client.DefaultRequestHeaders.Add("User-Agent", userAgent);

                HttpResponseMessage response = await client.GetAsync(pathname);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("json : "+json);
                    JavaScriptSerializer serializer1 = new JavaScriptSerializer();
                    var items = serializer1.Deserialize<T>(json);

                    // now use you have the date on Items !
                    return items;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    JavaScriptSerializer serializer1 = new JavaScriptSerializer();
                    ErrView.ErrMsg = serializer1.Deserialize<string>(json);
                    ErrView.IsViewed = false;
                    // deal with error or here ...
                    return default(T);
                }
            }
        }

        public static async Task<T> Post(object entity, string pathname, string token = "")
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                if(token != "")
                    client.DefaultRequestHeaders.Add("Authorization", token);

                var userAgent = "d-fens HttpClient";
                client.DefaultRequestHeaders.Add("User-Agent", userAgent);

                HttpResponseMessage response = await client.PostAsync(pathname,entity,new JsonMediaTypeFormatter());
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("json : " + json);
                    JavaScriptSerializer serializer1 = new JavaScriptSerializer();
                    var items = serializer1.Deserialize<T>(json);

                    return items;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    JavaScriptSerializer serializer1 = new JavaScriptSerializer();
                    ErrView.ErrMsg = serializer1.Deserialize<string>(json);
                    ErrView.IsViewed = false;
                    // deal with error or here ...
                    return default(T);
                }
            }
        }

        public static async Task<T> Put(object entity, string pathname, string token = "")
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                if (token != "")
                    client.DefaultRequestHeaders.Add("Authorization", token);

                var userAgent = "d-fens HttpClient";
                client.DefaultRequestHeaders.Add("User-Agent", userAgent);

                HttpResponseMessage response = await client.PutAsync(pathname, entity, new JsonMediaTypeFormatter());
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("json : " + json);
                    JavaScriptSerializer serializer1 = new JavaScriptSerializer();
                    var items = serializer1.Deserialize<T>(json);

                    return items;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    JavaScriptSerializer serializer1 = new JavaScriptSerializer();
                    ErrView.ErrMsg = serializer1.Deserialize<string>(json);
                    ErrView.IsViewed = false;
                    // deal with error or here ...
                    return default(T);
                }
            }
        }

        public static async Task<T> Delete(string pathname, string token = "")
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                if (token != "")
                    client.DefaultRequestHeaders.Add("Authorization", token);

                var userAgent = "d-fens HttpClient";
                client.DefaultRequestHeaders.Add("User-Agent", userAgent);

                HttpResponseMessage response = await client.DeleteAsync(pathname);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("json : " + json);
                    JavaScriptSerializer serializer1 = new JavaScriptSerializer();
                    var items = serializer1.Deserialize<T>(json);

                    return items;
                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    JavaScriptSerializer serializer1 = new JavaScriptSerializer();
                    ErrView.ErrMsg = serializer1.Deserialize<string>(json);
                    ErrView.IsViewed = false;
                    // deal with error or here ...
                    return default(T);
                }
            }
        }
    }
}
