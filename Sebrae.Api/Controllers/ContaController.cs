using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sebrae.Domain.Dtos;
using Sebrae.Domain.Interfaces.Service;

namespace Sebrae.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;
        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _contaService.ListContas();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _contaService.Consultar(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContaDto conta)
        {
            await _contaService.Create(conta);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(ContaDto conta)
        {
            await _contaService.Edit(conta);

            return Ok();
        }

        [HttpDelete("{id}")]        
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id == 0)
                return BadRequest("Objeto dto está vazio!");

            await _contaService.Delete(id);

            return Ok();
        }


    }
}
