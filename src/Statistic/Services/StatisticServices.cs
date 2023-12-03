using noo.api.Statistic.DataAbstraction;
using noo.api.Core.DataAbstraction.Exceptions;

using noo.api.Work.Aggregations.AssignedWork.DataAbstraction;
using Microsoft.AspNetCore.Http.Connections;

namespace noo.api.Statistic.Service
{
    public class StatisticService : IStatisticService
    {
        protected readonly IAssignedWorkRepository assignedWorkRepository;
        private const string DEFAULT_ACCURACY = "month";
        public StatisticService(IAssignedWorkRepository assignedWorkRepository)
        {
            this.assignedWorkRepository = assignedWorkRepository;
        }

        private string type = null!;
        private DateTime startDate;
        private DateTime endDate;
        private string accuracy = null!;
        public async Task<StatisticResponseBody> GetWorksStatisticAsync(StatisticRequestBody request, Ulid StudentId)
        {
            type = request.Type;
            startDate = request.StartDate;
            endDate = request.EndDate ?? DateTime.Now;
            accuracy = request.Accuracy ?? DEFAULT_ACCURACY;
            IEnumerable<AssignedWorkModel>? assignedWorks = new List<AssignedWorkModel>();
            StatisticResponseBody response = new StatisticResponseBody();

            Predicate<AssignedWorkModel> predicate = new Predicate<AssignedWorkModel>(model => model.StudentId == StudentId && model.CheckStatus == CheckStatusEnum.Checked && model.SolvedAt >= startDate && model.SolvedAt <= endDate);

            try
            {
                assignedWorks = await this.assignedWorkRepository.GetManyAsync(predicate);
                if (assignedWorks == null)
                    throw new NotFoundException("No corrected works with given criteria was found!");               
            }
            catch (System.Exception)
            {
                throw new UnknownException("Error getting works statistic!");
            }

            switch (type)
            {
                case "average":
                    switch (accuracy)
                    {
                        case "week":
                            response.Data = (List<StatisticDataBody>)ScoreStatisticCalculations.CalculateWeeklyScoreAverages(assignedWorks);
                            return response;
                        case "month":
                            response.Data = (List<StatisticDataBody>)ScoreStatisticCalculations.CalculateMonthlyScoreAverages(assignedWorks);
                            return response;
                        default:
                            throw new UnknownException("Wrong accuracy!");
                    }
                case "best":
                    switch (accuracy)
                    {
                        case "week":
                            response.Data = (List<StatisticDataBody>)ScoreStatisticCalculations.CalculateWeeklyScoreMaxes(assignedWorks);
                            return response;
                        case "month":
                            response.Data = (List<StatisticDataBody>)ScoreStatisticCalculations.CalculateMonthlyScoreMaxes(assignedWorks);
                            return response;
                        default:
                            throw new UnknownException("Wrong accuracy!");
                    }
                default:
                    throw new UnknownException("Wrong type!");
            }
            
        }

        public async Task<IEnumerable<StatisticResponseBody>> GetWorksStatisticAdvancedAsync(StatisticRequestBody requestAd)
        {
            var response = new List<StatisticResponseBody>();

            foreach (var user in requestAd.Users ?? new List<Ulid>())
            {
                var request = new StatisticRequestBody
                {
                    Type = requestAd.Type,
                    StartDate = requestAd.StartDate,
                    EndDate = requestAd.EndDate,
                    Accuracy = requestAd.Accuracy
                };

                var statistic = await GetWorksStatisticAsync(request, user);
                response.Add(statistic);
            }
            
            return response;
        }

        public async Task<StatisticResponseBody> GetDeadlinesStatisticAsync(StatisticRequestBody request, Ulid StudentId)
        {
            type = request.Type;
            startDate = request.StartDate;
            endDate = request.EndDate ?? DateTime.Now;
            accuracy = request.Accuracy ?? DEFAULT_ACCURACY;
            IEnumerable<AssignedWorkModel>? assignedWorks = new List<AssignedWorkModel>();
            StatisticResponseBody response = new StatisticResponseBody();

            Predicate<AssignedWorkModel> predicate = new Predicate<AssignedWorkModel>(model => model.StudentId == StudentId && model.CheckStatus == CheckStatusEnum.Checked && model.SolvedAt >= startDate && model.SolvedAt <= endDate);

            try
            {
                assignedWorks = await this.assignedWorkRepository.GetManyAsync(predicate);
                if (assignedWorks == null)
                    throw new NotFoundException("No corrected works with given criteria was found!");               
            }
            catch (System.Exception)
            {
                throw new UnknownException("Error getting works statistic!");
            }

            switch (type)
            {
                case "rate":
                    switch (accuracy)
                    {
                        case "week":
                            response.Data = (List<StatisticDataBody>)DeadlineStatisticCalculations.CalculateWeeklyDeadlineAverages(assignedWorks);
                            return response;
                        case "month":
                            response.Data = (List<StatisticDataBody>)DeadlineStatisticCalculations.CalculateMonthlyDeadlineAverages(assignedWorks);
                            return response;
                        default:
                            throw new UnknownException("Wrong accuracy!");
                    }
                case "failed":
                    switch (accuracy)
                    {
                        case "week":
                            response.Data = (List<StatisticDataBody>)DeadlineStatisticCalculations.CalculateWeeklyDeadlineMaxes(assignedWorks);
                            return response;
                        case "month":
                            response.Data = (List<StatisticDataBody>)DeadlineStatisticCalculations.CalculateMonthlyDeadlineMaxes(assignedWorks);
                            return response;
                        default:
                            throw new UnknownException("Wrong accuracy!");
                    }
                default:
                    throw new UnknownException("Wrong type!");
            }
        }

        public async Task<IEnumerable<StatisticResponseBody>> GetDeadlinesStatisticAdvancedAsync(StatisticRequestBody requestAd)
        {
            var response = new List<StatisticResponseBody>();

            foreach (var user in requestAd.Users ?? new List<Ulid>())
            {
                var request = new StatisticRequestBody
                {
                    Type = requestAd.Type,
                    StartDate = requestAd.StartDate,
                    EndDate = requestAd.EndDate,
                    Accuracy = requestAd.Accuracy
                };

                var statistic = await GetWorksStatisticAsync(request, user);
                response.Add(statistic);
            }
            
            return response;
        }

        
    }
}
