using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt;

namespace Ianf.Gametracker.Services.Domain 
{
    public record DtoValidationError(string ErrorMessage, string DtoType, string DtoProperty) { };
}
