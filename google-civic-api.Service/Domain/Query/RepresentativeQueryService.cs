using System.Threading.Tasks;
using google_civic_api.Service.Base;
using Google.Apis.CivicInfo.v2;
using Google.Apis.CivicInfo.v2.Data;

namespace google_civic_api.Service.Domain.Query
{
    public class RepresentativeQueryService: GoogleQueryServiceBase
    {
        public async Task<RepresentativeInfoData> GetInfoByDivision(string division)
        {
            // ex: "ocd-division/country:us/state:oh/sldl:1"
            return await _service.Representatives.RepresentativeInfoByDivision(division).ExecuteAsync();
        }

        public async Task<RepresentativeInfoResponse> GetInfoByAddress(string address)
        {
            var representativeInfoRequest = new RepresentativesResource.RepresentativeInfoByAddressRequest(_service) { Address = address };
            return await representativeInfoRequest.ExecuteAsync();
        }
    }
}