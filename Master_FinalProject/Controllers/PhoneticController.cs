using ApiManager.Interface;
using Microsoft.AspNetCore.Mvc;
using Poco;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Master_FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneticController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IPhoneticManager _phoneticManager;
        public PhoneticController(IConfiguration configuration,IPhoneticManager phoneticManager)
        {
            _config = configuration;
            _phoneticManager = phoneticManager;
        }
        
        // GET api/<PhoneticController>/5
        [HttpGet("{word}")]
        public async Task<ActionResult<List<Food>>> GetByName(string word)
        {
            return Ok(await _phoneticManager.SearchByName(word));
        }
    }
}
