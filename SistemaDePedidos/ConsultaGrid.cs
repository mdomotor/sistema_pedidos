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
                int stock = calculateCurrentStock(prod);
                dataGridEstoque.Rows.Add(prod.code, prod.description, stock, prod.stock);
            }
        }

        private int calculateCurrentStock(Product product)
        {
            int stock = 0;

            foreach (ProductChange change in productChanges)
            {
                if (change.product.code == product.code)
                {
                    if (change.opType == "E")
                    {
                        stock += change.qtt;
                    }
                    else
                    {
                        stock -= change.qtt;
                    }
                }
            }

            return stock;
        }

        private Product[] products = Product.all();
        private ProductChange[] productChanges = ProductChange.all();
    }
}
