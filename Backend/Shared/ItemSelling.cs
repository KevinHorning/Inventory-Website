using Backend.Parts;
using CTG.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Shared
{
    class ItemSelling
    {
        public static void SellPart(int partID, int personID)
        {
            Synchronize(partID, personID, 0);
        }

        public static void SellAssembly(int assemblyID, int personID)
        {
            Synchronize(assemblyID, personID, 1);
        }

        public static async void Synchronize(int itemID, int personID, int itemType)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                string type = "assemblies";
                if (itemType = 0)
                    type = "parts";

                var personID = new KeyValuePair<String, object>("serialNumber", serialNumber);
                var assemblyID = new KeyValuePair<String, object>("count", count);
                var partID = new KeyValuePair<String, object>("partType", partType);
                var dateSold;
                var PO;
                var values = new[] { namePair, serialNumberPair, countPair, partTypePair };

                MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                Query query = QBuilder.BuildInsertQuery("parts", values);
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }
    }
}
