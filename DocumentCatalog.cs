using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cachero_Group___Document_Request_System_Project
{
    class DocumentCatalog
    {
        public static Dictionary<string, decimal> Prices = new Dictionary<string, decimal>()
        {
            { "Certificate of Matriculation", 50 },
            { "Certificate of Grades", 30 },
            { "Certificate of Graduation", 50 },
            { "Certificate of Good Moral Character", 30 },
            { "Honorable Dismissal", 150 },
            { "Permit to Transfer", 150 },
            { "Transcript of Records", 120 },
            { "True Copy of Grades", 100 }
        };
    }
}
