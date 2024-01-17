using Android.Graphics.Text;
using System;


namespace MyBible
{
    public class HttpRequest
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RequestServer { get; set; }
        public DateTime TimeRequest { get; set; }

        public HttpRequest()
        {

        }

        public string GetToken()
        {
            return Cypher.Base64Encode(string.Format("{0}-{1}-{2}-{3}-{4}",
                this.Url,
                this.Username,
                Cypher.GetMd5Hash(string.Format("{0}:{1}", this.Username, this.Password)),
                this.RequestServer, 
                this.TimeRequest.ToString("s")));
        }
    }
}