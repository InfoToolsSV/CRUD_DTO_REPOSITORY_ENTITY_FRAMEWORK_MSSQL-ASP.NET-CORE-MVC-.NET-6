using Microsoft.AspNetCore.Mvc;
using RepositorioDTO_EF.DTO;
using RepositorioDTO_EF.Models;
using RepositorioDTO_EF.Repository;

namespace RepositorioDTO_EF.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoRepository _productoRepo;

        public ProductoController(ProductoRepository repository)
        {
            _productoRepo = repository;
        }

        public IActionResult Index()
        {
            var productos = _productoRepo.ObtenerProductos();
            var datos = productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio
            }).ToList();
            return View(datos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductoDTO productoDTO)
        {
            if (ModelState.IsValid)
            {
                var producto = new Producto
                {
                    Nombre = productoDTO.Nombre,
                    Precio = productoDTO.Precio
                };
                _productoRepo.AgregarProducto(producto);
                return RedirectToAction("Index");
            }
            return View(productoDTO);
        }

        public IActionResult Edit(int id)
        {
            var producto = _productoRepo.ObtenerProductos().FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();

            var productoDTO = new ProductoDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio
            };
            return View(productoDTO);
        }
        [HttpPost]
        public IActionResult Edit(ProductoDTO productoDTO)
        {
            if (ModelState.IsValid)
            {
                var producto = new Producto
                {
                    Id = productoDTO.Id,
                    Nombre = productoDTO.Nombre,
                    Precio = productoDTO.Precio
                };
                _productoRepo.ActualizarProducto(producto);
                return RedirectToAction("Index");
            }
            return View(productoDTO);
        }

        public IActionResult Delete(int id)
        {
            var producto = _productoRepo.ObtenerProductos().FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();

            var productoDTO = new ProductoDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio
            };
            return View(productoDTO);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _productoRepo.EliminarProducto(id);
            return RedirectToAction("Index");
        }

    }
}