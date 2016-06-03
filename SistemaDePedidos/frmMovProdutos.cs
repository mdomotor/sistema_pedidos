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
            Product product = Product.findByDescription(cmbProduct.SelectedItem.ToString());


            ProductChange.create(operation: tOperation.Text, 
                                 date: tDate.Text, 
                                 product: product,
                                 opType: cmbOpType.SelectedItem.ToString(), 
                                 qtt: Convert.ToInt32(tQtt.Text)
                                );
            
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

        private void frmMovProdutos_Load(object sender, EventArgs e)
        {
            Product[] products = Product.all();

            foreach (Product product in products) {
                cmbProduct.Items.Add(product.description);
            }

            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
