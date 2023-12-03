using noo.api.Statistic.DataAbstraction;
using noo.api.Core.DataAbstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using noo.api.Work.Aggregations.AssignedWork.DataAbstraction;

namespace noo.api.Statistic.Service
{
    public class DeadlineStatisticCalculations
    {
        /// <summary>
        /// Calculates deadline average with precision of one week. 
        /// assignedWorks.SolvedAt shouldn't contain null values, or it will be assigned to the maximum value.
        /// </summary>

        public static IEnumerable<StatisticDataBody> CalculateWeeklyDeadlineAverages(IEnumerable<AssignedWorkModel> assignedWorks)
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
                    Value = g.Count(aw => (aw.SolvedAt ?? DateTime.MaxValue) < aw.SolveDeadlineAt) / g.Count() * 100
                });
        }
        /// <summary>
        /// Calculates deadline average with precision of one month. 
        /// assignedWorks.SolvedAt shouldn't contain null values, or it will be assigned to the maximum value.
        /// </summary>
        public static IEnumerable<StatisticDataBody> CalculateWeeklyDeadlineMaxes(IEnumerable<AssignedWorkModel> assignedWorks)
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
                    Value = g.Count(aw => (aw.SolvedAt ?? DateTime.MaxValue) < aw.SolveDeadlineAt)
                });
        }
        /// <summary>
        /// Calculates failed deadlines with precision of one week. 
        /// assignedWorks.SolvedAt shouldn't contain null values, or it will be assigned to the maximum value.
        /// </summary>

        public static IEnumerable<StatisticDataBody> CalculateMonthlyDeadlineAverages(IEnumerable<AssignedWorkModel> assignedWorks)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            return assignedWorks
                .GroupBy(aw => new { Year = aw.SolveDeadlineAt.Year, Month = aw.SolveDeadlineAt.Month })

                .Select(g => new StatisticDataBody
                {
                    Label = $"{g.Key.Year}-{g.Key.Month:D2}",
                    Value = g.Count(aw => (aw.SolvedAt ?? DateTime.MaxValue) > aw.SolveDeadlineAt) / g.Count() * 100
                });
        }
        /// <summary>
        /// Calculates failed deadlines with precision of one month. 
        /// assignedWorks.SolvedAt shouldn't contain null values, or it will be assigned to the maximum value.
        /// </summary>
        public static IEnumerable<StatisticDataBody> CalculateMonthlyDeadlineMaxes(IEnumerable<AssignedWorkModel> assignedWorks)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            return assignedWorks
                .GroupBy(aw => new { Year = aw.SolveDeadlineAt.Year, Month = aw.SolveDeadlineAt.Month })

                .Select(g => new StatisticDataBody
                {
                    Label = $"{g.Key.Year}-{g.Key.Month:D2}",
                    Value = g.Count(aw => (aw.SolvedAt ?? DateTime.MaxValue) > aw.SolveDeadlineAt)
                });
        }
    }
}
