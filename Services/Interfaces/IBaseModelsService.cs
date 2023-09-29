﻿using api.Models.DB;

namespace api.Services.Interfaces
{
    public interface IBaseModelsService<T> where T : BaseModel
    {
        Task<T> GetAsync(Ulid id);

        Task DeleteAsync(T entity);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);
    }
}