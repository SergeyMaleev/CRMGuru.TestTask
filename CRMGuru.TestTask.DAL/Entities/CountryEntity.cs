using CRMGuru.TestTask.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRMGuru.TestTask.DAL.Entities
{
    /// <summary>
    /// Страна
    /// </summary>
    public class CountryEntity : IEntity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название страны
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код страны
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Столица
        /// </summary>
        public CityEntity Сapital { get; set; }

        /// <summary>
        /// Площадь
        /// </summary>
        public double Area { get; set; }

        /// <summary>
        /// Население
        /// </summary>
        public uint Population { get; set; }

        /// <summary>
        /// Регион
        /// </summary>
        public RegionEntity Region { get; set; }
    }
}
