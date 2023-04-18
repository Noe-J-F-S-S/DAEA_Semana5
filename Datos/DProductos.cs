using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DProductos
    {
        private string connectionString = "Data Source=LAB707-08\\SQLEXPRESS02;Initial Catalog=CAVV_MonitoreoViolencia;Integrated Security=True;";

        public List<Productos> Listar()
        {

            //Obtengo la conexión
            SqlConnection connection = null;
            SqlParameter param = null;
            SqlCommand command = null;
            List<Productos> productos = null;
            try
            {
                connection = new SqlConnection(connectionString);

                connection.Open();

                //Hago mi consulta
                command = new SqlCommand("USP_SeleccionProducto", connection);
                command.CommandType = CommandType.StoredProcedure;

                //param = new SqlParameter();
                //param.ParameterName = "@Description";
                //param.SqlDbType = SqlDbType.VarChar;
                //param.Value = description;

                //command.Parameters.Add(param);

                SqlDataReader reader = command.ExecuteReader();
                productos = new List<Productos>();


                while (reader.Read())
                {

                    Productos producto = new Productos();
                    producto.id = (int)reader["id"];
                    producto.nombre = reader["nombre"].ToString();
                    producto.precio = Convert.ToDouble(reader["precio"]);

                    productos.Add(producto);

                }

                connection.Close();

                //Muestro la información
                return productos;


            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            finally
            {
                connection = null;
                command = null;
                param = null;
                productos = null;

            }


        }
        public void Insertar(Productos producto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("USP_InsProducto", connection); // Nombre del procedimiento almacenado
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado                
                    command.Parameters.AddWithValue("@ProductoID", producto.id);
                    command.Parameters.AddWithValue("@Nombre", producto.nombre);
                    command.Parameters.AddWithValue("@Precio", producto.precio);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
