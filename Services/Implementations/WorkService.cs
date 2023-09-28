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

        public async Task CreateAsync(WorkModel workModel)
        {
            using (_unitOfWork)
            {
                await _unitOfWork.Works.Add(workModel);
                _unitOfWork.Complete();
            }
        }

        public async Task DeleteAsync(WorkModel workModel)
        {
            using (_unitOfWork)
            {
                await _unitOfWork.Works.Delete(workModel);
                _unitOfWork.Complete();
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

        public async Task UpdateAsync(WorkModel newWorkModel)
        {
            using (_unitOfWork)
            {
                var work = await _unitOfWork.Works.Get(newWorkModel.Id);

                if (work == null)
                    throw new NullReferenceException(nameof(work));

                work.Description = newWorkModel.Description;
                work.UpdatedAt = DateTime.Now;

                _unitOfWork.Complete();
            }        
        }
    }
}
