using System;
using System.Linq;
using Backend.Parts;
using Backend.Systems;

namespace Backend.Shared
{
    public class InventoryTable
    {
        public String[] Headers { get; set; }
        public Object[] Data { get; set; }

        public static Object[] partsData;
        public static Object[] systemsData;
        public static Object[] combinedData;

        public InventoryTable()
        {
            Headers = PartsTable.GetPartsTable().Headers;
            partsData = PartsTable.GetPartsTable().Data;
            systemsData = SystemsTable.GetSystemsTable().Data;

            combinedData = partsData.Concat(systemsData).ToArray();
        }

        public static InventoryTable GetInventoryTable()
        {
            return new InventoryTable();
        }
    }
}