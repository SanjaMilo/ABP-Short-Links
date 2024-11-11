using System;
using LinkStore.Permissions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace LinkStore.Links;

public class LinkAppService :
    CrudAppService<
        Link, //The Link entity
        LinkDto, //Used to show books
        Guid, //Primary key of the book entity
        //PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateLinkDto>, //Used to create/update a book
    ILinkAppService //implement the IBookAppService
{
    public LinkAppService(IRepository<Link, Guid> repository)
        : base(repository)
    {
        GetPolicyName = LinkStorePermissions.Links.Default;
        GetListPolicyName = LinkStorePermissions.Links.Default;
        CreatePolicyName = LinkStorePermissions.Links.Create;
        CreatePolicyName = LinkStorePermissions.Links.Redirect;
        //UpdatePolicyName = LinkStorePermissions.Links.Edit;
        //DeletePolicyName = LinkStorePermissions.Links.Delete;

    }

    // Ovde:
    private string GenerateUniqueShortID()
    {
        return Convert.ToString(Guid.NewGuid()).Substring(0, 7); // Example of generating a unique ID
    }

    private bool IsValidUrl(string urlString)
    {
        if (urlString.Length < 100) return false;

        try
        {
            var url = new Uri(urlString);
            return (url.Scheme == Uri.UriSchemeHttp || url.Scheme == Uri.UriSchemeHttps || url.Scheme == Uri.UriSchemeFtp) && !string.IsNullOrEmpty(url.Host);
        }
        catch
        {
            return false;
        }
    }

    // Get all links (list of all links)

    public async Task<List<LinkDto>> GetAllLinksAsync()
    {
        var links = await Repository.GetListAsync();
        return ObjectMapper.Map<List<Link>, List<LinkDto>>(links);
    }

    // Create a new link
    public async Task<LinkDto> CreateLinkAsync(CreateUpdateLinkDto input)
    {
        //var link = ObjectMapper.Map<CreateUpdateLinkDto, Link>(input);
        //await Repository.InsertAsync(link);
        //return ObjectMapper.Map<Link, LinkDto>(link);

        if (!IsValidUrl(input.Original))
        {
            throw new UserFriendlyException("Invalid Original URL");
        }

        var shortId = GenerateUniqueShortID();
        var shortUrl = $"http://localhost:3000/{shortId}";

        var newLink = new Link
        {
            Original = input.Original,
            Short = shortUrl,
            IdPart = shortId
        };

        await Repository.InsertAsync(newLink);
        return ObjectMapper.Map<Link, LinkDto>(newLink);

    }

    // Get original link from short link
    public async Task<string> PostOriginalAsync(string shortLinkId)
    {
        var link = await Repository.FirstOrDefaultAsync(l => l.IdPart == shortLinkId);

        if (link != null)
        {
            return link.Original;
        }
        else
        {
            throw new UserFriendlyException("Cannot find this URL!");
        }
    }


    //// Example: Update an existing link
    //public async Task<LinkDto> UpdateAsync(Guid id, CreateUpdateLinkDto input)
    //{
    //    var link = await Repository.GetAsync(id);
    //    ObjectMapper.Map(input, link);
    //    await Repository.UpdateAsync(link);
    //    return ObjectMapper.Map<Link, LinkDto>(link);
    //}

    // Example: Delete a link
    //public async Task DeleteAsync(Guid id)
    //{
    //    await Repository.DeleteAsync(id);
    //}
}
