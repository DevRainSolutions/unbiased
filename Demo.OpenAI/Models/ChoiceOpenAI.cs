﻿using System.Text.Json.Serialization;

namespace Demo.OpenAI.Models
{
    public class ChoiceOpenAI
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("index")]
        public int Index { get; set; }
        [JsonPropertyName("finish_reason")]
        public string FinishReason { get; set; }
        [JsonPropertyName("logprobs")]
        public string? Logprobs { get; set; }
    }
}
