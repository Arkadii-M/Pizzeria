using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserStatus, UserStatusDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusDTO>().ReverseMap();
            CreateMap<Menu, MenuDTO>().ReverseMap();
            CreateMap<ItemType, ItemTypeDTO>().ReverseMap();
            CreateMap<CustomProduct, CustomProductDTO>().ReverseMap();
            CreateMap<CustomizedMenuProduct, CustomizedMenuProductDTO>().ReverseMap();

        }
    }
}
