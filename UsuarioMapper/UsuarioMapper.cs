using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace Mapper
{
    public class UsuarioMapper
    {
        Datos datos;

        public UsuarioMapper()
        {
            datos = new Datos();
        }

        public List<TipoSubscripcion> ObtenerTiposSubscripcion()
        {
            DataTable tabla = datos.ObtenerDatos("Obtener_TiposSubscripcion", null);

            List<TipoSubscripcion> tiposSubscripcion = new List<TipoSubscripcion>();

            foreach (DataRow row in tabla.Rows)
            {
                tiposSubscripcion.Add(new TipoSubscripcion
                {
                    id = Convert.ToInt32(row["id"]),
                    nombre = row["nombre"].ToString()
                });
            }

            return tiposSubscripcion;
        }

        public void SuscribirUsuario(Usuario usuario, Subscripcion subscripcion)
        {
            Hashtable parametros = new Hashtable();

            parametros.Add("@usuarioID", usuario.id);
            parametros.Add("@subscripcionID", subscripcion.id);

            datos.EjecutarComando("Suscribir_Usuario", parametros);
        }

        public void CancelarSuscripcion(Usuario usuario, Subscripcion subscripcion)
        {
            Hashtable parametros = new Hashtable();
            parametros.Add("@usuarioID", usuario.id);
            parametros.Add("@subscripcionID", subscripcion.id);


            datos.EjecutarComando("Cancelar_Suscripcion", parametros);
        }

        public bool EsSuscripcionActiva(Usuario usuario)
        {
            Hashtable parametros = new Hashtable();
            parametros.Add("@usuarioID", usuario.id);

            object resultado = datos.EjecutarScalar("Es_Suscripcion_Activa", parametros);
            return Convert.ToBoolean(resultado);
        }

        public List<Usuario> ObtenerUsuariosConSuscripciones()
        {
            List<Usuario> usuarios = new List<Usuario>();

            DataTable dtUsuarios = datos.ObtenerDatos("Obtener_Usuarios_Suscripciones", null);
            foreach (DataRow row in dtUsuarios.Rows)
            {
                Usuario usuario = new Usuario
                {
                    id = Convert.ToInt32(row["UsuarioID"]),
                    nombre = row["NombreCompleto"].ToString(),
                    nomUsuario = row["NombreUsuario"].ToString(),
                    mail = row["Correo"].ToString(),
                    edad = Convert.ToInt32(row["Edad"]),
                    subscripcion = new Subscripcion
                    {
                        id = Convert.ToInt32(row["SubscripcionID"]),
                        activa = Convert.ToBoolean(row["SubscripcionActiva"]),
                        tipoSubscripcion = new TipoSubscripcion
                        {
                            nombre = row["TipoSubscripcion"].ToString()
                        }
                    }
                };

                usuarios.Add(usuario);
            }

            return usuarios;

        }

        public Usuario ObtenerUsuarioPorNombre(string nombre)
        {
            Hashtable parametros = new Hashtable();
            parametros.Add("@nombre", nombre);

            DataTable dt = datos.ObtenerDatos("Usuario_Por_Nombre", parametros);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Usuario
                {
                    id = Convert.ToInt32(row["id"]),
                    nombre = row["nombre"].ToString(),
                    nomUsuario = row["nom_usuario"].ToString(),
                    mail = row["mail"].ToString(),
                    edad = Convert.ToInt32(row["edad"])
                };
            }
            return null;
        }


        public Subscripcion ObtenerSubscripcionPorTipo(string tipo)
        {
            Hashtable parametros = new Hashtable();
            parametros.Add("@tipo", tipo);

            DataTable dt = datos.ObtenerDatos("Subscripcion_Por_Tipo", parametros);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Subscripcion
                {
                    id = Convert.ToInt32(row["id"]),
                    activa = Convert.ToBoolean(row["activa"]),
                    tipoSubscripcion = new TipoSubscripcion { nombre = row["tipoSubscripcion"].ToString() }
                };
            }
            return null;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            Hashtable parametros = new Hashtable();
            parametros.Add("@nombre", usuario.nombre);
            parametros.Add("@nomUsuario", usuario.nomUsuario);
            parametros.Add("@mail", usuario.mail);
            parametros.Add("@edad", usuario.edad);
            parametros.Add("@tipoSubscripcion", usuario.subscripcion.tipoSubscripcion.nombre);

            datos.EjecutarComando("Suscribir_Usuario", parametros);
        }
    }


}
