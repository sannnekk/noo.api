using api.Models.DB;
using api.Repositories;
using api.Services.Interfaces;

namespace api.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(SubjectModel newSubject)
        {
            using (_unitOfWork)
            {
                await _unitOfWork.Subjects.Add(newSubject);
            }
        }

        public async Task<SubjectModel?> GetAsync(Ulid id)
        {
            using (_unitOfWork)
            {
                var subject = await _unitOfWork.Subjects.Get(id);
                return subject;
            }
        }

        public async Task<SubjectModel> GetSubjectWithMaterialsAsync(Ulid id)
        {
            using (_unitOfWork)
            {
                var subject = await _unitOfWork.Subjects.GetSubjectWithMaterials(id);
                return subject;
            }
        }

        public async Task DeleteAsync(SubjectModel subject)
        {
            using (_unitOfWork)
            {
                await _unitOfWork.Subjects.Delete(subject);
            }
        }

        public async Task UpdateAsync(SubjectModel newSubject)
        {
            using (_unitOfWork)
            {
                var subject = await _unitOfWork.Subjects.Get(newSubject.Id);

                if (subject == null)
                    throw new NullReferenceException(nameof(subject));

                subject.Name = newSubject.Name;
                subject.Description = newSubject.Description;
                subject.UpdatedAt = DateTime.Now;
            }
        }

        public async Task<int> CountAsync()
        {
            using (_unitOfWork)
            {
                return await _unitOfWork.Subjects.Count();
            }
        }

        public async Task<IEnumerable<SubjectModel>> GetManyAsync(Func<SubjectModel, bool> predicate)
        {
            using (_unitOfWork)
            {
                var subjects = await _unitOfWork.Subjects.GetMany(predicate);
                return subjects;
            }
        }

        public async Task DeleteAsync(Ulid id)
        {
            using (_unitOfWork)
            {
                var model = await _unitOfWork.Subjects.Get(id);

                if (model == null)
                    throw new NullReferenceException(nameof(model));

                await _unitOfWork.Subjects.Delete(model);
            }
        }
    }
}
