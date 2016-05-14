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
        private Client[] clients = Client.all();
        private int totalRow = Client.count();
        private int currentClient { get; set; }
        private OperationMode operationControl { get; set; }

        enum OperationMode
        {
            Navigation,
            Edition,
            Update,
            Create
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
                    tCode.Enabled = false;
                    tCompanyName.Enabled = false;
                    tCnpj.Enabled = false;
                    tAddress.Enabled = false;
                    tCity.Enabled = false;
                    cmbState.Enabled = false;
                    tZipcode.Enabled = false;
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
                    tCode.Enabled = true;
                    tCompanyName.Enabled = true;
                    tCnpj.Enabled = true;
                    tAddress.Enabled = true;
                    tCity.Enabled = true;
                    cmbState.Enabled = true;
                    tZipcode.Enabled = true;
                    break;
            }

        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            currentClient = 0;
            operationMode(OperationMode.Navigation);
            showData(currentClient);
        }

        private void showData(int row)
        {
            Client client = clients[row];

            tCode.Text = client.code.ToString();
            tCompanyName.Text = client.companyName;
            tCnpj.Text = client.cnpj;
            tAddress.Text = client.address;
            tCity.Text = client.city;
            cmbState.SelectedItem = client.state;
            tZipcode.Text = client.zipcode;
        }

        private void saveData()
        {
            Client.create(code: tCode.Text, companyName: tCompanyName.Text, cnpj: tCnpj.Text, address: tAddress.Text, city: tCity.Text, state: cmbState.SelectedItem.ToString(), zipcode: tZipcode.Text);
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentClient < totalRow - 1)
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
            currentClient = totalRow - 1;
            showData(currentClient);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            operationMode(OperationMode.Edition);
            operationControl = OperationMode.Create;
            clearAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            operationMode(OperationMode.Navigation);
            if (totalRow == 0) clearAll();
            else showData(currentClient);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (operationControl == OperationMode.Create)
            {
                saveData();
                totalRow = Client.count();
                clients = Client.all();
                currentClient = totalRow - 1;
                showData(currentClient);
            }
            else if (operationControl == OperationMode.Update)
            {
                updateData(currentClient);
                clients = Client.all();
            }

            operationMode(OperationMode.Navigation);
            
        }

        private void updateData(int row)
        {
            Client client = new Client();
            client.code = tCode.Text;
            client.companyName = tCompanyName.Text;
            client.cnpj = tCnpj.Text;
            client.address = tAddress.Text;
            client.city = tCity.Text;
            client.state = cmbState.SelectedItem.ToString();
            client.zipcode = tZipcode.Text;

            Client.update(row, client);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Client.delete(clients[currentClient].code);
            clients = Client.all();
            currentClient = totalRow = Client.count();

            if (totalRow == 0)
            {
                clearAll();
            }
            else
            {
                --currentClient;
                showData(currentClient);
            }
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            operationMode(OperationMode.Edition);
            operationControl = OperationMode.Update;
        }

        private void clearAll()
        {
            tCode.Clear();
            tCompanyName.Clear();
            tCnpj.Clear();
            tAddress.Clear();
            tCity.Clear();
            cmbState.SelectedIndex = -1;
            tZipcode.Clear();
            tCode.Focus();
        }
    }
}
