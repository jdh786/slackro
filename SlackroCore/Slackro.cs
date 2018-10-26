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
        public static async Task GetSlackro(string text, string emoji, Request request)
        {
            if (ConfigurationManager.AppSettings["forbiddenEmoji"]?.Split(',')?.Contains(emoji) ?? false)
            {
                SendResponse(request.response_url, new Response() { response_type = "ephemeral", text = ConfigurationManager.AppSettings["forbiddenEmojiResponse"]});
            }
            else if (!IsAscii(text))
            {
                SendResponse(request.response_url, new Response() { response_type = "ephemeral", text = ConfigurationManager.AppSettings["nonAsciiResponse"] });
            }
            else
            {
                IProfanityRepository profanityRepository = new ProfanityRepository();
                bool hasProfanity = false;
                try
                {
                    hasProfanity = await profanityRepository.HasProfanity(text);                
                    if (hasProfanity)
                    {
                        SendResponse(request.response_url, new Response() { response_type = "ephemeral", text = ConfigurationManager.AppSettings["profanityText"] });
                    }
                    else
                    {
                        string macro = CharacterDefinition.Macrofy(text, emoji);
                        Response response = new Response()
                        {
                            response_type = "in_channel",
                            text = macro,
                            attachments = new Attachment[]
                                        { new Attachment()
                                            { text = "Requested by " + request.user_name}
                                        }
                        };
                        //SendResponse(request.response_url, response);

                        ChatPostMessageResponse chatMessageResponse = new ChatPostMessageResponse()
                        {
                            as_user = true,
                            channel = request.channel_id,
                            text = macro,
                            token = ConfigurationManager.AppSettings["slackOAuthToken"]
                        };

                        SendResponse(ConfigurationManager.AppSettings["slackChatPostMessageEndpoint"], chatMessageResponse);                                
                    }
                }
                catch (Exception)
                {
                    SendResponse(request.response_url, new Response() { response_type = "ephemeral", text = "Unable to check provided input for safeness" });
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
            HttpResponseMessage response = httpClient.PostAsync(url, bodyContent).Result;

            if (!response.IsSuccessStatusCode)
            {
                var a = 0;
            }
        }

    }
}
