using ApiManager.Interface;
using Microsoft.AspNetCore.Mvc;
using Poco;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Master_FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IFoodManager _foodManager;

        public FoodController(IConfiguration configuration, IFoodManager foodManager)
        {
            _config = configuration;
            _foodManager = foodManager;
        }

        [HttpPost("submit")]
        public async Task<ActionResult<Food>> Submit(FoodRequest request)
        {
            return Ok(await _foodManager.InsertNewFood(request));
        }

        [HttpGet("getall")]
        public async Task<ActionResult<Food>> GetAll()
        {
            return Ok(await _foodManager.GetAllProducts());
        }
        [HttpGet("bycategory/{category}")]
        public async Task<ActionResult<Food>> GetByCategory(string category)
        {
            return Ok(await _foodManager.GetByCategory(category));
        }
    }
}
