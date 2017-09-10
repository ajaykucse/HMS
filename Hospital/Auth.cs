using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BO;

namespace Hospital
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
           
        }
        RegistrationInfo regInfo = new RegistrationInfo();
        Operation opr = new Operation();
        DataTable dt = new DataTable();
        private void okbtn_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
           
            if (usrModCombox.Text == "Pharmacist")
            {
                regInfo.UserId = textBox1.Text;
                regInfo.Pass = textBox2.Text;
                regInfo.Role = usrModCombox.Text;
                regInfo.Status = false;
                dt = opr.loginPharmacist(regInfo);

                if (dt.Rows.Count > 0)
                {
                    this.Hide();
                    MedicineStore mds = new MedicineStore();
                    mds.Show();
                }
                else { MessageBox.Show("You Are Not Registered!or verify at contact with admin or Create a new account & try again"); }
            }
            else if (usrModCombox.Text == "Bill Cashier")
            {
                    regInfo.Role = usrModCombox.Text;
                    regInfo.UserId = textBox1.Text;
                    regInfo.Pass = textBox2.Text;
                    regInfo.Status = false;
                    dt = opr.loginBillCashier(regInfo);

                    if (dt.Rows.Count > 0)
                    {
                        this.Hide();
                        AppointmentFrm apptfrm = new AppointmentFrm(regInfo.UserId,regInfo.Name);
                        apptfrm.Show();
                    }
                    else { MessageBox.Show("You Are Not Registered!or verify at contact with admin or Create a new account & try again"); }
            }
            else if (usrModCombox.Text == "Doctor")
            {
                regInfo.UserId = textBox1.Text;
                regInfo.Pass = textBox2.Text;
                regInfo.Role = usrModCombox.Text;
                regInfo.Status = false;
                dt = opr.loginDoctor(regInfo);

                if (dt.Rows.Count > 0)
                {
                    this.Hide();
                    MedicineStore mds = new MedicineStore();
                    mds.Show();
                }
                else { MessageBox.Show("You Are Not Registered!or verify at contact with admin or Create a new account & try again"); }
            }
            else if (usrModCombox.Text == "Lab Assistant")
            {
                regInfo.UserId = textBox1.Text;
                regInfo.Pass = textBox2.Text;
                regInfo.Role = usrModCombox.Text;
                regInfo.Status = false;
                dt = opr.loginLabAssis(regInfo);

                if (dt.Rows.Count > 0)
                {
                    this.Hide();
                    MedicineStore mds = new MedicineStore();
                    mds.Show();
                }
                else { MessageBox.Show("You Are Not Registered!or verify at contact with admin or Create a new account & try again"); }
            }
            else { MessageBox.Show("Admin"); }







            







            //if (usrModCombox.Text =="Pharmacy"  && textBox1.Text == "a" && textBox2.Text == "a")
            //{
            //    this.Hide();
            //    MedicineStore mds = new MedicineStore();
            //    mds.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Wrong User ID Or Password");
            //    textBox1.Focus();
            //}
        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!textBox2.AcceptsReturn)
                {
                    button1.PerformClick();
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!textBox1.AcceptsReturn)
                {
                    button1.PerformClick();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationFrm regFrm = new RegistrationFrm();
            regFrm.Show();
            this.Hide();
        }
    }
}
