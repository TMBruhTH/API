using DataModel.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogradouroController : ControllerBase
    {
        private readonly ILogradouroService _service;
        public LogradouroController(ILogradouroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> visualizar(int? id)
        {
            try
            {
                return Ok(new { ok = true, data = await _service.visualizar(id), message = "Visualizado com sucesso!!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ok = false, message = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> remover(int id)
        {
            try
            {
                await _service.remover(id);

                return Ok(new { ok = true, message = "Removido com sucesso!!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ok = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> adicionar(Logradouro model)
        {
            try
            {
                await _service.adicionar(model);

                return Ok(new { ok = true, message = "Adicionado com sucesso!!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ok = false, message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> atualizar(Logradouro model)
        {
            try
            {
                await _service.atualizar(model);

                return Ok(new { ok = true, message = "Atualizado com sucesso!!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ok = false, message = ex.Message });
            }
        }
    }
}
