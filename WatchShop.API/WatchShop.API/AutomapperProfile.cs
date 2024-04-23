using AutoMapper;
using WatchShop.Model;
using WatchShop.Contracts;
using WatchShop.Contracts.Models;

namespace WatchShop.API
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Watch, AddWatchContract>().ReverseMap(); 

            CreateMap<Watch, WatchContract>().ReverseMap();

            CreateMap<Watch, WatchContract>().ReverseMap();
            CreateMap<Brand, BrandContract>().ReverseMap();

            CreateMap<Style, StyleContract>().ReverseMap();

            CreateMap<Color, ColorContract>().ReverseMap();

            CreateMap<Condition, ConditionContract>().ReverseMap();

            CreateMap<Gender, GenderContract>().ReverseMap();

            CreateMap<Cart, CartContract>().ReverseMap();

            CreateMap<User, UserContract>().ReverseMap();

            CreateMap<Purchase, PurchaseContract>().ReverseMap();

            CreateMap<Role, RoleContract>().ReverseMap();

            CreateMap<Privilege, PrivilegeContract>().ReverseMap();

            CreateMap<WishList, WishListContract>().ReverseMap();

        }
    }
}
