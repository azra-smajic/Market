using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Core.Dtos;
using Market.Entities;

namespace Market.Infrastructure.Mapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<MarketEntity, MarketDto>().ReverseMap();
        }
    }
}