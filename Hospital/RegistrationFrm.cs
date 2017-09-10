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
    public partial class RegistrationFrm : Form
    {
        public RegistrationFrm()
        {
            InitializeComponent();
            wclbl.Visible = false;
            button2.Visible = false;
        }
        RegistrationInfo reginfo = new RegistrationInfo();
        Operation opr = new Operation();
        private void RegistrationFrm_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        string Users = "";
        private void button1_Click_1(object sender, EventArgs e)
        {
            Users = comboBox1.Text;
            if (Users == "Bill Cashier")
            {
                BillCashierRegistation();
            }
            else if (Users == "Doctor")
            {
                DoctorRegistrationInfo();
            }
            else if (Users == "Pharmacist")
            {
                PharmacistRegInfo();
            }
            else if (Users == "Lab Assistant")
            {
                LabAssistRegInfo();
            }
            else { MessageBox.Show("there is no option"); }
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void BillCashierRegistation()
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please Select Your User Role");
                comboBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("User Id Field is Empty");
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Password is Empty");
                textBox3.Focus();
            }

            else if (textBox1.Text == "")
            {
                MessageBox.Show("Name is Empty");
                textBox1.Focus();
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Age is Empty");
                textBox4.Focus();
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Sex is Empty");
                comboBox2.Focus();
            }
            else if (comboBox3.Text == "")
            {
                MessageBox.Show("Marital Status is Empty");
                comboBox3.Focus();
            }
            else if (comboBox4.Text == "")
            {
                MessageBox.Show("Religion is Empty");
                comboBox4.Focus();
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Occupation is Empty");
                textBox5.Focus();
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Qualification is Empty");
                textBox6.Focus();
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("Permanent Address is Empty");
                textBox7.Focus();
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("Temporay Address is Empty");
                textBox8.Focus();
            }
            else if (textBox9.Text == "")
            {
                MessageBox.Show("Contact No is Empty");
                textBox9.Focus();
            }
            else if (textBox10.Text == "")
            {
                MessageBox.Show("Email_Id is Empty");
                textBox10.Focus();
            }
            else
            {
                reginfo.Role = comboBox1.Text;
                reginfo.UserId = textBox2.Text;
                reginfo.Pass = textBox3.Text;
                reginfo.Name = textBox1.Text;
                reginfo.Age = textBox4.Text;
                reginfo.Sex = comboBox2.Text;
                reginfo.Mstatus = comboBox3.Text;
                reginfo.Religion = comboBox4.Text;
                reginfo.Occupation = textBox5.Text;
                reginfo.Qualification = textBox6.Text;
                reginfo.Paddress = textBox7.Text;
                reginfo.Taddress = textBox8.Text;
                reginfo.ContacN = textBox9.Text;
                reginfo.Email = textBox10.Text;

                int rows = opr.insertRegistrationInfoBcashier(reginfo);
                if (rows > 0)
                {
                    wclbl.Visible = true;
                    button2.Visible = true;
                    button1.Visible = false;
                    wclbl.Text = "Congratulation your registration is successful!!!";
                }

            }
          }
        public void DoctorRegistrationInfo()
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please Select Your User Role");
                comboBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("User Id Field is Empty");
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Password is Empty");
                textBox3.Focus();
            }

            else if (textBox1.Text == "")
            {
                MessageBox.Show("Name is Empty");
                textBox1.Focus();
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Age is Empty");
                textBox4.Focus();
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Sex is Empty");
                comboBox2.Focus();
            }
            else if (comboBox3.Text == "")
            {
                MessageBox.Show("Marital Status is Empty");
                comboBox3.Focus();
            }
            else if (comboBox4.Text == "")
            {
                MessageBox.Show("Religion is Empty");
                comboBox4.Focus();
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Occupation is Empty");
                textBox5.Focus();
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Qualification is Empty");
                textBox6.Focus();
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("Permanent Address is Empty");
                textBox7.Focus();
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("Temporay Address is Empty");
                textBox8.Focus();
            }
            else if (textBox9.Text == "")
            {
                MessageBox.Show("Contact No is Empty");
                textBox9.Focus();
            }
            else if (textBox10.Text == "")
            {
                MessageBox.Show("Email_Id is Empty");
                textBox10.Focus();
            }
            else
            {
                reginfo.Role = comboBox1.Text;
                reginfo.UserId = textBox2.Text;
                reginfo.Pass = textBox3.Text;
                reginfo.Name = textBox1.Text;
                reginfo.Age = textBox4.Text;
                reginfo.Sex = comboBox2.Text;
                reginfo.Mstatus = comboBox3.Text;
                reginfo.Religion = comboBox4.Text;
                reginfo.Occupation = textBox5.Text;
                reginfo.Qualification = textBox6.Text;
                reginfo.Paddress = textBox7.Text;
                reginfo.Taddress = textBox8.Text;
                reginfo.ContacN = textBox9.Text;
                reginfo.Email = textBox10.Text;

                int rows = opr.insertRegistrationInfoDoctor(reginfo);
                if (rows > 0)
                {
                    wclbl.Visible = true;
                    button2.Visible = true;
                    button1.Visible = false;
                    wclbl.Text = "Congratulation your registration is successful!!!";    
                }

               }
            }
            public void LabAssistRegInfo()
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Please Select Your User Role");
                    comboBox1.Focus();
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("User Id Field is Empty");
                    textBox2.Focus();
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Password is Empty");
                    textBox3.Focus();
                }

                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Name is Empty");
                    textBox1.Focus();
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Age is Empty");
                    textBox4.Focus();
                }
                else if (comboBox2.Text == "")
                {
                    MessageBox.Show("Sex is Empty");
                    comboBox2.Focus();
                }
                else if (comboBox3.Text == "")
                {
                    MessageBox.Show("Marital Status is Empty");
                    comboBox3.Focus();
                }
                else if (comboBox4.Text == "")
                {
                    MessageBox.Show("Religion is Empty");
                    comboBox4.Focus();
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Occupation is Empty");
                    textBox5.Focus();
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("Qualification is Empty");
                    textBox6.Focus();
                }
                else if (textBox7.Text == "")
                {
                    MessageBox.Show("Permanent Address is Empty");
                    textBox7.Focus();
                }
                else if (textBox8.Text == "")
                {
                    MessageBox.Show("Temporay Address is Empty");
                    textBox8.Focus();
                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("Contact No is Empty");
                    textBox9.Focus();
                }
                else if (textBox10.Text == "")
                {
                    MessageBox.Show("Email_Id is Empty");
                    textBox10.Focus();
                }
                else
                {
                    reginfo.Role = comboBox1.Text;
                    reginfo.UserId = textBox2.Text;
                    reginfo.Pass = textBox3.Text;
                    reginfo.Name = textBox1.Text;
                    reginfo.Age = textBox4.Text;
                    reginfo.Sex = comboBox2.Text;
                    reginfo.Mstatus = comboBox3.Text;
                    reginfo.Religion = comboBox4.Text;
                    reginfo.Occupation = textBox5.Text;
                    reginfo.Qualification = textBox6.Text;
                    reginfo.Paddress = textBox7.Text;
                    reginfo.Taddress = textBox8.Text;
                    reginfo.ContacN = textBox9.Text;
                    reginfo.Email = textBox10.Text;

                    int rows = opr.insertRegistrationInfoLabAssist(reginfo);
                    if (rows > 0)
                    {
                        wclbl.Visible = true;
                        button2.Visible = true;
                        button1.Visible = false;
                        wclbl.Text = "Congratulation your registration is successful!!!";
                    }

                }
            }
            public void PharmacistRegInfo()
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Please Select Your User Role");
                    comboBox1.Focus();
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("User Id Field is Empty");
                    textBox2.Focus();
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Password is Empty");
                    textBox3.Focus();
                }

                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Name is Empty");
                    textBox1.Focus();
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Age is Empty");
                    textBox4.Focus();
                }
                else if (comboBox2.Text == "")
                {
                    MessageBox.Show("Sex is Empty");
                    comboBox2.Focus();
                }
                else if (comboBox3.Text == "")
                {
                    MessageBox.Show("Marital Status is Empty");
                    comboBox3.Focus();
                }
                else if (comboBox4.Text == "")
                {
                    MessageBox.Show("Religion is Empty");
                    comboBox4.Focus();
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Occupation is Empty");
                    textBox5.Focus();
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("Qualification is Empty");
                    textBox6.Focus();
                }
                else if (textBox7.Text == "")
                {
                    MessageBox.Show("Permanent Address is Empty");
                    textBox7.Focus();
                }
                else if (textBox8.Text == "")
                {
                    MessageBox.Show("Temporay Address is Empty");
                    textBox8.Focus();
                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("Contact No is Empty");
                    textBox9.Focus();
                }
                else if (textBox10.Text == "")
                {
                    MessageBox.Show("Email_Id is Empty");
                    textBox10.Focus();
                }
                else
                {
                    reginfo.Role = comboBox1.Text;
                    reginfo.UserId = textBox2.Text;
                    reginfo.Pass = textBox3.Text;
                    reginfo.Name = textBox1.Text;
                    reginfo.Age = textBox4.Text;
                    reginfo.Sex = comboBox2.Text;
                    reginfo.Mstatus = comboBox3.Text;
                    reginfo.Religion = comboBox4.Text;
                    reginfo.Occupation = textBox5.Text;
                    reginfo.Qualification = textBox6.Text;
                    reginfo.Paddress = textBox7.Text;
                    reginfo.Taddress = textBox8.Text;
                    reginfo.ContacN = textBox9.Text;
                    reginfo.Email = textBox10.Text;

                    int rows = opr.insertRegistrationInfoPharmacist(reginfo);
                    if (rows > 0)
                    {
                        wclbl.Visible = true;
                        button2.Visible = true;
                        button1.Visible = false;
                        wclbl.Text = "Congratulation your registration is successful!!!";
                    }

                }
            }

            private void button2_Click(object sender, EventArgs e)
            {
                this.Hide();
                Auth frm1 = new Auth();
                frm1.Show();
            }
        }
    }

