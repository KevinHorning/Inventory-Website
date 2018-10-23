using System;

namespace Backend.Testing
{
    class Program
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

            //Parts.AddPart.addPart("Screw Kit", "16841384", 7, 0).Wait();

            
            object[] headers = Shared.TableData.GetTableData("parts").Item2;
            for (int i = 0; i < headers.Length; i++)
            {
                Console.WriteLine(headers[i]);
            }
            

            Console.ReadKey();
        }
    }
}