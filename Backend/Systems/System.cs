namespace Backend.Systems
{
    public class System
    {
        public int itemID { get; set; }
        public string name { get; set; }
        public string SKU { get; set; }
        public string serialNumber { get; set; }
        public int count = 1;
        public string itemType = "system";
        public int systemTempateID { get; set; }
    }
}
