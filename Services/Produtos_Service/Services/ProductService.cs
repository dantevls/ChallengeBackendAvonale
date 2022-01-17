using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Produtos_Domain.Entities;
using Produtos_Domain.Intefaces;
using Produtos_Domain.Intefaces.Services.Products;
using Produtos_Domain.Models;
using Produtos_Domain.ViewModels;

namespace Produtos_Service.Services
{
    public class ProductService : IProductService
    {

        private static HttpClient _httpClient;
        private static HttpClient HttpClient => _httpClient ?? (_httpClient = new HttpClient());
        private IRepository<ProductEntity> _repository;

        private IMapper _mapper;

        public ProductService(IRepository<ProductEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<PaymentModel> BuyRequest(PaymentEntity paymentEntity)
        {
            List<string> bandeiras = new List<string> { "MASTERCARD", "ELO", "VISA" };

            if (paymentEntity.cartao.numero.Length != 16)
            {
                throw new Exception("Número do cartão inválido");
            }

            else if (paymentEntity.cartao.cvv.Length != 3)
            {
                throw new Exception("Código de segurança do cartão é inválido");
            }

            else if (!bandeiras.Contains(paymentEntity.cartao.bandeira))
            {
                throw new Exception("Bandeira do cartão é inválida");
            }

            var productContent = await Get(paymentEntity.produto_id);
            var paymentContent = new PaymentRequest();
            paymentContent.valor = productContent.Valor_Unitario * paymentEntity.qtde_comprada;
            paymentContent.cartao = paymentEntity.cartao;
            productContent.Qtde_estoque = productContent.Qtde_estoque - paymentEntity.qtde_comprada;
            if (productContent.Qtde_estoque < 0)
            {
                throw new Exception("Não há estoque dísponivel");
            }

            const string Url = "http://localhost:5000/api/pagamento/compras";
            var requestContent = JsonConvert.SerializeObject(paymentContent);
            var content = new StringContent(requestContent, Encoding.UTF8, "application/json");
            try
            {
                var response = await HttpClient.PostAsync(Url, content);
                var finalResponse = JsonConvert.DeserializeObject<PaymentResponse>(response.Content.ReadAsStringAsync().Result);
                if (finalResponse.estado.ToLower() == "aprovado")
                {
                    productContent.Valor_Ultima_Venda = paymentContent.valor;
                    productContent.Data_Compra = DateTime.UtcNow;
                }
                var entity = _mapper.Map<ProductEntity>(productContent);
                await _repository.UpdateAsync(entity);
                var modelResponse = _mapper.Map<PaymentModel>(finalResponse);
                return modelResponse;
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

        public async Task<ProductModel> Get(Guid id)
        {
            ProductEntity Entity = await _repository.SelectAsync(id);
            var Model = _mapper.Map<ProductModel>(Entity);
            return Model;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            var entityList = await _repository.SelectAsync();
            var modelList = _mapper.Map<List<ProductModel>>(entityList);
            return modelList;
        }

        public async Task<ProductModel> Post(ProductViewModel product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            if (productEntity.Valor_Unitario < 0 || productEntity.Valor_Ultima_Venda < 0)
            {
                throw new Exception("Os valores são inválidos");
            }

            productEntity.Valor_Unitario = Math.Round(productEntity.Valor_Unitario, 2);
            productEntity.Data_Compra = null;
            productEntity.Valor_Ultima_Venda = null;
            var entity = await _repository.InsertAsync(productEntity);
            var model = _mapper.Map<ProductModel>(entity);
            return model;

        }

        public async Task<ProductModel> Put(ProductEntity productEntity)
        {
            var entity = await _repository.UpdateAsync(productEntity);
            var model = _mapper.Map<ProductModel>(entity);

            return model;
        }
    }
}
