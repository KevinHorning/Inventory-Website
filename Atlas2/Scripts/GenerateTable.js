function GenerateTable() {
        $.get( "/api/Contacts/table/", function(data) {
            var tableInfo = eval(data);
            var table = document.createElement("table");
            table.border = "1";

            var row = table.insertRow(-1);

            //Fills headers
            for (var i = 0; i < tableInfo.Properties.Length; i++) {
                var cell = document.createElement("th");
                cell.innerHTML = tableInfo.Properties[i];
                console.log(tableInfo.Properties[i]);
                row.appendChild(cell);
            }

            //Fills table with elements
            for (var i = 0; i < tableInfo.Elements.Length/tableInfo.Properties.Length; i++) {
                row = table.insertRow(-1);
                for (var j = 0; j < tableInfo.Properties.Length; j++) {
                    var cell = row.insertCell(-1);
                    cell.innerHTML = tableInfo.Elements[i*(tableInfo.Properties.ength) + j];
                    console.log(tableInfo.Elements[i*(tableInfo.Properties.ength) + j]);
                }
            }
            
            var divTable = document.getElementById("divTable");
            divTable.innerHTML = "";
            divTable.appendChild(table);
        });
}
