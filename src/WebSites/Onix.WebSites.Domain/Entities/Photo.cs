using CSharpFunctionalExtensions;
using Onix.SharedKernel.ValueObjects.Ids;
using Path = Onix.SharedKernel.ValueObjects.Path;

namespace Onix.WebSites.Domain.Entities;

public class Photo : SharedKernel.Entity<PhotoId>
{
    //ef core
    private Photo(PhotoId id) : base(id)
    {
    }
    
    private Photo(
        PhotoId id,
        Path path) : base(id)
    {
        Path = path;
    }
    
    public Path Path { get; private set; }

    public static Result<Photo> Create (
        PhotoId id,
        Path path)
    {
        return new Photo(id, path);
    }
}