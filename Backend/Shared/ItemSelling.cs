using CTG.Database;
using CTG.Database.MSSQL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared
{
    class ItemSelling
    {
        public static void SellPart(int personID, int itemID, string itemType, string dateSold, string PO)
        {
            Synchronize(personID, itemID, itemType, dateSold, PO).Wait();
        }

        public static void SellAssembly(int personID, int itemID, string itemType, string dateSold, string PO)
        {
            Synchronize(personID, itemID, itemType, dateSold, PO).Wait();
        }

        public static async Task Synchronize(int personID, int itemID, string itemType, string dateSold, string PO)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            Boolean isException = false;
            try
            {
                string type;
                var systemIDpair = new KeyValuePair<String, object>();
                var partIDpair = new KeyValuePair<String, object>();

                if (itemType.Equals("system"))
                    type = "system";
                else if (itemType.Equals("parts"))
                    type = "part";
                else
                {
                    isException = true;
                    throw new CustomException("Item type is not 'part' or 'system'");
                }                   

                var personIDpair = new KeyValuePair<String, object>("personID", personID);
                if (type.Equals("system"))
                {
                    systemIDpair = new KeyValuePair<String, object>("system", itemID);
                    partIDpair = new KeyValuePair<String, object>("partID", "NA");
                }
                else
                {
                    systemIDpair = new KeyValuePair<String, object>("system", "NA");
                    partIDpair = new KeyValuePair<String, object>("partID", itemID);
                }
                //TODO verify date format
                var dateSoldPair = new KeyValuePair<String, object>("dateSold", dateSold);
                var POpair = new KeyValuePair<String, object>("PO", PO);
                var values = new[] { personIDpair, systemIDpair, partIDpair, dateSoldPair, POpair };

                if (!isException)
                {
                    MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                    Query query = QBuilder.BuildInsertQuery("parts", values);
                }
            }
            catch (CustomException ex)
            {
                isException = true;
                Console.WriteLine(ex.Message);
                //todo exeption handling
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }
        class CustomException : Exception
        {
            public CustomException(string message)
            {
            }
        }
    }
}