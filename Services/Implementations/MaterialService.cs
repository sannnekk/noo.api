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

        public async Task CreateMaterialAsync(MaterialModel newMaterial)
        {
            using (_unitOfWork)
            {
                await _unitOfWork.Materials.Add(newMaterial);
                _unitOfWork.Complete();
            }
        }

        public async Task<MaterialModel?> GetMaterialAsync(Ulid id)
        {           
            using (_unitOfWork)
            {
                var material = await _unitOfWork.Materials.Get(id);
                return material;
            }
        }

        public async Task RemoveMaterialAsync(MaterialModel material)
        {
            using (_unitOfWork)
            {
                await _unitOfWork.Materials.Delete(material);
                _unitOfWork.Complete();
            }
        }

        public async Task UpdateMaterialAsync(MaterialModel newMaterial)
        {
            using (_unitOfWork)
            {
                var material = await _unitOfWork.Materials.Get(newMaterial.Id);

                if(material == null)
                    throw new NullReferenceException();

                material.Name = newMaterial.Name;
                material.Description = newMaterial.Description;
                material.Content = newMaterial.Content;
                material.UpdatedAt = DateTime.Now;

                _unitOfWork.Complete();
            }
        }
    }
}
