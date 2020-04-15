using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Append.AntDesign.Services
{
    public class GitHubService
    {
        private HttpClient Client { get; }

        public GitHubService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://raw.githubusercontent.com");
            // GitHub API versioning
            client.DefaultRequestHeaders.Add("Accept",
                "application/vnd.github.v3+json");
            // GitHub requires a user-agent
            client.DefaultRequestHeaders.Add("User-Agent",
                "HttpClientFactory-Sample");

            Client = client;
        }

        public async Task<string> GetSampleAsync(string componentName, string demoName)
        {
            var content = await Client.GetStringAsync($"Append-IT/ant-design-blazor/master/docs/Append.AntDesign.Documentation/Components/{componentName}/Demo/{demoName}.razor");

            int indexOfDemoBegin = content.IndexOf("<Demo>")+6;
            int indexOfDemoEnd = content.IndexOf("</Demo>");
            var test =  content.Substring(indexOfDemoBegin);

            test = test.Replace("</Codebox>", "");
            test = test.Replace("</Demo>", "");
            return test;
        }
    }
}
