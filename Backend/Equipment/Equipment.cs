using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Equipment
{
    class Equipment
    {
        public int equipmentID { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string notes { get; set; }

        public static async Task AddEquipment(String name, String location, String notes = null)
        {
            var DatabaseManager = Shared.DBconnection.GetManager();
            KeyValuePair<String, object>[] values;

            try
            {
                var namePair = new KeyValuePair<String, object>("name", name);
                var locationPair = new KeyValuePair<String, object>("location", location);
                if (!(notes == null))
                {
                    var notesPair = new KeyValuePair<String, object>("notes", notes);
                    values = new[] { namePair, locationPair, notesPair };
                }
                else
                    values = new[] { namePair, locationPair };

                MSSQLQueryBuilder QBuilder = new MSSQLQueryBuilder();
                Query insertQuery = QBuilder.BuildInsertQuery("equipment", values);
                DatabaseManager.ExecuteNonQueryAsync(DatabaseManager.GetConnection(), insertQuery.QueryString, insertQuery.Parameters).Wait();
            }
            finally
            {
                DatabaseManager.GetConnection().Close();
            }
        }
    }
}
