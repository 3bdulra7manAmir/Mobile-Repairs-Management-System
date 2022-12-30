using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Repairs_Management_System
{
    public partial class Customers : Form
    {
        Functions Con;
        public Customers()
        {
            InitializeComponent();
            Con = new Functions();
        }

        private void ShowCustomers()
        {
            string Query = "select * from CustomerTb1";
            CustomersList.DataSource = Con.GetData(Query);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
