using DataAccess.Interface;
using Manager.Interface;
using Microsoft.Extensions.Configuration;

namespace Manager.Implementation
{
    public class DocumentManager: IDocumentManager
    {
        private readonly IConfiguration _config;
        private readonly IMongoDocumentClient _client;

        public DocumentManager(IConfiguration config, IMongoDocumentClient client)
        {
            config = _config;
            _client = client;
        }

        public void TestAccess() { 
            _client.Connect();
        }
    }
}
