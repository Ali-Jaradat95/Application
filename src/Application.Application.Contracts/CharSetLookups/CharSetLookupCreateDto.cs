using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Application.CharSetLookups
{
    public abstract class CharSetLookupCreateDtoBase
    {
        [Required]
        public string Code { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}