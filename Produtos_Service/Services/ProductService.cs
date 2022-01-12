using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Produtos_Domain.Entities;
using Produtos_Domain.Intefaces;
using Produtos_Domain.Intefaces.Services.Products;

namespace Produtos_Service.Services
{
    public class ProductService : IProductService
    {

        private IRepository<ProductEntity> _repository;

        public ProductService(IRepository<ProductEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ProductEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<List<ProductEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<ProductEntity> Post(ProductEntity productEntity)
        {
            if (productEntity.Valor_Unitario < 0 || productEntity.Valor_Ultima_Venda < 0)
            {
                productEntity = null;
            }

            productEntity.Valor_Unitario = Math.Round(productEntity.Valor_Unitario, 2);
            productEntity.Data_Compra = null;
            productEntity.Valor_Ultima_Venda = null;
            return await _repository.InsertAsync(productEntity);

        }

        public async Task<ProductEntity> Put(ProductEntity productEntity)
        {

            return await _repository.UpdateAsync(productEntity);
        }
    }
}
