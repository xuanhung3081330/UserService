using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using RetailerDTO = SmallProject.UserService.Infrastructure.DTOs.Retailer.Retailer;
using RetailerDomain = SmallProject.UserService.Domain.Aggregates.Retailer.Retailer;

namespace SmallProject.UserService.Infrastructure.MappingProfiles
{
    public class RetailerMappingProfile : Profile
    {
        public RetailerMappingProfile()
        {
            // RetailerDTO --> Retailer
            CreateMap<RetailerDTO, RetailerDomain>()
                .ForPath(dest => dest.Address.Ward, option => option.MapFrom(src => src.Ward))
                .ForPath(dest => dest.Address.Street, option => option.MapFrom(src => src.Street))
                .ForPath(dest => dest.Address.HouseNum, option => option.MapFrom(src => src.HouseNum))
                .ForPath(dest => dest.Address.District, option => option.MapFrom(src => src.District))
                .ForPath(dest => dest.Name.FirstName, option => option.MapFrom(src => src.FirstName))
                .ForPath(dest => dest.Name.LastName, option => option.MapFrom(src => src.LastName));
        }
    }
}
