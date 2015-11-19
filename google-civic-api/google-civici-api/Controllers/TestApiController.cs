using System;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using google_civic_api.Domain.Model.Test;
using google_civic_api.Service.Domain.Query;
using google_civic_api.ViewModel.DTO.Test;
using Google.Apis.CivicInfo.v2.Data;

namespace google_civici_api.Controllers
{
    [RoutePrefix("api/test")]
    public class TestApiController : ApiController
    {
        readonly ElectionQueryService _electionQueryService;
        readonly RepresentativeQueryService _representativeQueryService;
        readonly DivisionQueryService _divisionQueryService;

        public TestApiController()
        {
            _electionQueryService = new ElectionQueryService();
            _representativeQueryService = new RepresentativeQueryService();
            _divisionQueryService = new DivisionQueryService();
        }

        [HttpGet]
        [Route("elections")]
        // https://developers.google.com/civic-information/docs/v2/elections/electionQuery
        public Task<ElectionsQueryResponse> GetElections()
        {
            var aMapperTest = new Test
            {
                Id = Guid.NewGuid(),
                Name = "testy test"
            };

            var mappedTest = Mapper.Map<TestDTO>(aMapperTest);


            return _electionQueryService.GetElections();
        }

        [HttpGet]
        [Route("voter-info")]
        // https://developers.google.com/civic-information/docs/v2/elections/voterInfoQuery
        public async Task<VoterInfoResponse> GetVoterInfo()
        {

            var result = await _electionQueryService.GetVoterInfoByAddress("1968 Indianola Ave, Columbus OH");
            return result;

        }

        [HttpGet]
        [Route("division")]
        // https://developers.google.com/civic-information/docs/v2/divisions/search
        public Task<DivisionSearchResponse> GetDivision()
        {
            return _divisionQueryService.GetDivisions("oh");
        }

        [HttpGet]
        [Route("representative-info-by-address")]
        // https://developers.google.com/civic-information/docs/v2/representatives/representativeInfoByAddress
        public async Task<RepresentativeInfoResponse> GetRepresentativeInfoByAddress()
        {
            var result = await _representativeQueryService.GetInfoByAddress("1968 Indianola Ave, Columbus OH");
            return result;
        }

        [HttpGet]
        [Route("representative-info-by-division")]
        // https://developers.google.com/civic-information/docs/v2/representatives/representativeInfoByDivision
        public Task<RepresentativeInfoData> GetRepresentativeInfoByDivision()
        {
            return _representativeQueryService.GetInfoByDivision("ocd-division/country:us/state:oh/sldl:1");
        }
    }
}