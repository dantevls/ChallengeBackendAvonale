using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Produtos_Domain.Entities;
using Produtos_Domain.Intefaces.Services.Products;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ComprasController : ControllerBase
    {
        private readonly IProductService _service;

        public ComprasController(IProductService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult> BuyRequest([FromBody] PaymentEntity payment)
        {
            var retorno = await _service.BuyRequest(payment);
            return Ok(retorno);
        }
    }
}
