using Microsoft.AspNetCore.Mvc;
using ServerLogic;
using System.Net;

namespace PresentationProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        [HttpGet("fetchData")]
        public async Task<Response> FetchData(string email)
        {
            return await DataHandler.FetchData(email);
        }

        [HttpPost("insertData")]
        public async Task<HttpStatusCode> InsertUser(User user)
        {
            return await DataHandler.InsertData(user);
        }

    }
}
