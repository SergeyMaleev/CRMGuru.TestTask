using AutoMapper;
using CRMGuru.TestTask.DAL.Entities;
using CRMGuru.TestTask.Interfaces.Repositories;
using CRMGuru.TestTask.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CRMGuru.TestTask.Interfaces.Models;

namespace CRMGuru.TestTask.Implementations.Services
{
    public class AddCountryService : IAddCountryService
    {
       
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public AddCountryService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }
      
        
        public async Task AddCountryDb(CountryModel item)
        {
            var entity = _mapper.Map<CountryEntity>(item);
            
            try
            {
                var city = await _dbRepository.Get<CityEntity>(entity.Сapital.Name);
                var region = await _dbRepository.Get<RegionEntity>(entity.Region.Name);
                var country = _dbRepository.GetAll<CountryEntity>().Result.FirstOrDefault(x => x.CountryCode == entity.CountryCode);

                if (city is null)
                {
                    city = await _dbRepository.Add<CityEntity>(entity.Сapital);
                }
                if (region is null)
                {
                    region = await _dbRepository.Add<RegionEntity>(entity.Region);
                }

                if (country is null)
                {
                    entity.Сapital = city;
                    entity.Region = region;
                    await _dbRepository.Add<CountryEntity>(entity);
                }
                else
                {
                    country.Сapital = city;
                    country.Region = region;
                    await _dbRepository.Update<CountryEntity>(country);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}
