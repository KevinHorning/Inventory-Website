namespace CTG.Database
{
    public class Filter
    {
        public string Column { get; set; }
        public string Operator { get; set; }
        public object Value { get; set; }

        public Filter(string column, string operatorString, object value)
        {
            Column = column;
            Operator = operatorString;
            Value = value;
        }
    }
}