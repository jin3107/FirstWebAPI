using AutoMapper;
using FirstWebAPI.Data;
using FirstWebAPI.Models;

namespace FirstWebAPI.Common
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Products, ProductModel>().ReverseMap();
        }
    }
}
