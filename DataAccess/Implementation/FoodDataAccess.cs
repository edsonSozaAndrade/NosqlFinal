using DataAccess.Helper;
using DataAccess.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Entities;
using Poco;
using MongoDB.Driver;

namespace DataAccess.Implementation
{
    public class FoodDataAccess : IFoodDataAccess
    {
        private readonly IConfiguration _config;
        private readonly MongoConnecter _connector;
        public FoodDataAccess(IConfiguration config)
        {
            _config = config;
            _connector = new MongoConnecter();
        }

        public async Task<List<Food>> GetAllProducts()
        {
            await _connector.ConnectToDataBase(_config["ConnectionStrings:MongoDB"]);
            return await DB.Queryable<Food>().ToListAsync();
        }

        public async Task<List<Food>> GetByCategory(string category)
        {
            await _connector.ConnectToDataBase(_config["ConnectionStrings:MongoDB"]);
            return await DB.Find<Food>().ManyAsync(a => a.Categoria == category);
        }

        public async Task<Food> InsertNewFood(FoodRequest newFood)
        {
            var result = newFood.ToFoodModel();

            await _connector.ConnectToDataBase(_config["ConnectionStrings:MongoDB"]);
            await result.SaveAsync();

            return result;
        }

        public async Task<List<Food>> SearchByName(string name)
        {
            var result = new List<Food>();
            await _connector.ConnectToDataBase(_config["ConnectionStrings:MongoDB"]);

            await DB.Index<Food>()
                .Key(p => p.Nombre, KeyType.Text)
                .Key(k => k.Descripcion, KeyType.Text)
                .CreateAsync();

            var foodFinded = await DB.Find<Food>()
               .Match(Search.Fuzzy, name)
               .ExecuteAsync();
            var list = foodFinded.SortByRelevance(name, p => p.Nombre);
            foreach (var person in list)
            {
                Console.WriteLine(person.Nombre);
            }
            return foodFinded;
        }
    }
}
