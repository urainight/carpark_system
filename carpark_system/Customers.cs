using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpark_system
{
    internal class Customers
    {
        public string UID { get; set; }
        public string Plate { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public DateTime Date_create { get; set; } = DateTime.Now;
        public DateTime Date_pay { get; set; }
        public DateTime Date_end { get; set; }
        public bool Month_ticket { get; set; }
        public bool Gate_in { get; set; }

        public Customers(string uID, string plate, string name, string gender, string phone, DateTime date_pay, bool month_ticket, bool gate_in)
        {
            UID = uID;
            Plate = plate;
            Name = name;
            Gender = gender;
            Phone = phone;
            Date_pay = date_pay;
            Date_end = date_pay.AddMonths(1);
            Month_ticket = month_ticket;
            Gate_in = gate_in;
        }
    }
}
