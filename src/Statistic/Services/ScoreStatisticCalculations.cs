using noo.api.Statistic.DataAbstraction;
using System.Globalization;
using noo.api.Work.Aggregations.AssignedWork.DataAbstraction;

namespace noo.api.Statistic.Service
{
    public class ScoreStatisticCalculations
    {
        public static IEnumerable<StatisticDataBody> CalculateWeeklyScoreAverages(IEnumerable<AssignedWorkModel> assignedWorks)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            return assignedWorks
                .GroupBy(aw => ci.Calendar.GetWeekOfYear(
                    aw.SolveDeadlineAt,
                    CalendarWeekRule.FirstDay,
                    DayOfWeek.Monday))

                .Select(g => new StatisticDataBody
                {
                    Label = "Week of the year: " + g.Key.ToString(),
                    Value = g.Average(aw => aw.Score ?? 0)
                });
        }
        public static IEnumerable<StatisticDataBody> CalculateWeeklyScoreMaxes(IEnumerable<AssignedWorkModel> assignedWorks)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            return assignedWorks
                .GroupBy(aw => ci.Calendar.GetWeekOfYear(
                    aw.SolveDeadlineAt,
                    CalendarWeekRule.FirstDay,
                    DayOfWeek.Monday))

                .Select(g => new StatisticDataBody
                {
                    Label = "Week of the year: " + g.Key.ToString(),
                    Value = g.Max(aw => aw.Score ?? 0)
                });
        }
        public static IEnumerable<StatisticDataBody> CalculateMonthlyScoreAverages(IEnumerable<AssignedWorkModel> assignedWorks)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            return assignedWorks
                .GroupBy(aw => new { Year = aw.SolveDeadlineAt.Year, Month = aw.SolveDeadlineAt.Month })

                .Select(g => new StatisticDataBody
                {
                    Label = $"{g.Key.Year}-{g.Key.Month:D2}",
                    Value = g.Average(aw => aw.Score ?? 0)
                });
        }
        public static IEnumerable<StatisticDataBody> CalculateMonthlyScoreMaxes(IEnumerable<AssignedWorkModel> assignedWorks)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            return assignedWorks
                .GroupBy(aw => new { Year = aw.SolveDeadlineAt.Year, Month = aw.SolveDeadlineAt.Month })

                .Select(g => new StatisticDataBody
                {
                    Label = $"{g.Key.Year}-{g.Key.Month:D2}",
                    Value = g.Max(aw => aw.Score ?? 0)
                });
        }
    }
}
