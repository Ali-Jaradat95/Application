using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Application.AccessChannelLookups
{
    public abstract class AccessChannelLookupBase : FullAuditedAggregateRoot<int>
    {
        [NotNull]
        public virtual string Code { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? Description { get; set; }

        protected AccessChannelLookupBase()
        {

        }

        public AccessChannelLookupBase(string code, string name, string? description = null)
        {

            Check.NotNull(code, nameof(code));
            Check.NotNull(name, nameof(name));
            Code = code;
            Name = name;
            Description = description;
        }

    }
}