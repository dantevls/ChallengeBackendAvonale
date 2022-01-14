using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pagamentos_Domain.Entities;
using Pagamentos_Domain.Interfaces;

namespace ApiPagamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private IPagamentoService _service;
        public PagamentoController(IPagamentoService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("compras")]
        public ActionResult PaymentValidation([FromBody] PaymentEntity payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _service.PaymentValidation(payment);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido");
                }
            }
            catch (ArgumentException)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido");
            }
        }

    }
}
