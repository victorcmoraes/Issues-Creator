using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IssueCreator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IssueController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();

        [HttpPost]
        public async Task<IActionResult> CreateIssue()
        {
            var byteArray = Encoding.ASCII.GetBytes("email:APIKey");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var json = @"{
                ""fields"": {
                    ""project"": {
                        ""key"": """"
                    },
                    ""summary"": """",
                    ""issuetype"": {
                        ""name"": ""Task""
                    }
                }
            }";

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "URL";
            var response = await client.PostAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();
            return Ok(result);
        }
    }
}