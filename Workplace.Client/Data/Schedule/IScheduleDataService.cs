using Workplace.Shared.Schedule;

namespace Workplace.Client.Data.Schedule
{
    public interface IScheduleDataService
    {
        Task<List<ScheduleItem>> GetDayAsync(DateTime dayDate);
        Task<List<ScheduleItem>> GetDayRangeAsync(DateTime border1, DateTime border2, string studentName);
    }
}
