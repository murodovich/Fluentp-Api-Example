﻿using Faluent_Api.Application;

namespace Fluent_Api.Infrastructure.Services
{
    public interface IBaseService<TModel,TDto>
    {
        
        public ValueTask<int> CreateAsync(TDto model);
        public ValueTask<int> UpdateAsync(int Id, TDto model);
        public ValueTask<int> DeleteAsync(int Id);
        public ValueTask<TModel> GetByIdAsync(int Id);
        public ValueTask<List<TModel>> GetAllAsync();

    }
}
