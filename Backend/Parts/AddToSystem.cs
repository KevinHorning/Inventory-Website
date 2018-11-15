using Backend.Verification;
using CTG.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Parts
{
    public class AddToSystem
    {
        public static void Add(int systemID, int partID)
        {
            Synchronize(systemID, partID).Wait();
        }

        public static async Task Synchronize(int systemID, int partID)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                if (SystemIDverification.Verify(systemID) && PartIDverification.Verify(partID))
                {
                    //Query insertSystemPart =     
                }
                else if (PartIDverification.Verify(systemID))
                {
                    throw new CustomException("systemID " + systemID + " not found");
                }
                else if (SystemIDverification.Verify(systemID))
                {
                    throw new CustomException("partID " + partID + " not found");
                }
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
