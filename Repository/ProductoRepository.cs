using RepositorioDTO_EF.Data;
using RepositorioDTO_EF.Models;

namespace RepositorioDTO_EF.Repository
{
    public class ProductoRepository
    {
        private readonly ContextoDB _contexto;

        public ProductoRepository(ContextoDB contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Producto> ObtenerProductos()
        {
            return _contexto.Productos.ToList();
        }

        public void AgregarProducto(Producto producto)
        {
            _contexto.Productos.Add(producto);
            _contexto.SaveChanges();
        }
        public void ActualizarProducto(Producto producto)
        {
            _contexto.Productos.Update(producto);
            _contexto.SaveChanges();
        }

        public void EliminarProducto(int id)
        {
            var producto = _contexto.Productos.Find(id);

            if (producto != null)
            {
                _contexto.Productos.Remove(producto);
                _contexto.SaveChanges();
            }
        }

    }
}