using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibLlenarGrid;
using LibConexionBD;


namespace Lib_Categoria
{
    public class Categoria
    {
        #region atributos
        private string codigo;
        private string nombre;
        private string descripcion;
        private string error;
        private SqlDataReader reader;
        #endregion

        #region propiedades
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Error { get => error; set => error = value; }
        public SqlDataReader Reader { get => reader; set => reader=value; }


        #endregion
        #region metodos publicos
        public Categoria()
        {
            codigo = "";
            nombre = "";
            descripcion = "";
            error = "";
        }
        public bool InsertarCategoria()
        {
            ClsConexion ObjCat = new ClsConexion();
            string sentencia = "execute usp_InsertarCatego '" + codigo + "','" + nombre + "','" + descripcion+"'";
            if (!ObjCat.EjecutarSentencia(sentencia, false))
            {
                error = ObjCat.Error;
                ObjCat = null;
                return false;
            }
            else
            {
                error = "Se guardó exitosamente";
                ObjCat = null;
                return true;
            }
        }
        public bool ActualizarCategoria()
        {
            ClsConexion ObjCat = new ClsConexion();
            string sentencia = "execute usp_ActualizarCatego '" + codigo + "','" + nombre + "','" + descripcion+"'";
            if (!ObjCat.EjecutarSentencia(sentencia, false))
            {
                error = ObjCat.Error;
                ObjCat = null;
                return false;
            }
            else
            {
                error = "Se actualizó exitosamente";
                ObjCat= null;
                return true;
            }
        }
        public bool ConsultarCategoria()
        {
            ClsConexion ObjCat = new ClsConexion();

            string sentencia = "execute usp_ConsultarCatego '" + codigo + "'";
            if (!ObjCat.Consultar(sentencia, false))
            {
                error = ObjCat.Error;
                ObjCat = null;
                return false;
            }
            else
            {
                reader = ObjCat.Reader;
                ObjCat = null;
                return true;
            }



        }
        public bool ListarCategoria(DataGridView ObjCat)
        {
            ClsLlenarGrid ObjG = new ClsLlenarGrid();
            ObjG.NombreTabla= "DatosCatego";
            ObjG.SQL = "execute usp_ListarCatego";

            if (!ObjG.LlenarGrid(ObjCat))
            {
                error = ObjG.Error;
                ObjCat = null;
                return false;
            }
            else
            {
                ObjCat = null;
                return true;
            }



            #endregion
        }
    }
}