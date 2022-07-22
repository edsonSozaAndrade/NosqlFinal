using Poco;

namespace DataAccess.Interface
{
    public interface IFoodDataAccess
    {
        public Task<List<Food>> GetAllProducts();
        public Task<List<Food>> GetByCategory(string category);
        public Task<Food> InsertNewFood(FoodRequest newFood);
        public Task<List<Food>> SearchByName(string name);
    }
}
