using Core.Entities;
using Infrastructure.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IGenericRepostory<T>where T:BaseEntity
    {
        public Task<T> GetByIdAsync(int? id);

        public Task<IReadOnlyList<T>> GetAllAsync();

        Task<int> CountAsync(ISpecifications<T> specifications);
        public Task<T> GetEntityWithSpecificationAsync(ISpecifications<T> specs);
        public Task<IReadOnlyList<T>> GetAllWithSpecificationAsync(ISpecifications<T> specs);
        public void Update(T entity);
        public void Delete(T entity);
        public  Task Add(T entity);
    }
}
