using Data.domain.models;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnicaBack.Interfaces
{
    public interface IProducto
    {
        public Task<ActionResult<IEnumerable<ProductoModel>>> GetProductos();

        public Task<ActionResult<ProductoModel>> GetProducto(int id);

        public Task PostProducto(ProductoModel invoice);

        public Task PutProducto(int id, ProductoModel invoice);
        public Task DeleteProducto(int id);
    }
}
