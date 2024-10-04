namespace UpBikerCRM.Core.Entities
{
    public class Inventario
    {
        private Dictionary<string, List<Producto>> listaProductosCategoria;

        public Inventario()
        {
            listaProductosCategoria = new Dictionary<string, List<Producto>>();
        }

        public class Producto()
        {
            public string Nombre { get; set; } = null!;

            public double Precio { get; set; }

            public string Categoria { get; set; } = null!;
        }

        public void AgregarProducto(string nombre, double precio, String categoria)
        {
            var producto = new Producto
            {
                Nombre = nombre,
                Categoria = categoria,
                Precio = precio
            };

            if (!listaProductosCategoria.ContainsKey(categoria))
            {
                listaProductosCategoria[categoria] = new List<Producto>();
            }

            listaProductosCategoria[categoria].Add(producto);
        }

        public bool EliminarProducto(string nombre, string categoria)
        {
            if (listaProductosCategoria.ContainsKey(categoria))
            {
                var listaProductos = listaProductosCategoria[categoria];
                var productoActual = listaProductos.Where(x => x.Nombre == nombre).FirstOrDefault();
                if (productoActual is not null)
                {
                    listaProductos.Remove(productoActual);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<Producto> ListarProductosPorCategoria(string categoria)
        {
            return listaProductosCategoria.ContainsKey(categoria) ? listaProductosCategoria[categoria] : new List<Producto>();
        }

        public double CalcularValorTotalInventario()
        {
            double valorTotalInventario = listaProductosCategoria.Values.SelectMany(p => p).Sum(pc => pc.Precio);
            return valorTotalInventario;
        }
    }
}
