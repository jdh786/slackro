using Newtonsoft.Json;
using SlackroCore.SlackModels;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SlackroCore
{
    public static class Slackro
    {
        public static async Task GetSlackro(string text, string emoji, string userName, string responseUrl)
        {
            if (ConfigurationManager.AppSettings["forbiddenEmoji"].Split(',').Contains(emoji))
            {
                SendResponse(responseUrl, new SlackResponse() { response_type = "ephemeral", text = ConfigurationManager.AppSettings["forbiddenEmojiResponse"]});
            }
            else if (!IsAscii(text))
            {
                SendResponse(responseUrl, new SlackResponse() { response_type = "ephemeral", text = ConfigurationManager.AppSettings["nonAsciiResponse"] });
            }
            else
            {
                IProfanityRepository profanityRepository = new ProfanityRepository();
                bool hasProfanity = false;
                try
                {
                    hasProfanity = await profanityRepository.HasProfanity(text);
                }
                catch (Exception)
                {
                    SendResponse(responseUrl, new SlackResponse() { response_type = "ephemeral", text = "Unable to check provided input for safeness" });
                }

                if (hasProfanity)
                {
                    SendResponse(responseUrl, new SlackResponse() { response_type = "ephemeral", text = ConfigurationManager.AppSettings["profanityText"] });
                }
                else
                {
                    string macro = CharacterDefinition.Macrofy(text, emoji);
                    SendResponse(responseUrl, new SlackResponse() { response_type = "in_channel", text = macro, attachments = new SlackResponse.Attachment[] { new SlackResponse.Attachment() { text = $"\"{text}\" Requested by {userName}" } } });
                }
            }
        }

        private static bool IsAscii(string text)
        {
            return Encoding.UTF8.GetByteCount(text) == text.Length;
        }

        private static void SendResponse(string url, object content)
        {
            HttpClient httpClient = new HttpClient();
            HttpContent bodyContent = new StringContent(JsonConvert.SerializeObject(content));
            httpClient.PostAsync(url, bodyContent);
        }

    }
}
