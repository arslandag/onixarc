using CSharpFunctionalExtensions;

namespace Onix.WebSites.Domain.WebSites.ValueObjects;

public class DataSolution
{
    private DataSolution(string question, string answer)
    {
        Question = question;
        Answer = answer;
    }

    public string Question { get; }
    public string Answer { get; }

    public static Result<DataSolution>  Create(string question, string answer)
    {
        return new DataSolution(question, answer);
    }
}