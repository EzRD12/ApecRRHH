using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Web.Api.Helpers
{
    internal static class ModelStateHelpers
    {
        internal static string GetErrorMessages(this ModelStateDictionary.ValueEnumerable enumerable, string joinCharacters)
        {
            string messages = string.Join(joinCharacters, enumerable
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));

            return messages;
        }
    }
}
