using Google.Apis.CivicInfo.v2;
using Google.Apis.Services;

namespace google_civic_api.Service.Base
{
    public class GoogleQueryServiceBase
    {
        public CivicInfoService _service;

        public GoogleQueryServiceBase()
        {
            _service = new CivicInfoService(new BaseClientService.Initializer
            {
                ApplicationName = System.Configuration.ConfigurationManager.AppSettings["google-civic-api-project-name"],
                ApiKey = System.Configuration.ConfigurationManager.AppSettings["google-civic-api-server-key"]
            });
        }
    }
}