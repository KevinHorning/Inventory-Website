using System;

namespace Backend.Testing
{
    class Programs
    {
        static void Main(string[] args)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            var dbManager = new Managers.DatabaseManager();
            try
            {
                Console.WriteLine("Connection Successful");

                //Equipment.AddEquipment.addEquipment("Dell Inspiron 7559", "Office B Storage Closet", "has radioactive robotics testing software");
                //Deletion.Delete("parts", 7);

                var table = dbManager.GetPartsTable().Result;
                Console.WriteLine(table[2].serializable);

                //int result = AddToSystem.Add(2, 1111);
                //Console.WriteLine(result);

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