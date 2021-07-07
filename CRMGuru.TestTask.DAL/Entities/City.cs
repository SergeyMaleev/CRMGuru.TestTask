using CRMGuru.TestTask.DAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRMGuru.TestTask.DAL.Entities
{
    /// <summary>
    /// Город
    /// </summary>
    public class City : IEntity
    {
        [Key]
        [ForeignKey("Country")]
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string CityName { get; set; }
    }
}
