using System;
using System.Linq;
using Backend.Parts;
using Backend.Systems;

namespace Backend.Shared
{
    public class InventoryTable
    {
        public System.String[] Headers { get; set; }
        public Object[] Data { get; set; }

        public static Object[] partsData;
        public static Object[] systemsData;

        public static InventoryTable GetInventoryTable()
        {
            return new InventoryTable();
        }

        public InventoryTable()
        {
            Headers = PartsTable.GetPartsTable().Headers;
            string[] temp = Headers;
            Array.Resize<System.String>(ref temp, Headers.Length + 1);
            Headers = temp;
            Headers[0] = "itemID";
            Headers[Headers.Length - 1] = "itemType";

            partsData = PartsTable.GetPartsTable().Data;
            systemsData = SystemsTable.GetSystemsTable().Data;

            Data = partsData.Concat(systemsData).ToArray();

        }
    }
}