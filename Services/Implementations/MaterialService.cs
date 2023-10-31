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

        public async Task<IEnumerable<MaterialModel>> GetManyAsync(Func<MaterialModel, bool> predicate)
        {
            using (_unitOfWork)
            {
                var materials = await _unitOfWork.Materials.GetMany(predicate);
                return materials;
            }
        }

        public async Task<MaterialModel?> GetMaterialWithWorksAsync(Ulid id)
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
            }
        }

        public async Task UpdateAsync(MaterialModel newMaterial)
        {
            using (_unitOfWork)
            {
                var material = await _unitOfWork.Materials.Get(newMaterial.Id);

                if (material == null)
                    throw new NullReferenceException(nameof(material));

                material.Name = newMaterial.Name;
                material.Description = newMaterial.Description;
                material.Content = newMaterial.Content;
                material.UpdatedAt = DateTime.Now;
            }
        }

        public async Task<int> CountAsync()
        {
            using (_unitOfWork)
            {
                var count = await _unitOfWork.Materials.Count();
                return count;
            }
        }

        public async Task DeleteAsync(Ulid id)
        {
            using (_unitOfWork)
            {
                var model = await _unitOfWork.Materials.Get(id);

                if (model == null)
                    throw new NullReferenceException(nameof(model));

                await _unitOfWork.Materials.Delete(model);
            }
        }
    }
}
