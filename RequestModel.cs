using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cachero_Group___Document_Request_System_Project
{
    public class RequestModel
    {
        public string RequestID { get; set; }
        public string StudentNumber { get; set; }
        public string StudentName { get; set; }
        public string DocumentType { get; set; }
        public string Purpose { get; set; }
        public int Copies { get; set; }
        public string AdditionalNotes { get; set; }
        public decimal PricePerCopy { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DateRequested { get; set; }
        public string Status { get; set; }
    }
}
