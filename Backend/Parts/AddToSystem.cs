using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Parts
{
    public class AddToSystem
    {
        public static void Add(int systemID)
        {
            Synchronize(systemID).Wait();
        }

        public static async Task Synchronize(int systemID)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {

            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }
    }

    class CustomException : Exception
    {
        public CustomException(string message)
        {
        }
    }

}
