using System;
using System.Linq;
namespace Backend.Shared
{
    public class InventoryTable
    {
        public System.String[] Headers { get; set; }
        public Object[] Data { get; set; }

        public static Object[] partsData;
        public static Object[] systemsData;
        private Managers.DatabaseManager databaseManager = new Managers.DatabaseManager();

        public static InventoryTable GetInventoryTable()
        {
            return new InventoryTable();
        }

        public InventoryTable()
        {
            var headers = databaseManager.GetPartsTable();
            string[] temp = Headers;
            Array.Resize<System.String>(ref temp, Headers.Length + 1);
            Headers = temp;
            Headers[0] = "itemID";
            Headers[Headers.Length - 1] = "itemType";

            partsData = databaseManager.GetPartsTable().Result;
            systemsData = databaseManager.GetSystemsTable().Result;

            Data = partsData.Concat(systemsData).ToArray();

        }
    }
}