using System;
using Backend.Shared;
using Backend.Parts;

namespace Backend.Testing
{
    class Programs
    {
        static void Main(string[] args)
        {
            try
            {
                var DatabaseManager = Shared.DBconnection.GetManager();
                Console.WriteLine("Connection Successful");
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex.Message);
            }

            Deletion.Delete("parts", 2);

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
    }
}