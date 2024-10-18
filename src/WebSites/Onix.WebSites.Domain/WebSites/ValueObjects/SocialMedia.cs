using CSharpFunctionalExtensions;
using Onix.SharedKernel.ValueObjects;

namespace Onix.WebSites.Domain.WebSites.ValueObjects;

public class SocialMedia
{
    private SocialMedia(
        string social,
        string link)
    {
        Social = social;
        Link = link;
    }
    
    public string Social { get; }
    public string Link { get;}

    public static Result<SocialMedia> Create(
        string social,
        string link)
    {
        return new SocialMedia(social,link);
    }
}