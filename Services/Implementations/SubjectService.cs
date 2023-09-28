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
                _unitOfWork.Complete();
            }
        }

        public async Task<SubjectModel?> GetAsync(Ulid id)
        {
            using(_unitOfWork)
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
                _unitOfWork.Complete();
            }
        }

        public async Task UpdateAsync(SubjectModel newSubject)
        {
            using (_unitOfWork)
            {
                var subject =  await _unitOfWork.Subjects.Get(newSubject.Id);
                
                if(subject == null)
                    throw new NullReferenceException(nameof(subject));   

                subject.Name = newSubject.Name;
                subject.Description = newSubject.Description;
                subject.UpdatedAt = DateTime.Now;
              
                _unitOfWork.Complete();                              
            }
        }
    }
}
