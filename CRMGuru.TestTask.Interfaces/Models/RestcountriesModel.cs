using CRMGuru.TestTask.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CRMGuru.TestTask.Interfaces.Models
{
    /// <summary>
    /// Модель данных предоставляемая Api restcountries.eu
    /// </summary>
    public class RestcountriesModel : IEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Код страны
        /// </summary>
        [JsonPropertyName("alpha3Code")]
        public string Alpha3Code { get; set; }

        /// <summary>
        /// Столица
        /// </summary>
        [JsonPropertyName("capital")]
        public string Capital { get; set; }

        /// <summary>
        /// Регион
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }

        /// <summary>
        /// Население
        /// </summary>
        [JsonPropertyName("population")]
        public int Population { get; set; }

        /// <summary>
        /// Площадь
        /// </summary>
        [JsonPropertyName("area")]
        public double Area { get; set; }      
    }  
}
