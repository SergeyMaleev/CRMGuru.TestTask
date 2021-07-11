using CRMGuru.TestTask.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMGuru.TestTask.Interfaces.Models
{
    public class RegionModel : IEntity
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
