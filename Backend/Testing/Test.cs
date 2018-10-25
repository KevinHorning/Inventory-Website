using System;
using Backend.Shared;

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

            //Parts.AddPart.addPart("Screw Kit", "16841384", 7, 0).Wait();

            TableData data = new TableData("parts");
            //object[] headers = Shared.TableData.TableData("parts").Item2;
            for (int i = 0; i < data.Headers.Length; i++)
            {
                Console.WriteLine(data.Headers[i]);
            }
            

            Console.ReadKey();
        }
    }
}