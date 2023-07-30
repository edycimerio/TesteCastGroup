using Microsoft.AspNetCore.Mvc;

using RestSharp;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace Sebrae.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViaCepController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var client = new RestClient("http://viacep.com.br/");
            var request = new RestRequest("ws/01001000/json/");
            var response = client.ExecuteGet(request);

            var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;

            var userList = JsonSerializer.Deserialize<dynamic>(response.Content, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Ok(userList);
        }
    }
}
