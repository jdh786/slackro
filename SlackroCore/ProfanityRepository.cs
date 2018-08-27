using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace SlackroCore
{
    public class ProfanityRepository : IProfanityRepository
    {

        private HttpClient httpClient;
        private string serviceUrl;
        public ProfanityRepository()
        {
            serviceUrl = ConfigurationManager.AppSettings["purgoMalumUrl"];
            httpClient = new HttpClient();
        }
        public Task<string> FilterProfanity(string text)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> HasProfanity(string text)
        {
            bool result = true;
            HttpResponseMessage resp;
            resp = await httpClient.GetAsync(serviceUrl + "/containsprofanity?text=" + text);
            if (resp.IsSuccessStatusCode)
            {
                Boolean.TryParse(resp.Content.ReadAsStringAsync().Result, out result);
            }
            return result;
        }
    }
}
