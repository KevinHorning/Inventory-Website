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
        public System[] Data { get; set; }

        public static List<System> listData = new List<System>();

        public static CondensedSystemsTable GetCondensedSystemsTable()
        {
            return new CondensedSystemsTable();
        }

        public CondensedSystemsTable()
        {
            SystemsTable systems = SystemsTable.GetSystemsTable();
            Headers = systems.Headers;
            listData = systems.Data.OfType<System>().ToList();

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
        }

        //TODO index variable too to maintain position
        public static void Condense(System system, Stack<int> stack)
        {
            int size = stack.Count;
            for (int i = 0; i < size; i++)
            {
                listData.RemoveAt(stack.Pop());
            }

            System replacementSystem = system;
            replacementSystem.count = stack.Count;
            replacementSystem.serialNumber = "NA";
            listData.Add(replacementSystem);
        }
    }
}
