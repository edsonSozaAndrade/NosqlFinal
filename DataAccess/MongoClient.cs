using DataAccess.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using MongoDB.Entities;
using Poco;
using DataAccess.Helper;

namespace DataAccess
{
    public class MongoClient 
    {
        private readonly IConfiguration _config;
        private readonly MongoConnecter _connector;
        public MongoClient(IConfiguration config)
        {
            _config = config;
            _connector = new MongoConnecter();
        }

        public async Task<List<Food>> PhoneticSearchByItem(string itemName)
        {
            var result = new List<Food>();
            await _connector.ConnectToDataBase(_config["ConnectionStrings:MongoDB"]);
            //var newFood = new Food() { 
            //    Categoria = "Pollo",
            //    Descripcion = "Pollo frito con papas y soda",
            //    Imagen = "imagenes/pollo",
            //    Nombre = "Combo trio",
            //    Precio = new Precio() { 
            //        Base = 27,
            //        Moneda = "Bs"
            //    }
            //};
            //await newFood.SaveAsync<Food>();
            //return null;
            await DB.Index<Food>()
                .Key(p => p.Nombre, KeyType.Text)
                .Key(k => k.Descripcion, KeyType.Text)
                .CreateAsync();
            //var allFood = (from a in DB.Queryable<Food>()
            //              select a).ToList();
            //var queri1 = await DB.Find<Food>()
            //            .Match(Search.Full, "Stacker")
            //            .ExecuteAsync();
            var foodFinded = await DB.Find<Food>()
               .Match(Search.Fuzzy, itemName)
               .ExecuteAsync();
            var list = foodFinded.SortByRelevance(itemName, p => p.Nombre);
            foreach (var person in list)
            {
                Console.WriteLine(person.Nombre);
            }
            return foodFinded;
        }
    }
}
