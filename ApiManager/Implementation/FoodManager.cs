using ApiManager.Interface;
using DataAccess.Interface;
using Microsoft.Extensions.Configuration;
using Poco;

namespace ApiManager.Implementation
{
    public class FoodManager : IFoodManager
    {
        private readonly IConfiguration _config;
        private readonly IFoodDataAccess _foodDataAccess;
        public FoodManager(IConfiguration config, IFoodDataAccess foodDataAccess)
        {
            _config = config;
            _foodDataAccess = foodDataAccess;
        }

        public async Task<List<Food>> GetAllProducts()
        {
            return await _foodDataAccess.GetAllProducts();
        }

        public async Task<List<Food>> GetByCategory(string category)
        {
            return await _foodDataAccess.GetByCategory(category);
        }

        public async Task<Food> InsertNewFood(FoodRequest request)
        {
            return await _foodDataAccess.InsertNewFood(request);
        }
    }
}
