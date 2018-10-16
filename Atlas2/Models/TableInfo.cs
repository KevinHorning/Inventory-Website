using System;
namespace Atlas2.Models
{
    public class Contact
    {
        public string[] Properties;
        public string[] Elements;

        public Contact(string[] Properties, string[] Elements) {
            this.Properties = Properties;
            this.Elements = Elements;
        }
    }
}
