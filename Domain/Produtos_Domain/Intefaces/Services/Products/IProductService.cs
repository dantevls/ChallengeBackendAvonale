using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Produtos_Domain.Entities;
using Produtos_Domain.Models;
using Produtos_Domain.ViewModels;

namespace Produtos_Domain.Intefaces.Services.Products
{
    public interface IProductService
    {
        Task<ProductModel> Get(Guid id);

        Task<List<ProductModel>> GetAll();

        Task<ProductModel> Post(ProductViewModel product);

        Task<ProductModel> Put(ProductEntity productEntity);

        Task<bool> Delete(Guid id);

        Task<PaymentModel> BuyRequest(PaymentEntity paymentEntity);
        //Na verdade tem que ser um paymentRequest
    }
}
