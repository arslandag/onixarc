using CSharpFunctionalExtensions;
using Onix.SharedKernel;
using Onix.SharedKernel.ValueObjects.Ids;
using Onix.WebSites.Domain.Blocks.ValueObjects;

namespace Onix.WebSites.Domain.Blocks;

public class Block : SharedKernel.Entity<BlockId>
{
    //ef core
    private Block(BlockId id) : base(id)
    {
    }
    
    private Block(
        BlockId id,
        Code code) : base(id)
    {
        Code = code;
    }
    
    public Code Code { get; private set; }
    
    public static Result<Block, Error> Create(
        BlockId id, Code code)
    {
        return new Block(
            id, code);
    }

    public UnitResult<Error> Update(Code code)
    {
        this.Code = code;
        return UnitResult.Success<Error>();
    }
}