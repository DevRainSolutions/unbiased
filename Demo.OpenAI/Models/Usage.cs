using System.Text.Json.Serialization;

namespace Demo.OpenAI.Models
{
    public class Usage
    {
        [JsonPropertyName("completion_tokens")]
        public int CompletitionTokens { get; set; }
        [JsonPropertyName("prompt_tokens")]
        public int PromptTokens { get; set; }
        [JsonPropertyName("total_tokens")]
        public int TotalTokens { get; set; }
    }
}
