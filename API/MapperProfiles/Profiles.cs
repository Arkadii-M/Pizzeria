using API.Models;
using AutoMapper;
using DAL;
using DTO;

namespace API.MapperProfiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<ItemTypeDTO, TypeModel>()
                .ForMember(d =>  d.Id,opt => opt.MapFrom(s => s.ItemTypeId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.ItemTypeName));
            CreateMap<MenuDTO,ProductModel>()
                .ForMember(d => d.Id,opt => opt.MapFrom(s => s.ItemTypeId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.ItemName))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.ProductType, opt => opt.MapFrom(s => s.ItemType.ItemTypeName));


        }
    }
}
