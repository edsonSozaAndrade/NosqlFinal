using MongoDB.Driver;
using MongoDB.Entities;

namespace DataAccess.Helper
{
    internal class MongoConnecter
    {
        internal async Task ConnectToDataBase(string connectionString)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            await DB.InitAsync("Final_Master", settings);
        }
    }
}
