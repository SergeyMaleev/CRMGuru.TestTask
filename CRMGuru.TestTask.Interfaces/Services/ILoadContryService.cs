using CRMGuru.TestTask.Interfaces.Entities;
using CRMGuru.TestTask.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMGuru.TestTask.Interfaces.Services
{
    /// <summary>
    /// Сервис загрузки данных о стране 
    /// </summary>
    public interface ILoadContryService
    {      
        /// <summary>
        /// Загружает данные о стране с стороннего Api
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<CountryModel> LoadContryWebApi(string name);
        
        /// <summary>
        /// Загружает список стран с базы данных
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CountryModel>> LoadContryDb();
    }
}
