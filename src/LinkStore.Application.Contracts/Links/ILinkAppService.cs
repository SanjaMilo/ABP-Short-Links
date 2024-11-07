using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LinkStore.Links;

public interface ILinkAppService :
    ICrudAppService< //Defines CRUD methods
        LinkDto, //Used to show links
        Guid, //Primary key of the link entity
        // PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateLinkDto> //Used to create/update a link
{

}