namespace Onix.Core.Dtos;

public class EmployeeDto
{
    public Guid Id { get; init; }
    public Guid BlockId { get; init; }
    
    public string LastName { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string Patronymic { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;
     
    public PhotoDto? Photo { get; init; } = null!;

    public string? Link { get; init; } = string.Empty;
}