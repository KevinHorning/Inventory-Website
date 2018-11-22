namespace Backend.Parts
{
    public class Part
    {
        public int itemID { get; set; }
        public string name { get; set; }
        public string SKU { get; set; }
        public string serialNumber { get; set; }
        public int count { get; set; }
        public string itemType = "part";
        public bool serializable { get; set; }
    }
}
