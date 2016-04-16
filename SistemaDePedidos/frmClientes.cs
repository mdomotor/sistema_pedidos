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
    public partial class frmClientes : Form
    {
        enum OperationMode
        {
            Navigation,
            Edition
        }

        public frmClientes()
        {
            InitializeComponent();
        }

        private void operationMode(OperationMode mode)
        {
            switch (mode)
            {
                case OperationMode.Navigation:
                    btnOk.Enabled = false;
                    btnCancel.Enabled = false;
                    btnFirst.Enabled = true;
                    btnPrev.Enabled = true;
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                    btnNew.Enabled = true;
                    btnDel.Enabled = true;
                    btnAlter.Enabled = true;
                    break;

                case OperationMode.Edition:
                    btnOk.Enabled = true;
                    btnCancel.Enabled = true;
                    btnFirst.Enabled = false;
                    btnPrev.Enabled = false;
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                    btnNew.Enabled = false;
                    btnDel.Enabled = false;
                    btnAlter.Enabled = false;
                    break;
            }
            
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            operationMode(OperationMode.Navigation);
        }
    }
}
