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
    public partial class frmClientes : Form
    {
        private Client[] clients { get; set; }
        private int totalRow { get; set; }
        private int currentClient { get; set; }

        enum OperationMode
        {
            Navigation,
            Edition
        }

        public frmClientes()
        {
            InitializeComponent();
            totalRow = totalRows();
            clients = new Client[totalRow];
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
            currentClient = 0;
            operationMode(OperationMode.Navigation);
            loadData();
            showData(currentClient);
        }

        private void loadData()
        {
            StreamReader sr = new StreamReader("C:\\Users\\42566937850\\Clientes.txt", Encoding.UTF7);
	        string row = null;
	        Client client;
            int position = 0;

            while ((row = sr.ReadLine()) != null)
	        {
	            string[] columns = row.Split(';');
                client = new Client();
                client.code = Convert.ToInt32(columns[0]);
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
            StreamReader sr = new StreamReader("C:\\Users\\42566937850\\Clientes.txt", Encoding.UTF7);
            int count=0;
            
            while (sr.ReadLine() != null)
            {
                count++;
            }
            
            sr.Close();
            return count;
        }

        private void showData(int row)
        {
            Client client = clients[row];

            tCode.Text = client.code.ToString();
            tCompanyName.Text = client.companyName;
            tCnpj.Text = client.cnpj;
            tAddress.Text = client.adress;
            tCity.Text = client.city;
            cmbState.SelectedItem = client.state;
            tZipcode.Text = client.zipcode;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentClient < totalRow-1)
            {
                currentClient++;
                showData(currentClient);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentClient > 0)
            {
                currentClient--;
                showData(currentClient);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentClient = 0;
            showData(currentClient);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentClient = totalRow-1;
            showData(currentClient);
        }
    }
}
