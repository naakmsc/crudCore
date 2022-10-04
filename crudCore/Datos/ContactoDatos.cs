using crudCore.Models;
using System.Data;
using System.Data.SqlClient;

namespace crudCore.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {
            var oLista = new List<ContactoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL())) {

                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) {
                    while (dr.Read()) {
                        oLista.Add(new ContactoModel()
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Nombre = dr["nombre"].ToString(),
                            Telefono = dr["telefono"].ToString(),           Correo = dr["correo"].ToString()    
                        }); 
                    }
                }
            }

            return oLista;
        }

        public ContactoModel Obtener(int Id) 
        {
            var oContacto = new ContactoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL())) 
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener",conexion);

                cmd.Parameters.AddWithValue("id",Id);

                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) 
                {
                    while (dr.Read()) 
                    {
                        oContacto.Id = Convert.ToInt32(dr["id"]);
                        oContacto.Nombre = dr["nombre"].ToString();
                        oContacto.Telefono = dr["telefono"].ToString();
                        oContacto.Correo = dr["correo"].ToString();
                    }
                }
            }

            return oContacto;
        }

        public bool Guardar(ContactoModel oContacto) 
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL())) 
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("sp_Guardar",conexion);

                    cmd.Parameters.AddWithValue("nombre",oContacto.Nombre);
                    cmd.Parameters.AddWithValue("telefono",oContacto.Telefono);
                    cmd.Parameters.AddWithValue("correo",oContacto.Correo);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                respuesta = true;
            }
            catch (Exception e) 
            {
                string error = e.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public bool Editar(ContactoModel oContacto) 
        {
            bool res;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL())) 
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("sp_Editar",conexion);

                    cmd.Parameters.AddWithValue("id",oContacto.Id);
                    cmd.Parameters.AddWithValue("nombre",oContacto.Nombre);
                    cmd.Parameters.AddWithValue("telefono",oContacto.Telefono);
                    cmd.Parameters.AddWithValue("correo",oContacto.Correo);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                res = true;
            }
            catch (Exception e) 
            {
                string error = e.Message;
                res = false;
            }

            return res;
        }

        public bool Eliminar(int Id)
        {
            bool res;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {

                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);

                    cmd.Parameters.AddWithValue("id",Id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }


                    res = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                res = false;
            }


            return res;
        }
    }
}
