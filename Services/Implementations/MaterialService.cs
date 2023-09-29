using api.Models.DB;
using api.Repositories;
using api.Services.Interfaces;

namespace api.Services.Implementations
{
    public class MaterialService : IMaterialService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MaterialService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(MaterialModel newMaterial)
        {
            using (_unitOfWork)
            {
                await _unitOfWork.Materials.Add(newMaterial);
                _unitOfWork.Complete();
            }
        }

        public async Task<MaterialModel?> GetAsync(Ulid id)
        {           
            using (_unitOfWork)
            {
                var material = await _unitOfWork.Materials.Get(id);
                return material;
            }
        }

        public async Task<MaterialModel> GetMaterialWithWorksAsync(Ulid id)
        {
            using (_unitOfWork)
            {
                var material = await _unitOfWork.Materials.GetMaterialWithWorks(id);
                return material;
            }
        }

        public async Task DeleteAsync(MaterialModel material)
        {
            using (_unitOfWork)
            {
                await _unitOfWork.Materials.Delete(material);
                _unitOfWork.Complete();
            }
        }

        public async Task UpdateAsync(MaterialModel newMaterial)
        {
            using (_unitOfWork)
            {
                var material = await _unitOfWork.Materials.Get(newMaterial.Id);

                if(material == null)
                    throw new NullReferenceException(nameof(material));

                material.Name = newMaterial.Name;
                material.Description = newMaterial.Description;
                material.Content = newMaterial.Content;
                material.UpdatedAt = DateTime.Now;

                _unitOfWork.Complete();
            }
        }
    }
}
