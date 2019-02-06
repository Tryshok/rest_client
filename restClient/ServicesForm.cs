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
    public partial class ServicesForm : Form
    {
        public ServicesForm()
        {
            InitializeComponent();
        }

        private void Bill_Click(object sender, EventArgs e)
        {
            BillsForm f = new BillsForm();
            f.Show();
            this.Hide();
        }

        private void productsButton_Click(object sender, EventArgs e)
        {
            productsForm f = new productsForm();
            f.Show();
            this.Hide();
        }
    }
}
