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
    public partial class dataGrid : Form
    {
        public dataGrid()
        {
            InitializeComponent();
        }

        private void dataGrid_Load(object sender, EventArgs e)
        {
            createGridAndFill();
        }

        private void createGridAndFill() {
            createGrid();
            fillGrid();
        }

        private void createGrid()
        {
            dataGridView.ColumnCount = 7;
            dataGridView.ColumnHeadersVisible = true;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            dataGridView.Columns[0].Name = "Código";
            dataGridView.Columns[1].Name = "Razão Social";
            dataGridView.Columns[2].Name = "CNPJ";
            dataGridView.Columns[3].Name = "Endereço";
            dataGridView.Columns[4].Name = "Cidade";
            dataGridView.Columns[5].Name = "UF";
            dataGridView.Columns[6].Name = "CEP";
        }

        private void fillGrid()
        {
            foreach (Client client in clients) {
                dataGridView.Rows.Add(client.code, client.companyName, client.cnpj, client.address, client.city, client.state, client.zipcode);
            }
        }

        private Client[] clients = Client.all();

        private int totalRow = Client.count();
    }
}
