using CRMGuru.TestTask.Interfaces.Entities;

namespace CRMGuru.TestTask.Interfaces.Models
{
    public class CountryModel : IEntity
    {
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
        public CityModel Сapital { get; set; }

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
        public RegionModel Region { get; set; }
    }
}
