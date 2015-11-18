using System.Threading.Tasks;
using google_civic_api.Service.Base;
using Google.Apis.CivicInfo.v2;
using Google.Apis.CivicInfo.v2.Data;

namespace google_civic_api.Service.Domain.Query
{
    public class ElectionQueryService: GoogleQueryServiceBase
    {
        public async Task<ElectionsQueryResponse> GetElections()
        {
            return await _service.Elections.ElectionQuery().ExecuteAsync();
        }

        public async Task<VoterInfoResponse> GetVoterInfoByAddress(string address, int electionId = 2000)
        {
            var voterInfoRequest = new ElectionsResource.VoterInfoQueryRequest(_service, address) { ElectionId = electionId };
            return await voterInfoRequest.ExecuteAsync();
        }
    }
}