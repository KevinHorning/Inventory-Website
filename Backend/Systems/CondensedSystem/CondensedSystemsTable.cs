using CTG.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Systems.CondensedSystem
{
    public class CondensedSystemsTable
    {
        public String[] Headers { get; set; }
        public System[] Data { get; set; }

        public static List<System> listData = new List<System>();

        public CondensedSystemsTable()
        {
            Synchronize().Wait();
        }

        public static CondensedSystemsTable GetCondensedSystemsTable()
        {
            return new CondensedSystemsTable();
        }

        public async Task Synchronize()
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            try
            {
                SystemsTable systems = SystemsTable.GetSystemsTable();
                listData = systems.Data.OfType<System>().ToList();
                Headers = systems.Headers;

                for (int i = 0; i < Data.Length; i++)
                {
                    List<int> otherSystemIndices = new List<int>();
                    for (int j = i + 1; j < Data.Length; j++)
                    {
                        if (Data[i].SKU.Equals(Data[j].SKU))
                            otherSystemIndices.Add(j);                  
                    }
                    if (otherSystemIndices.Count > 1)
                    {
                        Condense(Data[i], otherSystemIndices);
                        i--;
                    }
                }
                Data = listData.ToArray();
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }

        //TODO index variable too to maintain position
        public static void Condense(System system, List<int> list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                listData.RemoveAt(i);
            }

            System replacementSystem = system;
            replacementSystem.count = list.Count;
            listData.Add(replacementSystem);
        }
    }
}
