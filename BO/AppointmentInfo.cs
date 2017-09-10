using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class AppointmentInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Weight { get; set; }
        public string AppointmentDate { get; set; }
        public string PatientOfCase { get; set; }
        public string DiseaseType { get; set; }
        public string Description { get; set; }
        public string ContactNo { get; set; }
        public string Amount { get; set; }
        public string BillcashierId = "0";
        public string DoctorId = "0";
        public bool Status = false;

    }
}
