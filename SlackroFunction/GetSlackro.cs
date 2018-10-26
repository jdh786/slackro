using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using SlackroCore;
using SlackroCore.SlackModels;

namespace SlackroFunction
{
    public static class MacroFunctions
    {
        [FunctionName("GetSlackro")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            NameValueCollection reqContent = req.Content.ReadAsFormDataAsync().Result;
            string token = reqContent["token"].Replace("\r\n","");
            string channel = reqContent["channel_id"].Replace("\r\n", "");
            string responseUrl = reqContent["response_url"].Replace("\r\n", "");
            string userName = reqContent["user_name"].Replace("\r\n", "");
            string commandText = reqContent["text"].Replace("\r\n","");
            
            string[] commandPieces = commandText.Split(new char[] { '\"', ':' })
                .Where(c => !string.IsNullOrEmpty(c))
                .ToArray();

            string emoji = $":{commandPieces.LastOrDefault().Trim()}:";
            string text = commandPieces.FirstOrDefault().Trim().ToUpper();


            Task slackro = Slackro.GetSlackro(text, emoji, new Request()
            {
                channel_id = channel,
                response_url = responseUrl,
                text= commandText,
                token = token,
                user_name = userName
            });
            
            return req.CreateResponse(HttpStatusCode.OK);
        }
    }
}