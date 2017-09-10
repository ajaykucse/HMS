using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BO;
using DALL;

namespace Hospital
{
    public partial class AppointmentFrm : Form
    {
        string billCashierId = "";
        public AppointmentFrm(string billCashierId, string Name)
        {
            InitializeComponent();
            this.billCashierId = billCashierId;
            //this.Name = Name;
            label31.Text = Name;
        }

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True");

     
        AppointmentInfo AppointInfo = new AppointmentInfo();
        Operation opr = new Operation();

        public void FillComboBillNo()
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " SELECT * FROM  AppointmentTbl";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox4.Items.Add(dr["AppoinmentId"].ToString());
                }
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void FillComboDoctroName()
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " SELECT * FROM  DoctorTbl";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox6.Items.Add(dr["Name"].ToString());
                }
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Auth frm1 = new Auth();
            frm1.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Name is empty");
                textBox1.Focus();
            }
            else if(textBox2.Text=="")
            {
                MessageBox.Show("Address is empty");
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Age is empty");
                textBox3.Focus();
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Fill the Sex Type");
                comboBox1.Focus();
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Weight is empty");
                textBox4.Focus();
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Contact is empty");
                textBox5.Focus();
            }
            else if (dateTimePicker1.Text == "")
            {
                MessageBox.Show("Select date & time");
                dateTimePicker1.Focus();
            }
            else
            {
                AppointInfo.Name = textBox1.Text;
                AppointInfo.Address = textBox2.Text;
                AppointInfo.Age = (textBox3.Text);
                AppointInfo.Sex = comboBox1.Text;
                AppointInfo.Weight = textBox4.Text;
                AppointInfo.AppointmentDate = dateTimePicker1.Text;
                AppointInfo.PatientOfCase = comboBox2.Text;
                AppointInfo.DiseaseType = textBox5.Text;
                AppointInfo.Description = textBox6.Text;
                AppointInfo.ContactNo = textBox7.Text;
                AppointInfo.Amount = comboBox3.Text;

                int rows = opr.patientEntryInfo(AppointInfo);
                if (rows > 0)
                {
                    textBox1.Text = "";
                    textBox2.Text="";
                    textBox3.Text = "";
                    comboBox1.Text = "";
                    textBox4.Text = "";
                    comboBox2.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    comboBox3.Text = "";
                    MessageBox.Show("Information save Successfully");
                    dataGridView1.DataSource = opr.patientEntryload(AppointInfo);
                    dataGridView2.DataSource = opr.patientEntryload(AppointInfo);
                    dataGridView3.DataSource = opr.patientEntryload(AppointInfo);
                    dataGridView4.DataSource = opr.patientEntryload(AppointInfo);
                }
            }
           

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);
        }

        private void addToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage4);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage3);
        }

        private void billPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
        //Bitmap bmp;
        private void button2_Click(object sender, EventArgs e)
        {
            //Graphics g = this.CreateGraphics();
            //bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            //Graphics mg = Graphics.FromImage(bmp);
            //mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            //printPreviewDialog1.ShowDialog();

            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
             
            //PrintDialog dlg = new PrintDialog();
            //dlg.ShowDialog();
            //PrintPreviewDialog ppd = new PrintPreviewDialog();
            //PrintDocument1 Pd = new PrintDocument1();
            //PrinterSettings PrinterSetting = new PrinterSettings();
            //Pd.PrinterSettings.PrinterName = "Eltron P310 Card Printer";
            //Pd.PrinterSettings.Copies = 1;
            //Pd.PrinterSettings.DefaultPageSettings.Landscape = true;
 
            //Pd.PrintPage += printDocument1_PrintPage;
            //ppd.Document = Pd;
            //ppd.ShowDialog();
        }

        private void AppointmentFrm_Load(object sender, EventArgs e)
        {
           FillComboDoctroName();
           FillComboBillNo();
           DataTable dt = new DataTable();
           dt = opr.patientEntryload(AppointInfo);
           dataGridView1.DataSource = dt;
           dataGridView2.DataSource = dt;
           dataGridView3.DataSource = dt;
           dataGridView4.DataSource = dt;
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " SELECT * FROM  AppointmentTbl WHERE AppoinmentId = '" + comboBox4.SelectedItem.ToString() + "'";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    textBox9.Text = dr["Name"].ToString();
                    textBox10.Text = dr["Age"].ToString();
                    comboBox5.Text = dr["Sex"].ToString();
                    dateTimePicker2.Text= dr["AppointmentDate"].ToString();
                     

                    //dataGridView2.SelectionMode = DataGridViewSelectionMode.CellSelect;
                }
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.DrawString(tabPage1.Text,new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
            Bitmap bmp = new Bitmap(groupBox3.ClientRectangle.Width, groupBox3.ClientRectangle.Height);
            groupBox3.DrawToBitmap(bmp, groupBox3.ClientRectangle);
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", textBox8.Text);
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
              DataGridView grid = (DataGridView) sender;

        //Check index 0 because the ComboBox is in that column
        if (grid.SelectedCells[0].OwningRow.Cells[0].Value != null)
        {
            
        }
        else
        {
             
        }
    }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
             
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
             
              
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "")
            {
                MessageBox.Show("Bill No is empty");
                comboBox4.Focus();
            }
            else if (textBox9.Text == "")
            {
                MessageBox.Show("Name is empty");
                textBox9.Focus();
            }
            else if (textBox10.Text == "")
            {
                MessageBox.Show("Age is empty");
                textBox10.Focus();
            }
            else if (comboBox5.Text == "")
            {
                MessageBox.Show("Select Sex");
                comboBox5.Focus();
            }
            else if (comboBox6.Text == "")
            {
                MessageBox.Show("Assign Doctor");
                comboBox6.Focus();
            }
            else
            {
                string doctorname = comboBox6.Text;
                int doctorID = 0;
                int billCashierID = 0;
                 
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DoctorId FROM DoctorTbl WHERE Name = '" + doctorname + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    doctorID = Convert.ToInt32(dr["DoctorId"].ToString());
                }
                cmd.CommandText = "SELECT BillCashierId FROM BillCashierTbl WHERE UserId = '" + billCashierId + "'";
                cmd.ExecuteNonQuery();
                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    billCashierID = Convert.ToInt32(dr["BillCashierId"].ToString());
                     
                }
                int appointmentID = Convert.ToInt32(comboBox4.Text);
                int rows = opr.AppointmentApprove(billCashierID, doctorID, appointmentID);
                if (rows > 0)
                {
                    MessageBox.Show("Appointment Approved");
                }

                con.Close();
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            (dataGridView4.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", textBox19.Text);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE AppointmentTbl SET Name = '" + textBox15.Text + "', Address ='" + textBox14.Text + "',Age='" + textBox13.Text + "',Sex='" + comboBox7.Text + "',Weight='" + textBox12.Text + "',AppointmentDate='" + dateTimePicker3.Text + "',PatientOfCase= '" + comboBox7.Text + "',DiseaseType='" + textBox17.Text + "',Description='" + textBox16.Text + "',Contactno='" + textBox11.Text +"',Amount='" +comboBox8.Text+ "' WHERE   AppoinmentId = '" + textBox18.Text + "' ; ";
                cmd.ExecuteNonQuery();
                dataGridView1.DataSource = opr.patientEntryload(AppointInfo);
                dataGridView2.DataSource = opr.patientEntryload(AppointInfo);
                dataGridView3.DataSource = opr.patientEntryload(AppointInfo);
                dataGridView4.DataSource = opr.patientEntryload(AppointInfo);
                con.Close();
                MessageBox.Show("Patient Information Updated Successfully");
                textBox15.Text = "";
                textBox14.Text = "";
                textBox13.Text = "";
                textBox12.Text = "";
                textBox11.Text = "";
                textBox16.Text = "";
                textBox17.Text = "";
                textBox18.Text = "";
                comboBox7.Text = "";
                comboBox8.Text = "";
                comboBox9.Text = "";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.CurrentRow.Index != -1)
                {
                    textBox15.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                    textBox14.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
                    textBox13.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
                    comboBox7.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
                    textBox12.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
                    textBox11.Text = dataGridView3.CurrentRow.Cells[10].Value.ToString();
                    comboBox9.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString();
                    textBox17.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString();
                    textBox16.Text = dataGridView3.CurrentRow.Cells[9].Value.ToString();
                    comboBox8.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString();

                    textBox18.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                    
                    textBox18.Focus();
                }

            }
            catch(Exception ex){MessageBox.Show(ex.Message);}
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            (dataGridView3.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", textBox18.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox21.Text == "") { MessageBox.Show("Enter Patient Name That You Want To Delete!"); }
                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM AppointmentTbl WHERE AppoinmentId = '" + textBox21.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    dataGridView1.DataSource = opr.patientEntryload(AppointInfo);
                    dataGridView2.DataSource = opr.patientEntryload(AppointInfo);
                    dataGridView3.DataSource = opr.patientEntryload(AppointInfo);
                    dataGridView4.DataSource = opr.patientEntryload(AppointInfo);
                    MessageBox.Show("Patient Information Delete Successfully");
                    textBox19.Text = "";
                    textBox21.Text = "";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView4_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView4.CurrentRow.Index != -1)
                {
                    

                    textBox19.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                    textBox21.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();

                    textBox19.Focus();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", textBox20.Text);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        }
    }

