using Android.App;
using Android.OS;
using Android.Webkit;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using static Android.Media.Session.MediaSession;

namespace MyBible
{
    [Activity(Label = "MyBible", MainLauncher = true, Icon = "@drawable/icon")]
    public class HomeScreen : Activity
    {//, View.IOnClickListener {

        WebView webView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Test);
            webView = FindViewById<WebView>(Resource.Id.webView1);
            webView.LoadData("<span style=\"font-size: 2px\">1</span>Texto <B>Em bold</B> em normal de novo", null, null);

            MyBible.HttpRequest http = new HttpRequest()
            {
                Url = "http://185.11.167.75/se7ening/api.php/testamento/1/livro/1/capitulo/1/versiculos",
                Username = "david",
                Password = "buendia27",
                RequestServer = "http://127.0.0.1",
                TimeRequest = new System.DateTime(2024, 01, 17, 16, 33, 30)
            };

            var token = http.GetToken();

            string data = get("http://185.11.167.75/se7ening/api.php/testamento/1/livro/1/capitulos", token);

            var ver = JsonConvert.DeserializeObject<Capitulos>(data);

            data = get("http://185.11.167.75/se7ening/api.php/testamento/1/livro/2/capitulo/3", token);

            ver = JsonConvert.DeserializeObject<Capitulos>(data);

            var a = 1;
        }

        protected string get(string url, string token)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch
            {

            }
            return null;
        }


    }
}