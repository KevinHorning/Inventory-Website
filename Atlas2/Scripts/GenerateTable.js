function GenerateTable() {
            var contacts = $.get("/api/Contacts/table");

            var table = document.createElement("TABLE")
            table.border = "1";

            var row = table.insertRow(-1);

            for (var i = 0; i < contacts.Properties.length; i++) {
                var cell = document.createElement("td");
                cell.innerHTML = contacts.Properties[i];
                row.appendChild(cell);
            }
            
            for (var i = 0; i < contacts.Properties.length; i++) {
                row = table.insertRow(-1);
                for (var j = 0; j < contacts.Elements.length/contacts.Properties.length; j++) {
                    var cell = row.insertCell(-1);
                    cell.innerHTML = contacts.Elements[i*(contacts.Elements.length/contacts.Properties.length) + j];
                }
            }


            var dvTable = document.getElementById("dvTable");
            dvTable.innerHTML = "";
            dvTable.appendChild(table);
}
GenerateTable();
