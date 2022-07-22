using Poco;

namespace ApiManager.Interface
{
    public interface IPhoneticManager
    {
        Task<List<Food>> SearchByName(string text);
    }
}
