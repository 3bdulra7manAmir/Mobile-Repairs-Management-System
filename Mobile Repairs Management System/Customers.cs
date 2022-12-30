﻿using System;
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
            ShowCustomers();
        }

        private void ShowCustomers()
        {
            string Query = "select * from CustomerTb1";
            CustomersList.DataSource = Con.GetData(Query);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(CustNameTb.Text == "" || CustPhoneTb.Text == "" || CustAddTb.Text == "")
            {
                MessageBox.Show("MissingData!!");
            }
            else
            {
                try
                {
                    string CName = CustNameTb.Text;
                    string CPhone = CustPhoneTb.Text;
                    string CAdd = CustAddTb.Text;
                    string Query = "insert into CustomerTb1 values('{0}','{1}','{2}')";
                    Query = string.Format(Query, CName, CPhone, CAdd);
                    Con.SetData(Query);
                    MessageBox.Show("Customer Added!");
                    ShowCustomers();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key = 0;
        private void CustomersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustNameTb.Text = CustomersList.SelectedRows[0].Cells[1].Value.ToString();
            CustPhoneTb.Text = CustomersList.SelectedRows[0].Cells[2].Value.ToString();
            CustAddTb.Text = CustomersList.SelectedRows[0].Cells[3].Value.ToString();
            if(CustNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CustomersList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" || CustPhoneTb.Text == "" || CustAddTb.Text == "")
            {
                MessageBox.Show("MissingData!!");
            }
            else
            {
                try
                {
                    string CName = CustNameTb.Text;
                    string CPhone = CustPhoneTb.Text;
                    string CAdd = CustAddTb.Text;
                    string Query = "Update CustomerTb1 set CustName = '{0}',CustPhone = '{1}',CustAdd = '{2}' where CustCode = {3}";
                    Query = string.Format(Query, CName, CPhone, CAdd, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Customer Updated!");
                    ShowCustomers();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
