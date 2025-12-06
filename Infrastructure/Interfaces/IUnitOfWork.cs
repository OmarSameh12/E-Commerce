using Core.Entities;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        public Task<int> Complete();

        public void Dispose();

        public IGenericRepostory<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

    }
}
