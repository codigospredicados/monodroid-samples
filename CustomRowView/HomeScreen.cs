using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Webkit;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Org.Json;

namespace CustomRowView {
    [Activity(Label = "CustomRowView", MainLauncher = true, Icon = "@drawable/icon")]
    public class HomeScreen : Activity{//, View.IOnClickListener {

        WebView webView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Test);
            webView = FindViewById<WebView>(Resource.Id.webView1);
            webView.LoadData("<span style=\"font-size: 2px\">1</span>Texto <B>Em bold</B> em normal de novo", null, null);

            string data = get("http://185.11.167.75/se7ening/api.php/testamento/1/livro/1/capitulos");

            var ver = JsonConvert.DeserializeObject<Capitulos>(data);

            data = get("http://185.11.167.75/se7ening/api.php/testamento/1/livro/2/capitulo/3");

            ver = JsonConvert.DeserializeObject<Capitulos>(data);
            
            var a = 1;
        }

        protected string get(string url)
        {
            try
            {
                string rt;

                WebRequest request = WebRequest.Create(url);

                WebResponse response = request.GetResponse();


                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                rt = reader.ReadToEnd();

                Console.WriteLine(rt);

                reader.Close();
                response.Close();

                return rt;
            }

            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }


    }
}