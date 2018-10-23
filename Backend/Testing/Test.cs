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

            object[] headers = Shared.TableData.GetTableData("parts").Item2;
            for (int i = 0; i < headers.Length; i++)
            {
                Console.WriteLine(headers[i]);
            }

            Console.ReadKey();
        }
    }
}