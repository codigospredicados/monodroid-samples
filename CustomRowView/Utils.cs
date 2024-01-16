
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

public static class Utils
{
    public static Equipe LoadEquipe(string url)
    {

        HttpClient client = new HttpClient();
        Equipe lp = new Equipe();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        try
        {
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string dados = response.Content.ReadAsStringAsync().Result;
                lp = JsonConvert.DeserializeObject<Equipe>(dados);
            }
        }
        catch
        {

        }
        return lp;
    } 
}