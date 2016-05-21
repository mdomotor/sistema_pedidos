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
    public partial class frmMovProdutos : Form
    {
        public frmMovProdutos()
        {
            InitializeComponent();
        }

        private void saveData()
        {
            ProductChange.create(operation: tOperation.Text, date: tDate.Text, product: cmbProduct.SelectedItem, productClass: tProduct.Text, opType: cmbOpType.SelectedItem.ToString(), qtt: Convert.ToInt32(tQtt.Text));
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            saveData();
            clearAll();
        }

        private void clearAll()
        {
            tOperation.Clear();
            tDate.Clear();
            cmbProduct.SelectedIndex = -1;
            cmbOpType.SelectedIndex = -1;
            tQtt.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
