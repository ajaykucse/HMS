using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DALL;
using BO;

namespace BO
{
    public class Operation
    {
        
            Connection db = new Connection();
            PharmacyStoreInfo mdinfo = new PharmacyStoreInfo();
            RegistrationInfo regInfoBcashier = new RegistrationInfo();
            RegistrationInfo regInfoDoctor = new RegistrationInfo();
            RegistrationInfo regInfoLabAssis = new RegistrationInfo();
            RegistrationInfo regInfoPharmacist = new RegistrationInfo();
            AppointmentInfo AppointInfo = new AppointmentInfo();

            public int insertmdInfo(PharmacyStoreInfo mdinfo)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO PharmacyTbl (InvoiceN, MedicineName, Details, CompanyName, Quantity, UnitePrice, EntryDate, MfgDate, ExpireDate, LocationAddress) VALUES ('" + mdinfo.InvoiceN + "','" + mdinfo.MedicineName + "','" + mdinfo.Details + "','" + mdinfo.CompanyName + "','" + mdinfo.Quantity + "','" + mdinfo.UnitPrice + "','" + mdinfo.EntryDate+ "','" + mdinfo.MfgDate + "','" + mdinfo.ExpireDate + "','" + mdinfo.LocationAddress + "')";
                return db.EXeNonQuery(cmd);
            }

