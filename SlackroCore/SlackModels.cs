using System.Collections.Generic;

namespace SlackroCore.SlackModels
{
    public class SlackRequest
    {
        public string token { get; set; }
        public string team_id { get; set; }
        public string team_domain { get; set; }
        public string enterprise_id { get; set; }
        public string enterprise_name { get; set; }
        public string channel_id { get; set; }
        public string channel_name { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string command { get; set; }
        public string text { get; set; }
        public string response_url { get; set; }
        public string trigger_id { get; set; }
    }

    public class SlackResponse
    {
        public string text { get; set; }
        public string response_type { get; set; }
        public bool replace_original { get; set; }
        public bool delete_original { get; set; }
        public IEnumerable<Attachment> attachments { get; set; }
        public class Attachment
        {
            public string text { get; set; }
            public IEnumerable<Action> actions { get; set; }
            public class Action
            {
                public string name { get; set; }
                public string text { get; set; }
                public string type { get; set; }
                public string style { get; set; }
                public string value { get; set; }
            }
        }
    }
}
