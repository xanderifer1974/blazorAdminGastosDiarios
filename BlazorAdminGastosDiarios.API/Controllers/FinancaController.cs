using BlazorAdminGastosDiarios.Data.Repositories;
using BlazorAdminGastosDiarios.Data.Repositories.Interfaces;
using BlazorAdminGastosDiarios.Model;
using BlazorAdminGastosDiarios.Model.Enum;
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

            if(financa.Valor < 0 && financa.TipoFinanca == TipoFinancaEnum.Credito)
            {
                ModelState.AddModelError("Valor Crédito", "O valor não deve ser negativo para crédito");
            }

            if (financa.Valor > 0 && financa.TipoFinanca == TipoFinancaEnum.Debito)
            {
                ModelState.AddModelError("Valor Débito", "O valor não deve ser positivo para débito");
            }     


            if (!ModelState.IsValid)
                return BadRequest();

            var inserido = await _financaRepository.InserirDetalheFinanca(financa).ConfigureAwait(false);

            return Created("inserido", inserido);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarDetalheFinanca([FromBody] Financa financa)
        {
            if (financa == null)
                return BadRequest();

            if (financa.Descricao.Trim() == string.Empty)
            {
                ModelState.AddModelError("NomeFinanca", "O nome da finança deve estar preenchido");
            }

            if (financa.Valor < 0 && financa.TipoFinanca == TipoFinancaEnum.Credito)
            {
                ModelState.AddModelError("Valor Crédito", "O valor não deve ser negativo para crédito");
            }

            if (financa.Valor > 0 && financa.TipoFinanca == TipoFinancaEnum.Debito)
            {
                ModelState.AddModelError("Valor Débito", "O valor não deve ser positivo para débito");
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var inserido = await _financaRepository.AtualizarDetalheFinanca(financa).ConfigureAwait(false);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarFinanca(int id)
        {
            if (id == 0)
                return BadRequest();

            var financa = await _financaRepository.ObterDetalheFinanca(id).ConfigureAwait(false);

            if (financa != null)
            {
                await _financaRepository.DeletarDetalheFinanca(id).ConfigureAwait(false);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
