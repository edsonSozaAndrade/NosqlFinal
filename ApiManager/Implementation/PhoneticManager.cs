using ApiManager.Interface;
using DataAccess.Interface;
using Microsoft.Extensions.Configuration;
using Poco;

namespace ApiManager.Implementation
{
    public class PhoneticManager : IPhoneticManager
    {
        private readonly IConfiguration _config;
        private readonly IFoodDataAccess _foodDataAccess;
        public PhoneticManager(IConfiguration config, IFoodDataAccess foodDataAccess)
        {
            _config = config;
            _foodDataAccess = foodDataAccess;
        }
        public async Task<List<Food>> SearchByName(string text)
        {
            return await _foodDataAccess.SearchByName(text);
        }
    }
}
