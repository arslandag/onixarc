namespace Onix.SharedKernel;

public static class Errors
{
    public static class General
    {
        public static Error NotFound(Guid? id = null)
        {
            var forId = id == null ? "" : $" for Id '{id}'";
            return Error.NotFound("record.not.found", $"record not found{forId}");
        }
    }
    
    public static class Domain
    {
        public static Error ValueIsRequired(string? value = null)
        {
            var label = value ?? "value";
            return Error.Validation("value.is.required", $"{label} is required");
        }
        
        public static Error ValueIsInvalid(string? value = null)
        {
            var label = value ?? "value";
            return Error.Validation("value.is.invalid", $"{label} is invalid");
        }
        
        public static Error AlreadyExist(string? value)
        {
            var label = value ?? "value";
            return Error.Validation("value.already.exist", $"{value} already exist");
        }

        public static Error MaxCount(string? value)
        {
            var label = value ?? "value";
            return Error.Failure("value.max.count", $"{value} exceeds maximum allowed count");
        }

        public static Error MaxLength(string? value)
        {
            var label = value ?? "value";
            return Error.Validation("value.max.length", $"{value} exceeds maximum allowed length");
        }
        
        public static Error MinLength(string? value)
        {
            var label = value ?? "value";
            return Error.Validation("value.min.length", $"{value} exceeds min allowed length");
        }
    }
}