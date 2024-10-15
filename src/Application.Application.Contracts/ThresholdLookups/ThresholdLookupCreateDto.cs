using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Application.ThresholdLookups
{
    public abstract class ThresholdLookupCreateDtoBase
    {
        [Required]
        public string Code { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}