using Demo.OpenAI.Models;
using Demo.OpenAI.Options;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Demo.OpenAI.Services
{
    public interface IOpenAIService
    {
        Task<ResponseOpenAI> GetResponseFromOpenAI(string jobTitle, string jobDetails, int step);
        Task<ResponseChatGPT> GetResponseFromChatGPT(string jobTitle, string jobDetails, int step);
    }

    public class OpenAIService : IOpenAIService
    {
        private readonly RequestOptions _requestOptions;
        public OpenAIService(
            IOptions<RequestOptions> options)
        {
            _requestOptions = options.Value;
        }

        public async Task<ResponseOpenAI> GetResponseFromOpenAI(string jobTitle, string jobDetails, int step)
        {
            var requestBody = new RequestOpenAI();
            string stepStr = _requestOptions.Condition;
            switch (step)
            {
                case 1:
                    stepStr += _requestOptions.AnalyzeText;
                    break;
                case 2:
                    stepStr += _requestOptions.RewriteText;
                    break;
            }
            jobTitle = "Job title: " + jobTitle;
            jobDetails = "Job description: " + jobDetails;
            requestBody.Prompt = stepStr + jobTitle + jobDetails;
            var requestBodyJson = JsonSerializer.Serialize(requestBody);

            using var httpClient = new HttpClient();

            // Create the request message with the HTTP method and the endpoint URL
            var request = new HttpRequestMessage(HttpMethod.Post, _requestOptions.UrlOpenAI);

            // Add headers to the request
            request.Headers.Add("api-key", _requestOptions.ApiKey);

            // Create the request content
            var requestContent = new StringContent(requestBodyJson, Encoding.UTF8, "application/json");

            // Set the request content on the request message
            request.Content = requestContent;

            // Send the request and get the response
            var response = await httpClient.SendAsync(request);

            // Read the response content as a string
            var responseJson = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponseOpenAI>(responseJson);

            return result;
        }

        public async Task<ResponseChatGPT> GetResponseFromChatGPT(string jobTitle, string jobDetails, int step)
        {
            var requestBody = new RequestChatGPT();
            string stepStr = _requestOptions.Condition;
            switch (step)
            {
                case 1:
                    stepStr += _requestOptions.AnalyzeText;
                    break;
                case 2:
                    stepStr += _requestOptions.RewriteText;
                    break;
            }
            jobTitle = "Job title: \n\n" + jobTitle;
            jobDetails = "Job description: " + jobDetails;
            requestBody.Messages = new List<MessageChatGPT> 
            { 
                new MessageChatGPT
                {
                    Role = "user",
                    Content = stepStr + jobTitle + jobDetails
                } 
            };
            var requestBodyJson = JsonSerializer.Serialize(requestBody);

            using var httpClient = new HttpClient();

            // Create the request message with the HTTP method and the endpoint URL
            var request = new HttpRequestMessage(HttpMethod.Post, _requestOptions.UrlChatGPT);

            // Add headers to the request
            request.Headers.Add("Authorization", _requestOptions.Token);

            // Create the request content
            var requestContent = new StringContent(requestBodyJson, Encoding.UTF8, "application/json");

            // Set the request content on the request message
            request.Content = requestContent;

            // Send the request and get the response
            var response = await httpClient.SendAsync(request);

            // Read the response content as a string
            var responseJson = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponseChatGPT>(responseJson);

            return result;
        }
    }
}
