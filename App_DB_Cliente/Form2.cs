using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib_Cliente;

namespace App_DB_Cliente
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listar();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente ObjClien = new Cliente();
            try
            {
                string identificacion, nombre, apellido, direccion, telefono;

                identificacion = txtidentificacion.Text;
                nombre = txtnombre.Text;
                apellido = txtapellido.Text;
                direccion = txtdireccion.Text;
                telefono = txttelefono.Text;

                //Enviar DATOS a la LOGICA DE NEGOCIO

                ObjClien.Identificacion = identificacion;
                ObjClien.Nombre = nombre;
                ObjClien.Apellido = apellido;
                ObjClien.Direccion = direccion;
                ObjClien.Telefono = telefono;

                if (!ObjClien.InsertarCliente())
                {
                    MessageBox.Show(ObjClien.Error);
                    ObjClien = null;
                    return;
                }
                else
                {
                    MessageBox.Show(ObjClien.Error);
                    ObjClien = null;
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            Cliente ObjClien = new Cliente();
            try
            {
                string identificacion, nombre, apellido, direccion, telefono;

                identificacion = txtidentificacion.Text;
                nombre = txtnombre.Text;
                apellido = txtapellido.Text;
                direccion = txtdireccion.Text;
                telefono = txttelefono.Text;

                //Enviar DATOS a la LOGICA DE NEGOCIO

                ObjClien.Identificacion = identificacion;
                ObjClien.Nombre = nombre;
                ObjClien.Apellido = apellido;
                ObjClien.Direccion = direccion;
                ObjClien.Telefono = telefono;


                if (!ObjClien.ActualizarCliente())
                {
                    MessageBox.Show(ObjClien.Error);
                    ObjClien = null;
                    return;
                }
                else
                {
                    MessageBox.Show(ObjClien.Error);
                    ObjClien = null;
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

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Cliente ObjClien = new Cliente();
            try
            {
                string identificacion;
                identificacion = txtidentificacion.Text;

                //Enviar DATOS a la LOGICA DE NEGOCIO

                ObjClien.Identificacion = identificacion;

                if (!ObjClien.EliminarCliente())
                {
                    MessageBox.Show(ObjClien.Error);
                    ObjClien = null;
                    return;
                }
                else
                {
                    MessageBox.Show(ObjClien.Error);
                    ObjClien = null;
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

        private void btnconsultar_Click(object sender, EventArgs e)
        {
            Cliente ObjClien = new Cliente();
            try
            {
                string identificacion;
                SqlDataReader reader;
                identificacion = txtidentificacion.Text;

                //Enviar DATOS a la LOGICA DE NEGOCIO

                ObjClien.Identificacion = identificacion;

                if (!ObjClien.ConsultarCliente())
                {
                    MessageBox.Show(ObjClien.Error);
                    ObjClien = null;
                    return;
                }
                else
                {
                    reader = ObjClien.Reader;
                    if (reader.HasRows)
                    {
                        reader.Read();
                        txtnombre.Text = reader.GetString(1);
                        txtapellido.Text = reader.GetString(2);
                        txtdireccion.Text = reader.GetString(3);
                        txttelefono.Text = reader.GetString(4);
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
        private void listar()
        {
            Cliente ObjClien = new Cliente();
            if (!ObjClien.ListarCliente(DGVdatos))
            {
                MessageBox.Show(ObjClien.Error);
                return;
            }
        }
        private void btnlistar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void txtidentificacion_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
