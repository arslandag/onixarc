using CSharpFunctionalExtensions;

namespace Onix.WebSites.Domain.Locations.ValueObjects;

public record Schedule
{
    private Schedule(
        string weekDay,
        string startTime,
        string endTime)
    {
        WeekDay = weekDay;
        StartTime = startTime;
        EndTime = endTime;
    }
    
    public string WeekDay { get; }
    public string StartTime { get; }
    public string EndTime { get; }

    public static Result<Schedule> Create(
        string weekDay,
        string startTime,
        string endTime)
    {
        return new Schedule(
            weekDay,
            startTime,
            endTime);
    }
}