using System;
using Volo.Abp.Application.Dtos;

namespace LinkStore.Links;

public class LinkDto : AuditedEntityDto<Guid>
{
    public string Original { get; set; }

    public string Short { get; set; }

    public string IdPart { get; set; }
}
