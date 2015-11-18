using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Google.Apis.CivicInfo.v2;
using Google.Apis.CivicInfo.v2.Data;
using Google.Apis.Services;

namespace google_civici_api.Controllers
{
    [RoutePrefix("api/test")]
    public class TestApiController : ApiController
    {
        [HttpGet]
        [Route("elections")]
        public async Task<ElectionsQueryResponse> GetElections()
        {
            var service = new CivicInfoService(new BaseClientService.Initializer
            {
                ApplicationName = System.Configuration.ConfigurationManager.AppSettings["google-civic-api-project-name"],
                ApiKey = System.Configuration.ConfigurationManager.AppSettings["google-civic-api-server-key"]
            });

            var elections =  await service.Elections.ElectionQuery().ExecuteAsync();

            return elections;
        }

        [HttpGet]
        [Route("voter-info")]
        public async Task<VoterInfoResponse> GetVoterInfo()
        {
            var service = new CivicInfoService(new BaseClientService.Initializer
            {
                ApplicationName = System.Configuration.ConfigurationManager.AppSettings["google-civic-api-project-name"],
                ApiKey = System.Configuration.ConfigurationManager.AppSettings["google-civic-api-server-key"]
            });

            var electionId = 2000;
            var testAddress = "1263 Pacific Ave. Kansas City KS";

            // Use voter's registered address to get info about specific election
            var voterInfoRequest = new ElectionsResource.VoterInfoQueryRequest(service, testAddress) { ElectionId = electionId };
            var result = await voterInfoRequest.ExecuteAsync();

            return result;
        }

    }
}