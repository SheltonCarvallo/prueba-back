using Data.domain.models;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaBack.Interfaces;

namespace PruebaTecnicaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        readonly IProducto _producto;

        public ProductoController(IProducto producto)
        {
            _producto = producto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoModel>>> GetProductos()
        {
            try
            {
                return await _producto.GetProductos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoModel>> GetProducto(int id)
        {
            try
            {
                string variable = "this is a test using another branch on git";
                return await _producto.GetProducto(id);

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult<ProductoModel>> PutInvoice([FromBody] ProductoModel producto)
        {
            try
            {
                await _producto.PostProducto(producto);
                return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult<ProductoModel>> PutInvoice(int id, [FromBody] ProductoModel producto)
        {
            try
            {
                if (producto.Id != id)
                {
                    return BadRequest();
                }
                await _producto.PutProducto(id, producto);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpDelete]
        public async Task DeleteProducto(int id)
        {
            try
            {
                await _producto.DeleteProducto(id);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
