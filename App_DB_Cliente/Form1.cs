using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_DB_Cliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    
        private void cLIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 childForm = new Form2(); // El formulario hijo
            childForm.MdiParent = this; // El formulario hijo bajo el control de formulario padre MDI
            childForm.Show();
        }

        private void vENDEDORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 childForm = new Form3(); // El formulario hijo
            childForm.MdiParent = this; // El formulario hijo bajo el control de formulario padre MDI
            childForm.Show();
        }

        private void pRODUCTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 childForm = new Form4(); // El formulario hijo
            childForm.MdiParent = this; // El formulario hijo bajo el control de formulario padre MDI
            childForm.Show();
        }

        private void oPCIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void cATEGORIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 childForm = new Form5(); // El formulario hijo
            childForm.MdiParent = this; // El formulario hijo bajo el control de formulario padre MDI
            childForm.Show();
        }
    }
}
