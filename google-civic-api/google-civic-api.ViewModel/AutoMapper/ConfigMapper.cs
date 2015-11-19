using AutoMapper;
using google_civic_api.ViewModel.AutoMapper.Mappings;

namespace google_civic_api.ViewModel.AutoMapper
{
    public static class ConfigMapper
    {
        public static void MapAll()
        {
            TestMapping.Map();
        }
    }
}