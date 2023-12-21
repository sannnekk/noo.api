using noo.api.Statistic.DataAbstraction;

namespace noo.api.Statistic.Service
{
    public interface IStatisticService
    {
        Task<StatisticResponseBody> GetWorksStatisticAsync(StatisticRequestBody model, Ulid userId);
        Task<IEnumerable<StatisticResponseBody>> GetWorksStatisticAdvancedAsync(StatisticRequestBody model);
        Task<StatisticResponseBody> GetDeadlinesStatisticAsync(StatisticRequestBody model, Ulid userId);
        Task<IEnumerable<StatisticResponseBody>> GetDeadlinesStatisticAdvancedAsync(StatisticRequestBody model);
    }
}
