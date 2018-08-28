using SlackroCore.SlackModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SlackroCore
{
    public static class Slackro
    {
        public static async Task GetSlackro(string text, string emoji, string userName, string responseUrl)
        {
            IProfanityRepository profanityRepository = new ProfanityRepository();
            bool hasProfanity = false;
            try
            {
                hasProfanity = await profanityRepository.HasProfanity(text);
            }
            catch (Exception)
            {
                SendResponse(responseUrl, new SlackResponse() { response_type = "ephemeral", text = "Unable to check provided input for safeness"});
            }

            if (hasProfanity)
            {
                SendResponse(responseUrl, new SlackResponse() { response_type = "ephemeral", text = ConfigurationManager.AppSettings["profanityText"] });
            }
            else
            {                
                string macro = CharacterDefinition.Macrofy(text, emoji);
                SendResponse(responseUrl, new SlackResponse() { response_type = "in_channel", text = macro, attachments = new SlackResponse.Attachment[] { new SlackResponse.Attachment() { text = "Requested by " + userName } } });
            }
        }

        private static void SendResponse(string url, object content)
        {
            HttpClient httpClient = new HttpClient();
            HttpContent bodyContent = new StringContent(JsonConvert.SerializeObject(content));
            httpClient.PostAsync(url, bodyContent);
        }
    }
}
