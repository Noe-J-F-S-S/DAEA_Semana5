using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BProductos

    {
        DProductos datos = new DProductos();

        public List<Productos> Listar(string nombre)
        {


            var productos = datos.Listar();
            var result = productos.Where(x => x.nombre == nombre
            || string.IsNullOrEmpty(nombre)
            ).ToList();
            return result;


        }

        public void Insertar(Productos producto)
        {
            try
            {
                var productos = datos.Listar();
                var max = productos.Select(x => x.id).Max();
                producto.id = max + 1;

                datos.Insertar(producto);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }






    }
}
