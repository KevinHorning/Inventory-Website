using System;
namespace Atlas2.Models
{
    public class TableResponse<T>
    {
        public string[] Headers { get; set; }
        public T[] Data { get; set; }
    }
}
