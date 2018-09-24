using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    /// <summary>
    /// Represents the base of a entity on the system.
    /// </summary>
    public interface IEntityBase
    {
        /// <summary>
        /// Represents the entity's identificator
        /// </summary>
        Guid Id { get; set; }
    }
}
