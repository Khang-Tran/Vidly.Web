using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customers, CustomersDto>();
            Mapper.CreateMap<CustomersDto, Customers>().ForMember(c=>c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MembershipTypes, MembershipTypesDto>();
            Mapper.CreateMap<MembershipTypes, MembershipTypesDto>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movies, MoviesDto>();
            Mapper.CreateMap<MoviesDto, Movies>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Genre, GenresDto>();
            Mapper.CreateMap<GenresDto, Genre>().ForMember(g => g.Id, opt => opt.Ignore());
            Mapper.CreateMap<Rental, NewRentalDto>();
            Mapper.CreateMap<NewRentalDto, Rental>().ForMember(g => g.Id, opt => opt.Ignore());
        }
    }
}