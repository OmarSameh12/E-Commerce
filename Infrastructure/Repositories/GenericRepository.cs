using Core;
using Core.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepostory<T> where T:BaseEntity
    {
        private readonly StoreDbContext _context;

        public GenericRepository(StoreDbContext context)
        {
            _context = context;
        }


        public async Task Add(T entity)
        => await _context.Set<T>().AddAsync(entity);

        public async Task<int> CountAsync(ISpecifications<T> specifications)
        => await ApplySpecifications(specifications).CountAsync();
        public void Delete(T entity)
       => _context.Set<T>().Remove(entity);

        public async Task<IReadOnlyList<T>> GetAllAsync()
        => await _context.Set<T>().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAllWithSpecificationAsync(ISpecifications<T> specs)
        => await ApplySpecifications(specs).ToListAsync();

        public async Task<T> GetByIdAsync(int? id)
        => await _context.Set<T>().FindAsync(id);

        public async Task<T> GetEntityWithSpecificationAsync(ISpecifications<T> specs)
        =>await ApplySpecifications(specs).FirstOrDefaultAsync();

        public void Update(T entity) 
        => _context.Set<T>().Update(entity);

        private IQueryable<T> ApplySpecifications(ISpecifications<T> specs)
                => SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specs);
    


    }
}
