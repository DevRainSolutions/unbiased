using System.Text.Json.Serialization;

namespace Demo.OpenAI.Models
{
    public class RequestOpenAI
    {
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }
        [JsonPropertyName("max_tokens")]
        public int MaxTokens => 2048;
        [JsonPropertyName("temperature")]
        public int Temperature => 1;
        [JsonPropertyName("frequency_penalty")]
        public int FrequencyPenalty => 0;
        [JsonPropertyName("presence_penalty")]
        public int PresencePenalty => 0;
        [JsonPropertyName("top_p")]
        public double TopP => 0.5;
        [JsonPropertyName("best_of")]
        public int BestOf => 1;
        [JsonPropertyName("stop")]
        public string? Stop => null;
    }
}
