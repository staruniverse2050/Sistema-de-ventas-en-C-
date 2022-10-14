using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib_Vendedor;

namespace App_DB_Cliente
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void DGVdatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            Vendedor ObjVen = new Vendedor();
            try
            {
                string identificacion, nombre, apellido, direccion, telefono, correo;

                identificacion = txtidentificacion.Text;
                nombre = txtnombre.Text;
                apellido = txtapellido.Text;
                direccion = txtdireccion.Text;
                telefono = txttelefono.Text;
                correo = txtcorreo.Text;

                //Enviar DATOS a la LOGICA DE NEGOCIO

                ObjVen.Identificacion = identificacion;
                ObjVen.Nombre = nombre;
                ObjVen.Apellido = apellido;
                ObjVen.Direccion = direccion;
                ObjVen.Telefono = telefono;
                ObjVen.Correo = correo;


                if (!ObjVen.InsertarVendedor())
                {
                    MessageBox.Show(ObjVen.Error);
                    ObjVen = null;
                    return;
                }
                else
                {
                    MessageBox.Show(ObjVen.Error);
                    ObjVen = null;
                    listar();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            Vendedor ObjVen = new Vendedor();
            try
            {
                string identificacion, nombre, apellido, direccion, telefono, correo;

                identificacion = txtidentificacion.Text;
                nombre = txtnombre.Text;
                apellido = txtapellido.Text;
                direccion = txtdireccion.Text;
                telefono = txttelefono.Text;
                correo = txtcorreo.Text;

                //Enviar DATOS a la LOGICA DE NEGOCIO

                ObjVen.Identificacion = identificacion;
                ObjVen.Nombre = nombre;
                ObjVen.Apellido = apellido;
                ObjVen.Direccion = direccion;
                ObjVen.Telefono = telefono;
                ObjVen.Correo = correo;



                if (!ObjVen.ActualizarVendedor())
                {
                    MessageBox.Show(ObjVen.Error);
                    ObjVen = null;
                    return;
                }
                else
                {
                    MessageBox.Show(ObjVen.Error);
                    ObjVen = null;
                    listar();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


      
           
        private void listar()
        {
            Vendedor ObjVen = new Vendedor();
            if (!ObjVen.ListarVendedor(DGVdatos))
            {
                MessageBox.Show(ObjVen.Error);
                return;
            }
        }

        private void btnconsultar_Click_1(object sender, EventArgs e)
        {
            Vendedor ObjVen = new Vendedor();
            try
            {
                string identificacion;
                SqlDataReader reader;
                identificacion = txtidentificacion.Text;

                //Enviar DATOS a la LOGICA DE NEGOCIO

                ObjVen.Identificacion = identificacion;

                if (!ObjVen.ConsultarVendedor())
                {
                    MessageBox.Show(ObjVen.Error);
                    ObjVen = null;
                    return;
                }
                else
                {
                    reader = ObjVen.Reader;
                    if (reader.HasRows)
                    {
                        reader.Read();
                        txtnombre.Text = reader.GetString(1);
                        txtapellido.Text = reader.GetString(2);
                        txtdireccion.Text = reader.GetString(3);
                        txttelefono.Text = reader.GetString(4);
                        txtcorreo.Text = reader.GetString(5);
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            Vendedor ObjVen = new Vendedor();
            try
            {
                string identificacion;
                identificacion = txtidentificacion.Text;

                //Enviar DATOS a la LOGICA DE NEGOCIO

                ObjVen.Identificacion = identificacion;

                if (!ObjVen.EliminarVendedor())
                {
                    MessageBox.Show(ObjVen.Error);
                    ObjVen = null;
                    return;
                }
                else
                {
                    MessageBox.Show(ObjVen.Error);
                    ObjVen = null;
                    listar();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnlistar_Click_1(object sender, EventArgs e)
        {
            listar();

        }
    }
    }


