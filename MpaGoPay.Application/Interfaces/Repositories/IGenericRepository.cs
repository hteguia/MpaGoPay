using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MpaGoPay.Application.Interfaces.Specifications;
using MpaGoPay.Domain.Entities;

namespace MpaGoPay.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);

        Task<T> GetEntityWithSpec(ISpecifications<T> specification);
        Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> specification);
        Task<int> CountAsync(ISpecifications<T> specifications);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);

        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
