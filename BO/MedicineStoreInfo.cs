using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class PharmacyStoreInfo
    {
        public int InvoiceN { get; set; }
        public string MedicineName { get; set; }
        public string Details { get; set; }
        public string CompanyName { get; set; }
        public string Quantity { get; set; }
        public string UnitPrice { get; set; }
        public string EntryDate { get; set; }
        public string MfgDate { get; set; }
        public string ExpireDate { get; set; }
        public string LocationAddress { get; set; }
    }

    public class RegistrationInfo 
    {
        public string Role { get; set; }
        public string UserId { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Mstatus { get; set; }
        public string Religion { get; set; }
        public string Occupation { get; set; }
        public string Qualification { get; set; }
        public string Paddress { get; set; }
        public string Taddress { get; set; }
        public string ContacN { get; set; }
        public string Email { get; set; }
        public bool Status = false;
         
    }
}


