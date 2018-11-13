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

                //AddPart.addPart("7mm Bolt", "6294", "4312189374", 51);
                //Deletion.Delete("parts", 7);

                //Parts.AddPart.addPart("7mm bolt", "8948667", 52, 0).Wait();

                /*
                TableData data = TableData.getTableData("parts");
                for (int i = 0; i < data.Headers.Length; i++)
                {
                    Console.Write(data.Headers[i] + " ");
                }
                Console.WriteLine();
                for (int i = 0; i < data.Data.Length; i++)
                {
                    Console.WriteLine(data.Data[i].partID + " " + data.Data[i].name + " " + data.Data[i].serialNumber + " " + data.Data[i].count + " " + data.Data[i].partType);
                }
                */

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