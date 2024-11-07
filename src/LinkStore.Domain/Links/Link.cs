using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace LinkStore.Links;

public class Link : AuditedAggregateRoot<Guid>
{
    public string Original { get; set; }

    public string Short { get; set; }

    public string IdPart { get; set; }
}
