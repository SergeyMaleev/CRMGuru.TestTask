using CRMGuru.TestTask.DAL.Entities;
using CRMGuru.TestTask.Interfaces.Repositories;
using CRMGuru.TestTask.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using CRMGuru.TestTask.Interfaces.Models;

namespace CRMGuru.TestTask.Implementations.Services
{

    public class LoadContryService : ILoadContryService
    {      
        private readonly IWebRepository _webRepository;
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public LoadContryService(IWebRepository webRepository, IDbRepository dbRepository, IMapper mapper)
        {
            _webRepository = webRepository;
            _dbRepository = dbRepository;
            _mapper = mapper;
        }
     
        public async Task<CountryModel> LoadContryWebApi(string name)
        {
            try
            {
                var response = await _webRepository.GetArray<RestcountriesModel>(name);
                var country = response.First();
                return _mapper.Map<CountryModel>(country);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<CountryModel>> LoadContryDb()
        {
            try
            {
                var countries = await _dbRepository.GetAll<CountryEntity>();

                var result = countries.Select(x => new CountryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Population = x.Population,
                    Area = x.Area,
                    CountryCode = x.CountryCode,
                    Region = new RegionModel { Id = x.Region.Id, Name = x.Region.Name },
                    Сapital = new CityModel { Id = x.Сapital.Id, Name = x.Сapital.Name }
                });
                return _mapper.Map<IEnumerable<CountryModel>>(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }
    }
}
