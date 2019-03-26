using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //TO DTO
            CreateMap<Customers, CustomerDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MembershipType, MembershiptypeDto>();
            CreateMap<Genre, GenreDto>();
            

            //TO DOMAIN
            
            CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<CustomerDto, Customers>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}