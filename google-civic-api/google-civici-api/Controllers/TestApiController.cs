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
        // https://developers.google.com/civic-information/docs/v2/elections/electionQuery
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
        // https://developers.google.com/civic-information/docs/v2/elections/voterInfoQuery
        public async Task<VoterInfoResponse> GetVoterInfo()
        {
            var service = new CivicInfoService(new BaseClientService.Initializer
            {
                ApplicationName = System.Configuration.ConfigurationManager.AppSettings["google-civic-api-project-name"],
                ApiKey = System.Configuration.ConfigurationManager.AppSettings["google-civic-api-server-key"]
            });

            var electionId = 2000;
            var testAddress = "1263 Pacific Ave. Kansas City KS";

            // MUST set electionId
            var voterInfoRequest = new ElectionsResource.VoterInfoQueryRequest(service, testAddress) { ElectionId = electionId };
            var result = await voterInfoRequest.ExecuteAsync();

            return result;
        }

        [HttpGet]
        [Route("division")]
        // https://developers.google.com/civic-information/docs/v2/divisions/search
        public async Task<DivisionSearchResponse> GetDivision()
        {
            var service = new CivicInfoService(new BaseClientService.Initializer
            {
                ApplicationName = System.Configuration.ConfigurationManager.AppSettings["google-civic-api-project-name"],
                ApiKey = System.Configuration.ConfigurationManager.AppSettings["google-civic-api-server-key"]
            });

            var divisionSearchRequest = new DivisionsResource.SearchRequest(service) { Query = "" };
            var result = await divisionSearchRequest.ExecuteAsync();

            return result;
        }

        [HttpGet]
        [Route("representative-info-by-address")]
        // https://developers.google.com/civic-information/docs/v2/representatives/representativeInfoByAddress
        public async Task<RepresentativeInfoResponse> GetRepresentativeInfoByAddress()
        {
            var service = new CivicInfoService(new BaseClientService.Initializer
            {
                ApplicationName = System.Configuration.ConfigurationManager.AppSettings["google-civic-api-project-name"],
                ApiKey = System.Configuration.ConfigurationManager.AppSettings["google-civic-api-server-key"]
            });

            var testAddress = "1263 Pacific Ave. Kansas City KS";

            var representativeInfoRequest = new RepresentativesResource.RepresentativeInfoByAddressRequest(service){ Address = testAddress };
            var result = await representativeInfoRequest.ExecuteAsync();

            return result;
        }

        [HttpGet]
        [Route("representative-info-by-division")]
        // https://developers.google.com/civic-information/docs/v2/representatives/representativeInfoByDivision
        public async Task<RepresentativeInfoData> GetRepresentativeInfoByDivision()
        {
            var service = new CivicInfoService(new BaseClientService.Initializer
            {
                ApplicationName = System.Configuration.ConfigurationManager.AppSettings["google-civic-api-project-name"],
                ApiKey = System.Configuration.ConfigurationManager.AppSettings["google-civic-api-server-key"]
            });

            // Find diviision
            // ocd-division/country:us/state:oh/sldl:1
            var division = "ocd-division/country:us/state:oh/sldl:1";

            // Find Representative Info
            var result = await service.Representatives.RepresentativeInfoByDivision(division).ExecuteAsync();

            return result;
        }
    }
}