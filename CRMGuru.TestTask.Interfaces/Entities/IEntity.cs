using System;
using System.Collections.Generic;
using System.Text;

namespace CRMGuru.TestTask.Interfaces.Entities
{
    public interface IEntity
    {
        int Id { get; }

        string Name { get; }
    }
}
