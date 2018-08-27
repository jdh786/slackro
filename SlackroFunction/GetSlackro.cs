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
            string commandText = reqContent["text"];
            string responseUrl = reqContent["response_url"];
            string userName = reqContent["user_name"];
            string[] commandPieces = commandText.Split(new char[] { '\"', '\n' }).Where(p => !string.IsNullOrEmpty(p)).ToArray();
            string text = commandPieces.FirstOrDefault().Trim().ToUpper();
            string emoji = commandPieces.LastOrDefault().Trim();
            Task slackro = Slackro.GetSlackro(text, emoji, userName, responseUrl);
            return req.CreateResponse(HttpStatusCode.OK);
        }
    }
}