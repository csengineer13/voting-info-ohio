using System.Threading.Tasks;
using google_civic_api.Service.Base;
using Google.Apis.CivicInfo.v2;
using Google.Apis.CivicInfo.v2.Data;

namespace google_civic_api.Service.Domain.Query
{
    public class DivisionQueryService: GoogleQueryServiceBase
    {
        public async Task<DivisionSearchResponse> GetDivisions(string query = "")
        {
            var divisionSearchRequest = new DivisionsResource.SearchRequest(_service) { Query = query };
            return await divisionSearchRequest.ExecuteAsync();
        }
    }
}