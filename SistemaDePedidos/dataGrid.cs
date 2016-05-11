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
            totalRow = totalRows();
        }

        private void dataGrid_Load(object sender, EventArgs e)
        {
            loadData();
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
                dataGridView.Rows.Add(client.code, client.companyName, client.cnpj, client.adress, client.city, client.state, client.zipcode);
            }
        }

        private void loadData()
        {
            clients = new Client[totalRow];
            StreamReader sr = new StreamReader("C:\\Users\\40795448805\\Clientes.txt", Encoding.UTF8);
            string row = null;
            Client client;
            int position = 0;

            while ((row = sr.ReadLine()) != null)
            {
                string[] columns = row.Split(';');
                client = new Client();
                client.code = columns[0];
                client.companyName = columns[1];
                client.cnpj = columns[2];
                client.adress = columns[3];
                client.city = columns[4];
                client.state = columns[5];
                client.zipcode = columns[6];

                clients[position] = client;
                position++;
            }

            sr.Close();
        }

        private int totalRows()
        {
            StreamReader sr = new StreamReader("C:\\Users\\40795448805\\Clientes.txt", Encoding.UTF8);
            int count = 0;

            while (sr.ReadLine() != null)
            {
                count++;
            }

            sr.Close();
            return count;
        }

        private Client[] clients { get; set; }

        private int totalRow { get; set; }
    }
}
