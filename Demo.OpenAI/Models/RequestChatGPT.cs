using System.Text.Json.Serialization;

namespace Demo.OpenAI.Models
{
    public class RequestChatGPT
    {
        [JsonPropertyName("model")]
        public string Model => "gpt-3.5-turbo";
        [JsonPropertyName("messages")]
        public IEnumerable<MessageChatGPT> Messages { get; set; }
    }
}
