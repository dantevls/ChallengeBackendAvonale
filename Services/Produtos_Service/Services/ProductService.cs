using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Produtos_Domain.Entities;
using Produtos_Domain.Intefaces;
using Produtos_Domain.Intefaces.Services.Products;

namespace Produtos_Service.Services
{
    public class ProductService : IProductService
    {

        private static HttpClient _httpClient;
        private static HttpClient HttpClient => _httpClient ?? (_httpClient = new HttpClient());
        private IRepository<ProductEntity> _repository;

        public ProductService(IRepository<ProductEntity> repository)
        {
            _repository = repository;
        }

        public async Task<PaymentResponse> BuyRequest(PaymentEntity paymentEntity)
        {
            List<string> bandeiras = new List<string> { "MasterCard", "Elo", "VISA" };

            if (paymentEntity.cartao.numero.Length != 16)
            {
                throw new Exception("Número do cartão é inválido");
            }
            else if (paymentEntity.cartao.cvv.Length != 3)
            {
                throw new Exception("Número de segurança do cartão é inválido");
            }
            else if (!bandeiras.Contains(paymentEntity.cartao.bandeira))
            {
                throw new Exception("Bandeira do cartão é inválida");
            }

            var productValue = await Get(paymentEntity.produto_id);
            var objContent = new PaymentRequest();
            objContent.valor = productValue.Valor_Unitario * paymentEntity.qtde_comprada;
            objContent.cartao = paymentEntity.cartao;
            productValue.Qtde_estoque = productValue.Qtde_estoque - paymentEntity.qtde_comprada;

            if (productValue.Qtde_estoque < 0)
            {
                throw new Exception("Não há estoque dísponivel");
            }

            const string Url = "http://localhost:5000/api/pagamento/compras";
            var requestContent = JsonConvert.SerializeObject(objContent);
            var content = new StringContent(requestContent, Encoding.UTF8, "application/json");
            try
            {
                var response = await HttpClient.PostAsync(Url, content);
                var finalResponse = JsonConvert.DeserializeObject<PaymentResponse>(response.Content.ReadAsStringAsync().Result);
                await _repository.UpdateAsync(productValue);
                return finalResponse;

            }
            catch (ArgumentException)
            {
                throw new Exception("Erro conectar-se com o serviço de pagamento");
            }

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
