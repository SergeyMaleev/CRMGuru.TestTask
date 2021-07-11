using CRMGuru.TestTask.Interfaces.Entities;
using System;

namespace CRMGuru.TestTask.Interfaces.Models
{
    public class CityModel : IEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
