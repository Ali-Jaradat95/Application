using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Application.MethodTypeLookups
{
    public abstract class MethodTypeLookupDtoBase : FullAuditedEntityDto<int>, IHasConcurrencyStamp
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}