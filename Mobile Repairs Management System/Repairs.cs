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
    public partial class Repairs : Form
    {
        Functions Con;
        public Repairs()
        {
            InitializeComponent();
            Con = new Functions();
            ShowRepairs();
        }

        private void Repairs_Load(object sender, EventArgs e)
        {

        }

        private void ShowRepairs()
        {
            string Query = "select * from RepairTb1";
            RepairsList.DataSource = Con.GetData(Query);
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
