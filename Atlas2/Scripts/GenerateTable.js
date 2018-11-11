function GenerateTable(url) {
        $.get(url, function(data) {
            
            var table = document.createElement("TABLE");
            table.border = "1";

            var row = table.insertRow(-1);
            
            for (var header = 0; header < data.Headers.length; header++) {
                var cell = document.createElement("th");
                cell.innerHTML = data.Headers[header];
                row.appendChild(cell);
            }

            var tableBody = document.createElement("tbody");
            tableBody.setAttribute("id", "TableBody");
            table.appendChild(tableBody);

            for (var i = 0; i < data.Data.length; i++) {
                var current = data.Data[i];
                var row = tableBody.insertRow(-1);
                row.setAttribute("onclick", "alert('hello')");

                for (var j = 0; j < data.Headers.length; j++) {
                    var cell = document.createElement("td");
                    cell.innerHTML = current[data.Headers[j]];
                    row.appendChild(cell);
                }
            }
            
            var divTable = document.getElementById("divTable");
            divTable.innerHTML = "";
            divTable.appendChild(table);
        });
}
