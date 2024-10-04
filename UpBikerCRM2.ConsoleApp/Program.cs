using UpBikerCRM.Core.Entities;

int opcion = 0;
var inventario = new Inventario();

Console.WriteLine("Bienvenido Al Sistema CRM Upbiker");

while (opcion != 5)
{
    Console.WriteLine("----------------------------------------------");
    Console.WriteLine("Ingrese una de las siguientes opciones: \n");
    Console.WriteLine("1 -> Agregar Un Producto \n" +
        "2 -> Listar Productos Por Categoria \n" +
        "3 -> Eliminar Productos Por Nombre Y Categoría \n" +
        "4 -> Calcular El Valor Total Del Inventario \n" +
        "5 -> Salir"
        );
    opcion = Int32.Parse(Console.ReadLine());
    switch (opcion) 
    {
        case 1:
            Console.WriteLine("Has Seleccionado La Opción Agregar Un Producto");
            OpcionAgregarProducto();
            Console.WriteLine("¿Desea Agregar Otro Producto?");
            Console.WriteLine("Ingrese Si O No");
            string respuestaOp1 = Console.ReadLine().ToLower();
            if(respuestaOp1 == "si")
            {
                OpcionAgregarProducto();
            }
            break;
        case 2:
            Console.WriteLine("Has Seleccionado Listar Productos Por Categoria");
            OpcionListarProductosPorCategoria();
            Console.WriteLine("¿Desea Realizar Otra Busqueda?");
            Console.WriteLine("Ingrese Si O No");
            string respuestaOp2 = Console.ReadLine().ToLower();
            if (respuestaOp2 == "si")
            {
                OpcionListarProductosPorCategoria();
            }
            break;
        case 3:
            Console.WriteLine("Has Seleccionado La Opción Eliminar Productos Por Nombre Y Categoría");
            OpcionEliminarProducto();
            Console.WriteLine("¿Desea Eliminar Otro Producto?");
            Console.WriteLine("Ingrese Si O No: ");
            string respuestaOp3 = Console.ReadLine().ToLower();
            if (respuestaOp3 == "si")
            {
                OpcionEliminarProducto();
            }
            break;
        case 4:
            Console.WriteLine("Has Seleccionado Eliminar Productos Por Nombre Y Categoría");
            double valorTotalInventario = inventario.CalcularValorTotalInventario();
            Console.WriteLine($"El Valor Total Del Inventario Es De: $ {valorTotalInventario}");
            break;
    }
}


void OpcionAgregarProducto()
{
    Console.WriteLine("Ingrese El Nombre Del Producto:");
    string nombre = Console.ReadLine();
    Console.WriteLine("Ingrese El Precio Del Producto:");
    double precio = Double.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese La Categoría Del Producto:");
    string categoria = Console.ReadLine();

    inventario.AgregarProducto(nombre, precio, categoria);
    Console.WriteLine("El Nuevo Producto Ha Sido Agregado Correctamente!");
    Console.WriteLine("----------------------------------------------");
}

void OpcionListarProductosPorCategoria()
{
    Console.WriteLine("Ingresa La Categoria Que Deseas Buscar: ");
    string categoria = Console.ReadLine();

    var listaProductos = inventario.ListarProductosPorCategoria(categoria);
    if (listaProductos.Count > 0)
    {
        Console.WriteLine("Se Han Encontrado Los Siguientes Productos:");
        foreach (Inventario.Producto producto in listaProductos)
        {
            Console.WriteLine($"Nombre: {producto.Nombre}, Precio: {producto.Precio}, Categoría: {producto.Categoria}");
        }
    }
    else
    {
        Console.WriteLine($"No Se Han Encontrado Productos Con La Categoría {categoria}");
    }
    Console.WriteLine("----------------------------------------------");
}

void OpcionEliminarProducto()
{
    Console.WriteLine("Ingrese El Nombre Del Producto Que Desea Eliminar:");
    string nombre = Console.ReadLine();
    Console.WriteLine("Ingrese La Categoría Del Producto Que Desea Eliminar: ");
    string categoria = Console.ReadLine();

    bool respuesta = inventario.EliminarProducto(nombre, categoria);

    if (respuesta)
    {
        Console.WriteLine($"El Producto {nombre} Se Ha Eliminado Correctamente");
    }
    else
    {
        Console.WriteLine($"No Se Pudo Eliminar El Producto {nombre}");
    }
    Console.WriteLine("----------------------------------------------");
}