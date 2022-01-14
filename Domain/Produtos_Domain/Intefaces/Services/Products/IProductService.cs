using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Produtos_Domain.Entities;

namespace Produtos_Domain.Intefaces.Services.Products
{
    public interface IProductService
    {
        Task<ProductEntity> Get(Guid id);

        Task<List<ProductEntity>> GetAll();

        Task<ProductEntity> Post(ProductEntity productEntity);

        Task<ProductEntity> Put(ProductEntity productEntity);

        Task<bool> Delete(Guid id);

        Task<PaymentResponse> BuyRequest(PaymentEntity paymentEntity);
        //Na verdade tem que ser um paymentRequest
    }
}
