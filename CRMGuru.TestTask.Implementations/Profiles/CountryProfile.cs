using AutoMapper;
using CRMGuru.TestTask.DAL.Entities;
using CRMGuru.TestTask.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMGuru.TestTask.Implementations.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryEntity, CountryModel>()
                .ForMember(x => x.Сapital, d => d.MapFrom(s => new CityModel { Id = s.Сapital.Id, Name = s.Сapital.Name }))
                .ForMember(x => x.Region, d => d.MapFrom(s => new RegionModel { Id = s.Region.Id, Name = s.Region.Name }));

            CreateMap<CountryModel, CountryEntity>()
                .ForMember(x => x.Сapital, d => d.MapFrom(s => new CityEntity { Id = s.Сapital.Id, Name = s.Сapital.Name }))
                .ForMember(x => x.Region, d => d.MapFrom(s => new RegionEntity { Id = s.Region.Id, Name = s.Region.Name }));

            CreateMap<RestcountriesModel, CountryModel>()           
            .ForMember(x => x.CountryCode, d => d.MapFrom(s => s.Alpha3Code))           
            .ForPath(x => x.Сapital.Name, d => d.MapFrom(s => s.Capital))
            .ForPath(x => x.Region.Name, d => d.MapFrom(s => s.Region));
        }
        
    }
}
