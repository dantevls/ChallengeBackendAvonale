using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Produtos_Domain.Entities;

namespace Produtos_Domain.Intefaces
{
    public interface IRepository<E> where E : BaseEntity
    {
        Task<E> InsertAsync(E entity);

        Task<E> UpdateAsync(E entity);

        Task<bool> DeleteAsync(Guid id);

        Task<E> SelectAsync(Guid id);

        Task<List<E>> SelectAsync();

    }
}
