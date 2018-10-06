using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public sealed class Error
    {
        private const int BadRequest = 400;

        /// <summary>
        /// A code for indicating whats going on
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// A detail description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A brief description
        /// </summary>
        public string ReasonPhrase { get; set; }

        /// <summary>
        /// Creates an instance of a <see cref="Error"/> with code 400
        /// </summary>
        /// <param name="message">A message containing the errors</param>
        /// <returns>A instance of <see cref="Error"/></returns>
        public static Error BuildBadRequest(string message)
            => new Error
            {
                Code = BadRequest,
                ReasonPhrase = "Bad request",
                Description = message
            };
    }
}
