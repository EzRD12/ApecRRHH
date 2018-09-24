using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    /// <summary>
    /// Represents the result of a basic operation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOperationResult<T>
    {
        /// <summary>
        /// Represents a message result of the operation
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Represents if the operation was succesful
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// Represents the operation result's body
        /// </summary>
        T Entity { get; }
    }
}
