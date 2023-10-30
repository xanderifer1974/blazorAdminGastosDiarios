using BlazorAdminGastosDiarios.Data.Repositories.Interfaces;
using BlazorAdminGastosDiarios.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAdminGastosDiarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public  CategoriaController(ICategoriaRepository categoriaRepositorio)
        {
            _categoriaRepository = categoriaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> ListarTodasCategorias()
        {
            var categorias = await _categoriaRepository.ListarTodasCategorias();
            return Ok(categorias);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Categoria>> ObterCategoria(int id)
        {
            var categoria = await _categoriaRepository.ObterCategoria(id);
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> InserirCategoria([FromBody] Categoria categoria)
        {
            if(categoria == null)
                return BadRequest();

            if(categoria.NomeCategoria.Trim() == string.Empty)
            {
                ModelState.AddModelError("NomeCategoria", "O nome da categoria deve estar preenchido");
            }
               

            if(!ModelState.IsValid)
                return BadRequest();

            var inserido = await _categoriaRepository.InserirCategoria(categoria).ConfigureAwait(false);

            return Created("inserido", inserido);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarCategoria([FromBody] Categoria categoria)
        {
            if (categoria == null)
                return BadRequest();

            if (categoria.NomeCategoria.Trim() == string.Empty)
            {
                ModelState.AddModelError("NomeCategoria", "O nome da categoria deve estar preenchido");
            }


            if (!ModelState.IsValid)
                return BadRequest();

            var atualizado = await _categoriaRepository.AtualizarCategoria(categoria).ConfigureAwait(false);

            return NoContent();
        }
    }

    
}