            public DataTable ViewMedicineInfo(PharmacyStoreInfo mdinfo)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT *FROM PharmacyTbl";
                return db.ExeReader(cmd);
            }

            public int insertRegistrationInfoBcashier(RegistrationInfo regInfoBcashier)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO BillCashierTbl (Role, UserId, Pass, Name, Age, Sex, Mstatus, Religion, Occupation, Qualification, Paddress, Taddress, ContactN,Email, Status) VALUES ('" + regInfoBcashier.Role + "','" + regInfoBcashier.UserId + "','" + regInfoBcashier.Pass + "','" + regInfoBcashier.Name + "','" + regInfoBcashier.Age + "','" + regInfoBcashier.Sex + "','" + regInfoBcashier.Mstatus + "','" + regInfoBcashier.Religion + "','" + regInfoBcashier.Occupation + "','" + regInfoBcashier.Qualification + "','" + regInfoBcashier.Paddress + "','" + regInfoBcashier.Taddress + "','" + regInfoBcashier.ContacN + "','" + regInfoBcashier.Email + "','" + regInfoBcashier.Status + "')";
                cmd.CommandText = "INSERT INTO UsersTbl()";
                return db.EXeNonQuery(cmd);
            }
            public int insertRegistrationInfoDoctor(RegistrationInfo regInfoDoctor)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO DoctorTbl (Role, UserId, Pass, Name, Age, Sex, Mstatus, Religion, Occupation, Qualification, Paddress, Taddress, ContactN,Email, Status) VALUES ('" + regInfoDoctor.Role + "','" + regInfoDoctor.UserId + "','" + regInfoDoctor.Pass + "','" + regInfoDoctor.Name + "','" + regInfoDoctor.Age + "','" + regInfoDoctor.Sex + "','" + regInfoDoctor.Mstatus + "','" + regInfoDoctor.Religion + "','" + regInfoDoctor.Occupation + "','" + regInfoDoctor.Qualification + "','" + regInfoDoctor.Paddress + "','" + regInfoDoctor.Taddress + "','" + regInfoDoctor.ContacN + "','" + regInfoDoctor.Email + "','" + regInfoDoctor.Status + "')";
                return db.EXeNonQuery(cmd);
            }
            public int insertRegistrationInfoLabAssist(RegistrationInfo regInfoLabAssis)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO LabAssisTbl (Role, UserId, Pass, Name, Age, Sex, Mstatus, Religion, Occupation, Qualification, Paddress, Taddress, ContactN,Email, Status) VALUES ('" + regInfoLabAssis.Role + "','" + regInfoLabAssis.UserId + "','" + regInfoLabAssis.Pass + "','" + regInfoLabAssis.Name + "','" + regInfoLabAssis.Age + "','" + regInfoLabAssis.Sex + "','" + regInfoLabAssis.Mstatus + "','" + regInfoLabAssis.Religion + "','" + regInfoLabAssis.Occupation + "','" + regInfoLabAssis.Qualification + "','" + regInfoLabAssis.Paddress + "','" + regInfoLabAssis.Taddress + "','" + regInfoLabAssis.ContacN + "','" + regInfoLabAssis.Email + "','" + regInfoLabAssis.Status + "')";
                return db.EXeNonQuery(cmd);
            }
            public int insertRegistrationInfoPharmacist(RegistrationInfo regInfoPharmacist)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO PharmacistTbl (Role, UserId, Pass, Name, Age, Sex, Mstatus, Religion, Occupation, Qualification, Paddress, Taddress, ContactN,Email, Status) VALUES ('" + regInfoPharmacist.Role + "','" + regInfoPharmacist.UserId + "','" + regInfoPharmacist.Pass + "','" + regInfoPharmacist.Name + "','" + regInfoPharmacist.Age + "','" + regInfoPharmacist.Sex + "','" + regInfoPharmacist.Mstatus + "','" + regInfoPharmacist.Religion + "','" + regInfoPharmacist.Occupation + "','" + regInfoPharmacist.Qualification + "','" + regInfoPharmacist.Paddress + "','" + regInfoPharmacist.Taddress + "','" + regInfoPharmacist.ContacN + "','" + regInfoPharmacist.Email + "','" + regInfoPharmacist.Status + "')";
                return db.EXeNonQuery(cmd);
            }
            public DataTable loginPharmacist(RegistrationInfo regInfo)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " SELECT * FROM PharmacistTbl WHERE UserId ='" + regInfo.UserId + "' and Pass = '" + regInfo.Pass + "' and Role = '" + regInfo.Role + "' and Status ='"+false+ "' ";
                return db.ExeReader(cmd);
            }
            public DataTable loginBillCashier(RegistrationInfo regInfo)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " SELECT * FROM BillCashierTbl WHERE UserId ='" + regInfo.UserId + "' and Pass = '" + regInfo.Pass + "' and Role = '" + regInfo.Role + "' and Status ='"+regInfo.Status+ "'or Name = '"+regInfo.Name+"'";
                return db.ExeReader(cmd);
            }
            public DataTable loginDoctor(RegistrationInfo regInfo)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " SELECT * FROM DoctorTbl WHERE UserId ='" + regInfo.UserId + "' and Pass = '" + regInfo.Pass + "' and Role = '" + regInfo.Role + "'and Status ='" + false + "' ";
                return db.ExeReader(cmd);
            }
            
            public DataTable loginLabAssis(RegistrationInfo regInfo)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " SELECT * FROM LabAssisTbl WHERE UserId ='" + regInfo.UserId + "' and Pass = '" + regInfo.Pass + "' and Role = '" + regInfo.Role +"' and Status ='"+false+ "' ";
                return db.ExeReader(cmd);
            }
            public int patientEntryInfo(AppointmentInfo AppointInfo)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO AppointmentTbl (Name, Address, Age, Sex, Weight, AppointmentDate, PatientofCase, DiseaseType, Description, ContactNo, BillcashierId, DoctorId, Amount,Status) VALUES ('" + AppointInfo.Name + "','" + AppointInfo.Address + "','" + AppointInfo.Age + "','" + AppointInfo.Sex + "','" + AppointInfo.Weight + "','" + AppointInfo.AppointmentDate + "','" + AppointInfo.PatientOfCase + "','" + AppointInfo.DiseaseType + "','" + AppointInfo.Description + "','" + AppointInfo.ContactNo + "','" + AppointInfo.BillcashierId + "','" + AppointInfo.DoctorId + "','" + AppointInfo.Amount + "','" + AppointInfo.Status + "')";
                return db.EXeNonQuery(cmd);
            }
            public int AppointmentApprove(int billCashierID, int doctorID, int appointmentID)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE AppointmentTbl set BillcashierId = '"+billCashierID+"', DoctorId = '"+doctorID+"', Status=1 WHERE AppoinmentId = '"+appointmentID+"'";
                return db.EXeNonQuery(cmd);
            }
            public DataTable patientEntryload(AppointmentInfo AppointInfo)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM AppointmentTbl";
                return db.ExeReader(cmd);
            }

    }
}


