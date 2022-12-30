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
    public partial class Spares : Form
    {
        Functions Con;
        public Spares()
        {
            InitializeComponent();
            Con = new Functions();
            ShowSpares();
        }
        private void ShowSpares()
        {
            string Query = "select * from SpareTb1";
            PartsList.DataSource = Con.GetData(Query);
        }

        private void Clear()
        {
            PartNameTb.Text = "";
            PartCostTb.Text = "";
            Key = 0;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PartNameTb.Text == "" || PartCostTb.Text == "")
            {
                MessageBox.Show("MissingData!!");
            }
            else
            {
                try
                {
                    string PName = PartNameTb.Text;
                    int Cost = Convert.ToInt32(PartCostTb.Text);
                    string Query = "insert into SpareTb1 values('{0}',{1})";
                    Query = string.Format(Query, PName, Cost);
                    Con.SetData(Query);
                    MessageBox.Show("Customer Added!");
                    ShowSpares();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key = 0;
        private void PartsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PartNameTb.Text = PartsList.SelectedRows[0].Cells[1].Value.ToString();
            PartCostTb.Text = PartsList.SelectedRows[0].Cells[2].Value.ToString();
            if (PartNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(PartsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (PartNameTb.Text == "" || PartCostTb.Text == "")
            {
                MessageBox.Show("MissingData!!");
            }
            else
            {
                try
                {
                    string PName = PartNameTb.Text;
                    int Cost = Convert.ToInt32(PartCostTb.Text);
                    string Query = "Update SpareTb1 set SpName = '{0}',SpCost = {1} where SpCode = {2}";
                    Query = string.Format(Query, PName, Cost,Key);
                    Con.SetData(Query);
                    MessageBox.Show("Customer Updated!");
                    ShowSpares();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string PName = PartNameTb.Text;
                    int Cost = Convert.ToInt32(PartCostTb.Text);
                    string Query = "delete from SpareTb1 where SpCode = {0}";
                    Query = string.Format(Query,Key);
                    Con.SetData(Query);
                    MessageBox.Show("Customer Deleted!");
                    ShowSpares();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
