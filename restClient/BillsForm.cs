using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace restClient
{
    public partial class BillsForm : Form
    {
        public BillsForm()
        {
            InitializeComponent();
            loadDataBills();
        }
        #region UI Event Handlers

        DataTable table = new DataTable();

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void loadDataBills()
        {
            string job = "bills";
            RestClient restClient = new RestClient();
            await restClient.getRequest(job);
            string strResponse = string.Empty;

            strResponse = await restClient.getRequest(job);

            //Using dynamic keyword with JsonConvert.DeserializeObject, here you need to import Newtonsoft.Json  
            dynamic myObject = JsonConvert.DeserializeObject(strResponse);

            //Binding gridview from dynamic object   
            dataGridBills.DataSource = myObject;
        }

        #endregion
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textResponse_TextChanged(object sender, EventArgs e)
        {

        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            RestClient restClient = new RestClient();
            //restClient.productPostRequest(descriptionTextBox.Text, descriptionTextBox.Text);
            //restClient.billsPostRequest(descriptionTextBox.Text, clientTextBox.Text, productsTextBox.Text);
            string job = "bills";
            await restClient.getRequest(job);
        }

        private void productsTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
