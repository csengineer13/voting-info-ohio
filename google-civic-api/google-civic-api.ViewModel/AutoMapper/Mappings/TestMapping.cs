using AutoMapper;
using google_civic_api.Domain.Model.Test;
using google_civic_api.ViewModel.DTO.Test;

namespace google_civic_api.ViewModel.AutoMapper.Mappings
{
    public static class TestMapping
    {
        public static void Map()
        {
            Mapper.CreateMap<Test, TestDTO>()
                .ForMember(dest => dest.Derived, options => options.MapFrom(source => source.Name + source.Id.ToString()));
        }
    }
}