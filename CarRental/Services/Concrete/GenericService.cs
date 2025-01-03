﻿using CarRental.Data.Abstract;
using CarRental.Models;
using CarRental.Services.Abstract;

namespace CarRental.Services.Concrete
{
    public class GenericService<T> : IGenericService<T> where T: BaseEntity
    {
        private readonly IGenericRepository<T> _repository;
        public GenericService(IGenericRepository<T> genericRepository )
        {
            _repository = genericRepository;
        }

        public async Task AddAsync(T entity)
        {
             await _repository.TAddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
          await  _repository.TDeleteAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.TGetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.TGetByIdAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.TUpdateAsync(entity);
        }
    }
}
