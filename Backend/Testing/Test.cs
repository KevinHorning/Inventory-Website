using System;
using Backend.Shared;
using Backend.Parts;
using System.Threading.Tasks;
using CTG.Database;
using CTG.Database.Models;
using Backend.Systems.CondensedSystem;
using Backend.Systems;
using System.Collections.Generic;

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

                CondensedSystemsTable c = CondensedSystemsTable.GetCondensedSystemsTable();
                //SystemsTable s = SystemsTable.GetSystemsTable();

                Console.WriteLine(c.Data.Length);
                for (int i = 0; i < c.Headers.Length; i++)
                {
                    Console.Write(c.Headers[i] + " ");
                }
                Console.WriteLine();
                for (int j = 0; j < c.Data.Length; j++)
                {
                    Console.WriteLine(c.Data[j].itemID + " " + c.Data[j].name + " " + c.Data[j].SKU + " " + c.Data[j].serialNumber + " " + c.Data[j].systemTempateID);
                }
                
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