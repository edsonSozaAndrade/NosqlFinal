using Poco;

namespace ApiManager.Interface
{
    public interface IFoodManager
    {
        Task<Food> InsertNewFood(FoodRequest request);
        Task<List<Food>> GetAllProducts();
        Task<List<Food>> GetByCategory(string category);
    }
}
