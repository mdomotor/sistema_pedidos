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

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool formFound = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f is dataGrid)
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
                dataGrid formCliente = new dataGrid();
                formCliente.MdiParent = this;
                formCliente.Show();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool formFound = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f is frmMovProdutos)
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
                frmMovProdutos formCliente = new frmMovProdutos();
                formCliente.MdiParent = this;
                formCliente.Show();
            }
        }

        private void consultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool formFound = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f is ConsultaGrid)
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
                ConsultaGrid formCliente = new ConsultaGrid();
                formCliente.MdiParent = this;
                formCliente.Show();
            }
        }
    }
}
