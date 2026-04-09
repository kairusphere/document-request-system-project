using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cachero_Group___Document_Request_System_Project
{
    public static class SessionManager
    {
        public static int DbUserId { get; set; }
        public static string UserID { get; set; }
        public static string FullName { get; set; }
        public static string Role { get; set; }

        public static void Clear()
        {
            DbUserId = 0;
            UserID = null;
            FullName = null;
            Role = null;
        }
    }
}
