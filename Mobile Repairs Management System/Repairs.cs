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
            if (CustCb.SelectedIndex == -1 || PhoneTb.Text == "" || DNameTb.Text == "" || ModelTb.Text == "" || ProblemTb.Text == "" || SpareCb.SelectedIndex == -1 || SpareCostTb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("MissingData!!");
            }
            else
            {
                try
                {
                    string RDate = RepDateTb.Value.Date.ToString();
                    int Customer = Convert.ToInt32(CustCb.SelectedValue.ToString());
                    string CPhone = PhoneTb.Text;
                    string DeviceName = DNameTb.Text;
                    string DeviceModel = ModelTb.Text;
                    string Problem = ProblemTb.Text;
                    int Spare = Convert.ToInt32(PhoneTb.Text);
                    int Total = Convert.ToInt32(TotalTb.Text);
                    string Query = "insert into RepairTb1 values('{0}',{1},'{2}','{3}','{4}','{5}',{6},{7})";
                    Query = string.Format(Query, RDate, Customer, CPhone, DeviceName, DeviceModel, Problem, Spare, Total);
                    Con.SetData(Query);
                    MessageBox.Show("Repair Added!");
                    ShowRepairs();
                    //Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
