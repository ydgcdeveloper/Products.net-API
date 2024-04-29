using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Productos.Server.Models;
using Products.Server.Models;

namespace Products.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            //guardar el product en la base de datos
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            //devolver un mensaje de exito
            return Ok();
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            //Obten la lista de Products de la base de datos
            var Products = await _context.Products.ToListAsync();

            //devuelve una lista de Products
            return Ok(Products);
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetProduct(int id)
        {
            //obtener el product de la base de datos
            Product product = await _context.Products.FindAsync(id);

            //devolver el product
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            //Actualizar el product en la base de datos
            var productoExistente = await _context.Products.FindAsync(id);
            productoExistente!.Name = product.Name;
            productoExistente.Description = product.Description;
            productoExistente.Price = product.Price;

            await _context.SaveChangesAsync();

            //devolver un mensaje de exito
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            //Eliminar product de la base de datos
            var productoBorrado = await _context.Products.FindAsync(id);
            _context.Products.Remove(productoBorrado!);

            await _context.SaveChangesAsync();

            //Devolver un mensaje de exito
            return Ok();
        }
    }
}
