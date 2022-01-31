using AutoMapper;
using webapiApiService.Dtos;
using webapiApiService.Models;

namespace webapiApiService.Profiles
{
    public class webapiApisProfile : Profile
    {
        public webapiApisProfile()
        {
            //Sources -> Target
            CreateMap<webapiApi, webapiApiReadDto>();
            CreateMap<webapiApiCreateDto, webapiApi>();
        }
    }
}