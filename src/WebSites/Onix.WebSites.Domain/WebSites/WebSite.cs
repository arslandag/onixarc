using CSharpFunctionalExtensions;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Blocks;
using Onix.WebSites.Domain.ConfigSite;
using Onix.WebSites.Domain.Entities;
using Onix.WebSites.Domain.WebSites.ValueObjects;

namespace Onix.WebSites.Domain.WebSites;

public class WebSite : SharedKernel.Entity<WebSiteId>
{
    //ef core
    private WebSite(WebSiteId id) : base(id)
    {
    }
    
    private WebSite(
        WebSiteId id,
        Url url,
        Name name,
        Appearance appearance,
        bool showStatus = true) : base(id)
    {
        Url = url;
        Name = name;
        ShowStatus = showStatus;
        Appearance = appearance;
    }
    
    public Url Url { get; private set; }
    public Name Name { get; private set; }
    public Phone? Phone { get; private set; }
    public bool ShowStatus { get; private set; }
    public Appearance Appearance { get; private set; }
    
    public Photo? Favicon { get; private set; }
    
    public IReadOnlyList<SocialMedia> SocialMedias => _socialMedias;
    private readonly List<SocialMedia> _socialMedias = [];
    
    public IReadOnlyList<Block> Blocks => _blocks;
    private readonly List<Block> _blocks = [];
    
    public static Result<WebSite, ErrorList> Create(
        WebSiteId id,
        Url url,
        Name name,
        Appearance appearance,
        bool showStatus = true)
    {
        if (string.IsNullOrWhiteSpace(url.Value))
            return Errors.Domain.ValueIsRequired(nameof(url)).ToErrorList();
        
        if (string.IsNullOrWhiteSpace(name.Value))
            return Errors.Domain.ValueIsRequired(nameof(name)).ToErrorList();
        
        return new WebSite(
            id,
            url,
            name,
            appearance, showStatus);
    }

    public  UnitResult<Error> AddBlock(Block block)
    {
        //реализовать позиции 
        _blocks.Add(block);
        return Result.Success<Error>();
    }
    
    public static Result<WebSite> AddFavicon(
        ref WebSite webSite, Photo favicon)
    {
        webSite.Favicon = favicon;

        return webSite;
    }
}