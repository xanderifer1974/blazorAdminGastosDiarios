using BlazorAdminGastosDiarios.Data.Repositories;
using BlazorAdminGastosDiarios.Data.Repositories.Interfaces;
using BlazorAdminGastosDiarios.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAdminGastosDiarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancaController : Controller
    {
        private readonly IFinancaRepository _financaRepository;

        public FinancaController(IFinancaRepository financaRepository)
        {
            _financaRepository = financaRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Financa>>> ListarTodasFinancas()
        {
            var financas = await _financaRepository.ListarTodasFinancas();

            return Ok(financas);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Financa>> ObterDetalheFinanca(int id)
        {
            var financa = await _financaRepository.ObterDetalheFinanca(id);
            return Ok(financa);
        }

        [HttpPost]
        public async Task<IActionResult> InserirDetalheFinanca([FromBody] Financa financa)
        {
            if (financa == null)
                return BadRequest();

            if (financa.Descricao.Trim() == string.Empty)
            {
                ModelState.AddModelError("NomeFinanca", "O nome da finança deve estar preenchido");
            }
           


            if (!ModelState.IsValid)
                return BadRequest();

            var inserido = await _financaRepository.InserirDetalheFinanca(financa).ConfigureAwait(false);

            return Created("inserido", inserido);
        }

        //Parei no video 44, 7:36
    }
}
