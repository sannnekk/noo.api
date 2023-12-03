using noo.api.Work.Aggregations.AssignedWork.Aggregations.Answer.DataAbstraction;

namespace noo.api.Work.Aggregations.AssignedWork.Aggregations.Answer.Services;

public interface IAnswerService
{
    Task CreateAsync(AnswerModel model);
    Task UpdateAsync(AnswerModel model);
    Task DeleteAsync(Ulid id);
    Task<AnswerModel?> GetAsync(Ulid id);
    Task<IEnumerable<AnswerModel>> GetAsync();
}
