using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restClient
{
    public partial class productsForm : Form
    {
        public productsForm()
        {
            InitializeComponent();
            loadDataProducts();
        }

        int selectedRow;

        productsClass productFocused = new productsClass();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void loadDataProducts()
        {
            try
            {
                string job = "products";
                RestClient restClient = new RestClient();
                string strResponse = string.Empty;
                strResponse = await restClient.getRequest(job);
                dynamic myObject = JsonConvert.DeserializeObject(strResponse);
                productsDataGridView.DataSource = myObject;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                RestClient restClient = new RestClient();
                restClient.productPostRequest(nameTextBox.Text, priceTextBox.Text);
                loadDataProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ServicesForm f = new ServicesForm();
                f.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                RestClient restClient = new RestClient();
                restClient.productUpdateRequest(productFocused.id, nameTextBox.Text, priceTextBox.Text);
                loadDataProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                RestClient restClient = new RestClient();
                restClient.productDeleteRequest(productFocused.id);
                loadDataProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        private void productsDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;

                DataGridViewRow row = productsDataGridView.Rows[selectedRow];
                //Console.WriteLine(row.Cells[0].Value.ToString());
                nameTextBox.Text = row.Cells[1].Value.ToString();
                priceTextBox.Text = row.Cells[2].Value.ToString();
                productFocused.id = row.Cells[0].Value.ToString();
                productFocused.name = row.Cells[0].Value.ToString();
                productFocused.price = row.Cells[0].Value.ToString();

    }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            };
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                loadDataProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
