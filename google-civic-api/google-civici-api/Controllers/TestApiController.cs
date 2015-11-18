using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Google.Apis.CivicInfo.v2;
using Google.Apis.CivicInfo.v2.Data;
using Google.Apis.Services;

namespace google_civici_api.Controllers
{
    public class TestApiController : ApiController
    {
        [HttpGet]
        public async Task<ElectionsQueryResponse> Get()
        {
            var service = new CivicInfoService(new BaseClientService.Initializer
            {
                ApplicationName = System.Configuration.ConfigurationManager.AppSettings["google-civic-api-project-name"],
                ApiKey = System.Configuration.ConfigurationManager.AppSettings["google-civic-api-server-key"]
            });

            // Get List of valid election IDs
            var elections =  await service.Elections.ElectionQuery().ExecuteAsync();

            var electionId = 2000;
            var testAddress = "1263 Pacific Ave. Kansas City KS";

            // Use voter's registered address to get info about specific election
            //var voterInfoReq = service.Elections.VoterInfoQuery(testAddress);
            //var voterInfo = await voterInfoReq.ExecuteAsync();

            return elections;

        }

    }
}
