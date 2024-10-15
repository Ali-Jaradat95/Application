using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Application.ServiceTypeLookups
{
    public abstract class ServiceTypeLookupCreateDtoBase
    {
        [Required]
        public string Code { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}