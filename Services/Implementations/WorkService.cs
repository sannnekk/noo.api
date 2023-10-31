using api.Models.DB;
using api.Repositories;
using api.Services.Interfaces;

namespace api.Services.Implementations
{
    public class WorkService : IWorkService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(WorkModel workModel)
        {
            using (_unitOfWork)
            {
                await _unitOfWork.Works.Add(workModel);
            }
        }

        public async Task DeleteAsync(WorkModel workModel)
        {
            using (_unitOfWork)
            {
                await _unitOfWork.Works.Delete(workModel);
            }
        }

        public async Task DeleteAsync(Ulid id)
        {
            using (_unitOfWork)
            {
                var work = await _unitOfWork.Works.Get(id);

                if (work == null)
                    throw new NullReferenceException(nameof(work));

                await _unitOfWork.Works.Delete(work);
            }
        }

        public async Task<WorkModel?> GetAsync(Ulid id)
        {
            using (_unitOfWork)
            {
                var work = await _unitOfWork.Works.Get(id);
                return work;
            }
        }

        public Task<IEnumerable<WorkModel>> GetManyAsync(Func<WorkModel, bool> predicate)
        {
            using (_unitOfWork)
            {
                var works = _unitOfWork.Works.GetMany(predicate);
                return works;
            }
        }

        public async Task UpdateAsync(WorkModel newWorkModel)
        {
            using (_unitOfWork)
            {
                var work = await _unitOfWork.Works.Get(newWorkModel.Id);

                if (work == null)
                    throw new NullReferenceException(nameof(work));

                work.Description = newWorkModel.Description;
                work.UpdatedAt = DateTime.Now;
            }
        }
    }
}
