using System.Text.Json.Serialization;

namespace Demo.OpenAI.Models
{
    public class ResponseChatGPT
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("object")]
        public string ObjectData { get; set; }
        [JsonPropertyName("created")]
        public int Created { get; set; }
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("usage")]
        public Usage Usage { get; set; }
        [JsonPropertyName("choices")]
        public IEnumerable<ChoiceChatGPT> Choices { get; set; }
    }
}
