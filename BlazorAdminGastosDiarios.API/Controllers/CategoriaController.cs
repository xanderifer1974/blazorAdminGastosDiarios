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

    }

    
}
