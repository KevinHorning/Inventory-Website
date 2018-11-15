using System;
using Backend.Shared;
using Backend.Parts;
using System.Threading.Tasks;
using CTG.Database;
using CTG.Database.Models;

namespace Backend.Testing
{
    class Programs
    {
        static void Main(string[] args)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                Console.WriteLine("Connection Successful");

                Systems.SelectSystem.SubSystemsTable.GetSubSystemsTable();
                //Equipment.AddEquipment.addEquipment("Dell Inspiron 7559", "Office B Storage Closet", "has radioactive robotics testing software");
                //Deletion.Delete("parts", 7);

                //Parts.AddPart.addPart("7mm bolt", "8948667", 52, 0).Wait();

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex.Message);
                DatabaseManager.GetConnection().Close();
            }
        }
    }
}