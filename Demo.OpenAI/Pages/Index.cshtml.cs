using Demo.OpenAI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.OpenAI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IOpenAIService _openAIService;

        public IndexModel(
            ILogger<IndexModel> logger,
            IOpenAIService openAIService)
        {
            _logger = logger;
            _openAIService = openAIService;
        }
        public string? JobTitle { get; set; }
        public string? JobDetails { get; set; }
        public string? Analyzed { get; set; }
        public string? Rewrote { get; set; }

        public async Task OnGet(string? jobTitle, string? jobDetails)
        {
            if(jobTitle != null && jobDetails != null)
            {
                JobTitle = jobTitle;
                JobDetails = jobDetails;
                var analyzedResult = await _openAIService.GetResponseFromChatGPT(jobTitle, jobDetails, 1);
                var rewroteResult = await _openAIService.GetResponseFromChatGPT(jobTitle, jobDetails, 2);
                if (analyzedResult != null)
                {
                    if (analyzedResult.Choices.Count() > 0)
                    {
                        Analyzed = analyzedResult.Choices.First().Message.Content;
                    }
                }
                if (rewroteResult != null)
                {
                    if (rewroteResult.Choices.Count() > 0)
                    {
                        Rewrote = rewroteResult.Choices.First().Message.Content;
                    }
                }
            }
        }
    }
}