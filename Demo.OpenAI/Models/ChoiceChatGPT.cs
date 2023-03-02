using System.Text.Json.Serialization;

namespace Demo.OpenAI.Models
{
    public class ChoiceChatGPT
    {
        [JsonPropertyName("message")]
        public MessageChatGPT Message { get; set; }
        [JsonPropertyName("finish_reason")]
        public string FinishReason { get; set; }
        [JsonPropertyName("index")]
        public int Index { get; set; }
    }
}
