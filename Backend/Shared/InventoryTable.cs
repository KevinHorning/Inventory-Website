using System;
using System.Linq;
using Backend.Parts;
using Backend.Systems.CondensedSystem;

namespace Backend.Shared
{
    public class InventoryTable
    {
        public System.String[] Headers { get; set; }

        public Part[] partsData;
        public Systems.System[] systemsData;

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
            systemsData = CondensedSystemsTable.GetCondensedSystemsTable().Data;

        }
    }
}