using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Produtos_Domain.Entities;
using Produtos_Domain.Intefaces.Services.Products;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        private readonly IProductService _service;
        public ProdutosController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]

        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, "Ocorreu um erro Desconhecido");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException)
            {

                return StatusCode((int)HttpStatusCode.BadRequest, "Ocorreu um erro Desconhecido");
            }
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] ProductEntity product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(product);
                if (result != null)
                {
                    //  return Created(new Uri(Url.Link("GetById", new { id = result.Id })), result);
                    return StatusCode((int)HttpStatusCode.OK, "Produto Cadastrado");
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

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProductEntity product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(product);
                if (result != null)
                {
                    return StatusCode((int)HttpStatusCode.OK);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Delete(id);
                if (result == true)
                {
                    return StatusCode((int)HttpStatusCode.OK, "Produto Excluído com sucesso");
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
