using LinkStore.Links; // ova ovde dodadi za da nema error
using AutoMapper;

namespace LinkStore;

public class LinkStoreApplicationAutoMapperProfile : Profile
{
    public LinkStoreApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        // Ova ovde (map the Link entities to the LinkDto objects):
        CreateMap<Link, LinkDto>();
        // I ova (define the mapping from the CreateUpdateLinkDto object to the Link entity)
        CreateMap<CreateUpdateLinkDto, Link>();
    }
}
