using System;
namespace Atlas2.Models
{
    public class TableInfo
    {
        public string[] Properties;
        public string[] Elements;

        public TableInfo(string[] Properties, string[] Elements) {
            this.Properties = Properties;
            this.Elements = Elements;
        }
    }
}
