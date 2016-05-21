using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDePedidos
{
    public partial class ConsultaGrid : Form
    {
        public ConsultaGrid()
        {
            InitializeComponent();
        }

        private void ConsultaGrid_Load(object sender, EventArgs e)
        {
            createGridAndFill();
        }

        private void createGridAndFill()
        {
            createGrid();
            fillGrid();
        }

        private void createGrid()
        {
            dataGridEstoque.ColumnCount = 4;
            dataGridEstoque.ColumnHeadersVisible = true;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            dataGridEstoque.Columns[0].Name = "Código Produto";
            dataGridEstoque.Columns[1].Name = "Descrição";
            dataGridEstoque.Columns[2].Name = "Estoque Atual";
            dataGridEstoque.Columns[3].Name = "Estoque Mínimo";
        }

        private void fillGrid()
        {
            foreach (Product prod in products)
            {
                dataGridEstoque.Rows.Add(prod.code, prod.description, prod.stock);
            }
        }

        private Product[] products = Product.all();

        private int totalRow = Product.count();
    }
}
