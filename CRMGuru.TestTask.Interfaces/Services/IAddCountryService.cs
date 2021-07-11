using CRMGuru.TestTask.Interfaces.Entities;
using CRMGuru.TestTask.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMGuru.TestTask.Interfaces.Services
{
    /// <summary>
    /// Сервис добавления Страны в базу данных
    /// </summary>
    public interface IAddCountryService
    {       
        /// <summary>
        /// Добавление страны в базу данных
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task AddCountryDb(CountryModel item);
    }
}
