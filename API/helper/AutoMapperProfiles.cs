using API.Controllers.Entities;
using API.DTOs;
using AutoMapper;

namespace API.helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductsSellOrder, ProductSoldResults>();
        }
    }
}