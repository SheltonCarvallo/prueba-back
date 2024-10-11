using Data.Data;
using Data.domain.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBack.Interfaces;

namespace PruebaTecnicaBack.Services
{
    public class ProductoService : IProducto
    {
        readonly TiendaDbContext _context;

        public ProductoService(TiendaDbContext context) //DI
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<ProductoModel>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }
        public async Task<ActionResult<ProductoModel>> GetProducto(int id)
        {
            ProductoModel? producto;
            try
            {
                bool existsId = await _context.Productos.AnyAsync(producto => producto.Id == id);
                if (existsId)
                {
                    producto = await _context.Productos.FindAsync(id);
                }
                else
                {
                    return new ProductoModel { };
                }
            }
            catch (Exception)
            {

                throw;
            }

            return producto!;
        }

        public async Task PostProducto(ProductoModel producto)
        {
            try
            {
                bool isRegistered = await _context.Productos.AnyAsync(pro => pro.Id == producto.Id );
                if (isRegistered)
                {
                    return;
                }
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task PutProducto(int id, ProductoModel producto)
        {
            try
            {
                ProductoModel? productoToUpdate = await _context.Productos.FindAsync(id);
                if (productoToUpdate is null)
                {
                    return;
                }
                productoToUpdate.Name = producto.Name;
                productoToUpdate.Description = producto.Description;
                productoToUpdate.Price = producto.Price;
                productoToUpdate.Categoria = producto.Categoria;
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
         public async Task DeleteProducto(int id)
        {
            ProductoModel? productoToDelete = await _context.Productos.FindAsync(id);
            if (productoToDelete is null)
            {
                return;
            }
            if(productoToDelete.Estado == 1) 
            {
                productoToDelete.Estado = 0;
            }
            
            await _context.SaveChangesAsync();
        }

    }
}
