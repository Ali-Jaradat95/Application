using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Application.MessageEncodingLookups
{
    public abstract class MessageEncodingLookupCreateDtoBase
    {
        [Required]
        public string Code { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}