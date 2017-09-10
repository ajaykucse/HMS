using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

using System.Windows.Forms;
using BO;
using DALL;

namespace Hospital
{
    public partial class MedicineStore : Form
    {
         
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True");
       

        PharmacyStoreInfo mdinfo = new PharmacyStoreInfo();
        Operation opr = new Operation();
        public MedicineStore()
        {
             
            InitializeComponent();

            
            
        }

        DataTable dt = new DataTable();
         
        private void savebtn_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
        }

        private void MedicineStore_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = opr.ViewMedicineInfo(mdinfo);
            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = dt;
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from PharmacyTbl where  MedicineName='" + textBox8.Text + "'";
            cmd.ExecuteNonQuery();
             

            con.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

            

        }


        public void searchData(string vlaueToFind) 
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Auth frm1 = new Auth();
            frm1.Show();
        }

        private void savebtn_Click_1(object sender, EventArgs e)
        {
            

            if (textBox1.Text == "")
            {
                MessageBox.Show("Invoice Number is Empty");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Medicine Name is Empty");
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Details is Empty");
                textBox3.Focus();
            }

            else if (textBox4.Text == "")
            {
                MessageBox.Show("Company Name is Empty");
                textBox4.Focus();
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Quantity is Empty");
                textBox5.Focus();
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Unit Price is Empty");
                textBox6.Focus();
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("Location Address is Empty");
                textBox7.Focus();
            }
            else
            {

                mdinfo.InvoiceN = Convert.ToInt32(textBox1.Text);
                mdinfo.MedicineName = textBox2.Text;
                
                mdinfo.Details = textBox3.Text;
                mdinfo.CompanyName = textBox4.Text;
                mdinfo.Quantity = textBox5.Text;
                mdinfo.UnitPrice = textBox6.Text;
                mdinfo.LocationAddress = textBox7.Text;
                mdinfo.EntryDate = dateTimePicker1.Text;
                mdinfo.MfgDate = dateTimePicker2.Text;
                mdinfo.ExpireDate = dateTimePicker3.Text;



                int rows = opr.insertmdInfo(mdinfo);
                if (rows > 0)
                {
                    MessageBox.Show("Data save Successfully");
                }

                dataGridView1.DataSource = opr.ViewMedicineInfo(mdinfo);
                dataGridView2.DataSource = opr.ViewMedicineInfo(mdinfo);

                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
                textBox7.Text = null;
                textBox9.Text = null;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE PharmacyTbl SET InvoiceN = '" + textBox1.Text + "', MedicineName='" + textBox2.Text + "',Details='" + textBox3.Text + "',CompanyName='" + textBox4.Text + "',Quantity='" + textBox5.Text + "',UnitePrice='" + textBox6.Text + "',LocationAddress= '" + textBox7.Text + "',EntryDate='" + dateTimePicker1.Text + "',MfgDate='" + dateTimePicker2.Text + "',ExpireDate='" + dateTimePicker3.Text + "' WHERE   PharmacyId = '" + textBox9.Text + "' ; ";
                cmd.ExecuteNonQuery();
                dataGridView1.DataSource = opr.ViewMedicineInfo(mdinfo);
                con.Close();
                MessageBox.Show("Medicine Information Updated Successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox9.Text == "") { MessageBox.Show("Enter Medicine Name That You Want To Delete!"); }
                else
                    con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM PharmacyTbl WHERE PharmacyId = '" + textBox9.Text + "'";
                cmd.ExecuteNonQuery();
                dataGridView1.DataSource = opr.ViewMedicineInfo(mdinfo);
                con.Close();
                MessageBox.Show("Medicine Information Delete Successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                textBox8.Text = "";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView1.CurrentRow.Index != -1)
                {
                    textBox9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();



                    textBox7.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    textBox8.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    //savebtn.Text = "Update";
                    //button2.Enabled = true;
                    textBox8.Focus();
                }
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("MedicineName LIKE '%{0}%'", textBox8.Text);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            { textBox11.Visible = false;
            comboBox1.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
           if (radioButton2.Checked)
           { 
               textBox11.Visible = true;
               comboBox1.Visible = true;
           }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = string.Format("MedicineName LIKE '%{0}%'", textBox12.Text);
        }
 
    }
}
