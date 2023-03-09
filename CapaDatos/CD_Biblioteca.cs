using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
	public class Libro
    { 
       public static List<Libro> Listar()
        {
            List<Libro> rptListaLibro = new List<Libro>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaAlumno.Add(new Libro()
                        {
                            IdAlumno = Convert.ToInt32(dr["IdLibro"].ToString()),
                            Codigo = dr["Codigo"].ToString(),
                            Nombre = dr["Nombre del libro"].ToString(),
                            Autor = dr["Autor"].ToString(),
                            Cantidad = dr["Cantidad"].ToString(),
                            FechaEmision = Convert.ToDateTime(dr["FechaEmision"].ToString()),
                            Editorial = dr["Editorial"].ToString(),
                           
                        });
                    }
                    dr.Close();

                    return rptListaLibro;

                }
                catch (Exception ex)
                {
                    rptListaLibros = null;
                    return rptListaLibros;
                }
        }
    }
    public static DataTable Prestamos(string Codigo, string Nombre , string Apellido, string grupo, int Cantidad, string FechaPrestamo, string FechaDevolucion, string Genero, int Numpaginas)
    {
        List<Libro> rptListaLibro = new List<Libro>();
        DataTable dt = new DataTable();
        using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
        {
            SqlDataAdapter da = new SqlDataAdapter(" rptListaLibro", oConexion);
            da.SelectCommand.Parameters.AddWithValue("Codigo",Codigo);
            da.SelectCommand.Parameters.AddWithValue("NombreAlumno", Nombre);
            da.SelectCommand.Parameters.AddWithValue("Apellido", Apellido );
            da.SelectCommand.Parameters.AddWithValue("grupo", Cantidad);
            da.SelectCommand.Parameters.AddWithValue("cantidad", Cantidad);
            da.SelectCommand.Parameters.AddWithValue("Fechaprestamo", FechaPrestamo);
            da.SelectCommand.Parameters.AddWithValue("FechaDevolucion", FechaDevolucion);
            da.SelectCommand.Parameters.AddWithValue("Genero", Genero);
            da.SelectCommand.Parameters.AddWithValue("Num.Paginas", Numpaginas;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
    }

    public static bool Registrar(Libro oLibro)
    {
        bool respuesta = true;
        using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
        {
            try
            {
                SqlCommand cmd = new SqlCommand("usp_RegistrarLibro", oConexion);
                cmd.Parameters.AddWithValue("Codigo", oLibro.Codigo);
                cmd.Parameters.AddWithValue("Nombre del libro", oLibro.Nombre del libro);
                cmd.Parameters.AddWithValue("Autor", oLibro.Autor);
                cmd.Parameters.AddWithValue("Cantidad ", oLibro.Cantidad);
                cmd.Parameters.AddWithValue("Fecha de Emicion", oLibro.Fecha de Emicion);
                cmd.Parameters.AddWithValue("Editorial", oLibro.Editorial);
                cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                oConexion.Open();

                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

            }
            catch (Exception ex)
            {
                respuesta = false;
            }

        }

        return respuesta;

    }

    public static bool Editar(Libro oLibro)
    {
        bool respuesta = true;
        using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
        {
            try
            {
                SqlCommand cmd = new SqlCommand("usp_EditarAlumno", oConexion);
                cmd.Parameters.AddWithValue("Codigo", oLibro.Codigo);
                cmd.Parameters.AddWithValue("Nombre del libro", oLibro.Nombre del libro);
                cmd.Parameters.AddWithValue("Autor", oLibro.Autor);
                cmd.Parameters.AddWithValue("Cantidad ", oLibro.Cantidad);
                cmd.Parameters.AddWithValue("Fecha de Emocion", oLibro.Fecha de Emision);
                cmd.Parameters.AddWithValue("Editorial", oLibro.Editorial);
                cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                oConexion.Open();

                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

            }
            catch (Exception ex)
            {
                respuesta = false;
            }

        }

        return respuesta;

    }

    public static bool Eliminar(int idLibro)
    {
        bool respuesta = true;
        using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
        {
            try
            {
                SqlCommand cmd = new SqlCommand("usp_EliminarLibro", oConexion);
                cmd.Parameters.AddWithValue("IdLibro", idalumno);
                cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                oConexion.Open();

                cmd.ExecuteNonQuery();

                respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

            }
            catch (Exception ex)
            {
                respuesta = false;
            }

        }

        return respuesta;

    }

}
}
