using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDePedidos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool formFound = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f is frmClientes)
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }

                    f.Focus();
                    formFound = true;
                }
            }

            if (!formFound)
            {
                frmClientes formCliente = new frmClientes();
                formCliente.MdiParent = this;
                formCliente.Show();
            }
            
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
