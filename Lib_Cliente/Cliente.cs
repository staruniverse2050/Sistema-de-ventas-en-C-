using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibLlenarGrid;
using LibConexionBD;
using System.Windows.Forms;

namespace Lib_Cliente
{
    public class Cliente
    {
        #region atributos
        private string identificacion;
        private string nombre;
        private string apellido;
        private string direccion;
        private string telefono;
        private string error;
        private SqlDataReader reader;
        #endregion

        #region propiedades
        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Error { get => error; set => error = value; }
        public SqlDataReader Reader { get => reader; set => reader=value; }


        #endregion
        #region metodos publicos
        public Cliente()
        {
            identificacion = "";
            nombre = "";
            apellido = "";
            direccion ="";
            telefono = "";
            error = "";
        }
        public bool InsertarCliente()
        {
            ClsConexion ObjCl = new ClsConexion();
            string sentencia = "execute usp_InsertarClien '" + Identificacion + "','" + nombre + "','" + apellido + "','" + direccion + "','" + telefono+"'";
            if (!ObjCl.EjecutarSentencia(sentencia, false))
            {
                error = ObjCl.Error;
                ObjCl = null;
                return false;
            }
            else
            {
                error = "Se guardó exitosamente";
                ObjCl = null;
                return true;
            }
        }
        public bool ActualizarCliente()
        {
            ClsConexion ObjCl = new ClsConexion();
            string sentencia = "execute usp_ActualizarClien '"  + Identificacion + "','" + nombre + "','" + apellido + "','" + direccion + "','" + telefono+"'";
            if (!ObjCl.EjecutarSentencia(sentencia, false))
            {
                error = ObjCl.Error;
                ObjCl = null;
                return false;
            }
            else
            {
                error = "Se actualizó exitosamente";
                ObjCl= null;
                return true;
            }
        }
        public bool EliminarCliente()
        {
            ClsConexion ObjCl = new ClsConexion();
            string sentencia = "execute usp_EliminarClien '" + Identificacion + "'";
            if (!ObjCl.EjecutarSentencia(sentencia, false))
            {
                error = ObjCl.Error;
                ObjCl = null;
                return false;
            }
            else
            {
                error = "Se eliminó exitosamente";
                ObjCl = null;
                return true;
            }
        }

        public bool ConsultarCliente()
        {
            ClsConexion ObjCl = new ClsConexion();

            string sentencia = "execute usp_ConsultarClien '" + Identificacion + "'";
            if (!ObjCl.Consultar(sentencia, false))
            {
                error = ObjCl.Error;
                ObjCl = null;
                return false;
            }
            else
            {
                reader = ObjCl.Reader;
                ObjCl = null;
                return true;
            }



        }
        public bool ListarCliente(DataGridView ObjCl)
        {
            ClsLlenarGrid ObjG = new ClsLlenarGrid();
            ObjG.NombreTabla= "DatosClien";
            ObjG.SQL = "execute usp_ListarClien";

            if (!ObjG.LlenarGrid(ObjCl))
            {
                error = ObjG.Error;
                ObjCl = null;
                return false;
            }
            else
            {
                ObjCl = null;
                return true;
            }



            #endregion
        }
    }
}