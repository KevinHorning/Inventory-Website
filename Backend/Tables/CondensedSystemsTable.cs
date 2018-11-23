using CTG.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Systems.CondensedSystem
{
    public class CondensedSystemsTable
    {
        public String[] Headers { get; set; }
        public Models.System[] Data { get; set; }

        public static List<Models.System> listData = new List<Models.System>();

        public static CondensedSystemsTable GetCondensedSystemsTable()
        {
            return new CondensedSystemsTable();
        }

        public async Task CondensedSystemsTables()
        {
            var databaseManager = new Managers.DatabaseManager();
            var systems = await databaseManager.GetSystemsTable();
            listData = systems.ToList<Models.System>();

            for (int i = 0; i < listData.Count; i++)
            {
                Stack<int> duplicateSystemsIndices = new Stack<int>();
                duplicateSystemsIndices.Push(i);
                for (int j = i + 1; j < listData.Count; j++)
                {
                    if (listData[i].SKU.Equals(listData[j].SKU))
                        duplicateSystemsIndices.Push(j);
                }
                if (duplicateSystemsIndices.Count > 1)
                {
                    Condense(listData[i], duplicateSystemsIndices);
                    i--;
                }
            }
            Data = listData.ToArray();
            return;
        }

        //TODO index variable too to maintain position
        public static void Condense(Models.System system, Stack<int> stack)
        {
            int size = stack.Count;
            for (int i = 0; i < size; i++)
            {
                listData.RemoveAt(stack.Pop());
            }

            var replacementSystem = system;
            replacementSystem.count = size;

            replacementSystem.serialNumber = "NA";
            listData.Add(replacementSystem);
        }
    }
}
