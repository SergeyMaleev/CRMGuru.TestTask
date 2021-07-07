using CRMGuru.TestTask.DAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRMGuru.TestTask.DAL.Entities
{
    /// <summary>
    /// Страна
    /// </summary>
    public class Country : IEntity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название страны
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Код страны
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Столица
        /// </summary>
        public City Сapital { get; set; }

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
        public Region Region { get; set; }
    }
}
