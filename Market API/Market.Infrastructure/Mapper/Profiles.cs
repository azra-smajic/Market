using AutoMapper;
using Market.Core.Dtos;
using Market.Entities;
using Market.Core.Dto;
using Market.Core.Entities.Identity;
using Market.Core.Entities;

namespace Market.Infrastructure.Mapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<MarketEntity, MarketDto>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();

            #region User

            CreateMap<ApplicationUserRole, ApplicationUserRoleDto>()
                .ReverseMap();

            CreateMap<ApplicationUserRole, ApplicationUserRoleDto>()
                .ForMember(x => x.User, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PersonDto, Person>().ReverseMap();
            //ForMember(x => x.ProfilePhotoBytes, opt => opt.MapFrom(x => ImageHelper.FromImageToByte(x.ProfilePhotoBytes)))
            //.ForMember(x => x.ProfilePhotoBytes, opt => opt.MapFrom(x => ImageHelper.FromByteToImage(x.ProfilePhotoBytes)))

            CreateMap<ApplicationUserDto, ApplicationUser>()
                .ForMember(au => au.Roles, auDto => auDto.MapFrom(x => x.UserRoles))
                .ReverseMap();

            #endregion User
        }
    }
}