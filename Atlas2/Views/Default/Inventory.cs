#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Atlas2.Views.Default
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "2.6.0.0")]
public partial class Inventory : InventoryBase
{

#line hidden

public override void Execute()
{
WriteLiteral("<!DOCTYPE html>\n<html>\n<head>\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width\"");

WriteLiteral(" />\n\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"/Scripts/jquery-3.3.1.min.js\"");

WriteLiteral("></script>\n\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"/Scripts/GenerateTable.js\"");

WriteLiteral("></script>\n\n    <title></title>\n\n    <script");

WriteLiteral(" src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js\"");

WriteLiteral("></script>\n\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" href=\"https://www.w3schools.com/w3css/4/w3.css\"");

WriteLiteral(">\n  \n    <style>\n        body {\n            margin: 0;\n            font-family: A" +
"rial, Helvetica, sans-serif;\n        }\n\n        h2 {\n            padding-left: 1" +
"5px;\n        }\n\n        table {\n            border: 1px solid #ccc;\n            " +
"border-collapse: collapse;\n            width: 80%;\n        }\n\n            table " +
"th {\n                background-color: #F7F7F7;\n                color: #333;\n   " +
"             font-weight: bold;\n                text-align: left;\n            }\n" +
"\n            table th, table td {\n                padding: 15px;\n               " +
" text-align: left;\n                border-bottom: 1px solid #ddd;\n            }\n" +
"\n        tr:hover {\n            background-color: #f5f5f5;\n        }\n\n\n\n        " +
".topnav {\n            overflow: hidden;\n            background-color: #25275A;\n " +
"       }\n\n            .topnav a {\n                float: left;\n                c" +
"olor: #f2f2f2;\n                text-align: center;\n                padding: 14px" +
" 16px;\n                text-decoration: none;\n                font-size: 17px;\n " +
"           }\n\n                .topnav a:hover {\n                    background-c" +
"olor: #B0EEFA;\n                    color: black;\n                }\n\n            " +
"    .topnav a.active {\n                    background-color: #7ED8F9;\n          " +
"          color: #343E46;\n                }\n\n        .modal {\n            displa" +
"y: none; /* Hidden by default */\n            position: fixed; /* Stay in place *" +
"/\n            z-index: 1; /* Sit on top */\n            padding-top: 100px; /* Lo" +
"cation of the box */\n            left: 0;\n            top: 0;\n            width:" +
" 100%; /* Full width */\n            height: 100%; /* Full height */\n            " +
"overflow: auto; /* Enable scroll if needed */\n            background-color: rgb(" +
"0,0,0); /* Fallback color */\n            background-color: rgba(0,0,0,0.4); /* B" +
"lack w/ opacity */\n        }\n\n        .w3-modal-content {\n            background" +
"-color: #fefefe;\n            margin: auto;\n            padding: 20px;\n          " +
"  border: 1px solid #888;\n            width: 80%;\n        }\n\n        .w3-modal i" +
"nput[type=text], select, textarea {\n            width: 100%; /* Full width */\n  " +
"          padding: 12px; /* Some padding */\n            border: 1px solid #ccc; " +
"/* Gray border */\n            border-radius: 4px; /* Rounded borders */\n        " +
"    box-sizing: border-box; /* Make sure that padding and width stays in place *" +
"/\n            margin-top: 6px; /* Add a top margin */\n            margin-bottom:" +
" 16px; /* Bottom margin */\n            resize: vertical /* Allow the user to ver" +
"tically resize the textarea (not horizontally) */\n        }\n\n        .w3-modal b" +
"utton {\n            background-color: #25275A;\n            border: none;\n       " +
"     color: white;\n            padding: 8px 21px;\n            text-align: center" +
";\n            text-decoration: none;\n            display: inline-block;\n        " +
"    font-size: 16px;\n        }\n\n        .close {\n            color: #aaaaaa;\n   " +
"         float: right;\n            font-size: 28px;\n            font-weight: bol" +
"d;\n        }\n\n            .close:hover,\n            .close:focus {\n             " +
"   color: #000;\n                text-decoration: none;\n                cursor: p" +
"ointer;\n            }\n    </style>\n</head>\n<body>\n    <div");

WriteLiteral(" class=\"topnav\"");

WriteLiteral(">\n        <a");

WriteLiteral(" class=\"active\"");

WriteLiteral(" href=\"Inventory\"");

WriteLiteral(">Inventory</a>\n        <a");

WriteLiteral(" href=\"Equipment\"");

WriteLiteral(">Equipment</a>\n        <a");

WriteLiteral(" href=\"Contacts\"");

WriteLiteral(">Contacts</a>\n    </div>\n    <div");

WriteLiteral(" id=\"sendModal\"");

WriteLiteral(" class=\"w3-modal\"");

WriteLiteral(" style=\"z-index: 2001\"");

WriteLiteral(">\n        <!-- Modal content -->\n        <div");

WriteLiteral(" class=\"w3-modal-content w3-animate-right\"");

WriteLiteral(">\n            <span");

WriteLiteral(" class=\"close\"");

WriteLiteral(">&times;</span>\n            <p>Send Modal</p>\n        </div>\n    </div>\n    <div");

WriteLiteral(" id=\"editModal\"");

WriteLiteral("></div>\n    <div");

WriteLiteral(" id=\"myModal\"");

WriteLiteral("></div>\n    <div");

WriteLiteral(" id=\"partModal\"");

WriteLiteral(" class=\"w3-modal\"");

WriteLiteral(" style=\"z-index:1999\"");

WriteLiteral(">\n        <!-- Modal content -->\n        <div");

WriteLiteral(" class=\"w3-modal-content w3-animate-right\"");

WriteLiteral(">\n            <span");

WriteLiteral(" class=\"close\"");

WriteLiteral(">&times;</span>\n            <p>Part Modal</p>\n            <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\n                <label>Part Name: </label>\n                <label");

WriteLiteral(" class=\"partName\"");

WriteLiteral("></label>\n                <br /><br />\n                <label>SKU: </label>\n     " +
"           <label");

WriteLiteral(" class=\"partSku\"");

WriteLiteral("></label>\n                <br /><br />\n                <label>Count: </label>\n   " +
"             <label");

WriteLiteral(" class=\"partCount\"");

WriteLiteral("></label>\n                <br /><br />\n                <table");

WriteLiteral(" id=\"modalTable\"");

WriteLiteral("></table>\n                <button");

WriteLiteral(" class=\"editButton\"");

WriteLiteral(" accesskey=\"partEdit\"");

WriteLiteral(">Open Edit Modal</button>\n                <button");

WriteLiteral(" class=\"editButton\"");

WriteLiteral(" accesskey=\"partAdd\"");

WriteLiteral(">Add to System</button>\n            </div>\n        </div>\n    </div>\n    <div");

WriteLiteral(" id=\"partEditModal\"");

WriteLiteral(" class=\"w3-modal\"");

WriteLiteral(" style=\"z-index:2000\"");

WriteLiteral(">\n        <div");

WriteLiteral(" class=\"w3-modal-content w3-animate-right\"");

WriteLiteral(">\n            <span");

WriteLiteral(" class=\"close\"");

WriteLiteral(">&times;</span>\n            <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\n                <label>Part Name: </label>\n                <label");

WriteLiteral(" class=\"partName\"");

WriteLiteral("></label>\n                <br/>\n                <label>Count: </label>\n          " +
"      <label");

WriteLiteral(" class=\"partCount\"");

WriteLiteral("></label>\n                <br/>\n                <button");

WriteLiteral(" id=\"partAddButton\"");

WriteLiteral(">Add: </button>\n                <input");

WriteLiteral(" id=\"partAddBox\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" style=\"width:45px; height: 40px\"");

WriteLiteral("/>\n                <br/>\n                <button");

WriteLiteral(" id=\"partRemoveButton\"");

WriteLiteral(">Remove: </button>\n                <input");

WriteLiteral(" id=\"partRemoveBox\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" style=\"width:45px; height: 40px\"");

WriteLiteral(@"/>
                <script>
                    $(""#partAddButton).click(function() {
                        var count = $(""#partAddBox"").val();
                        var content = document.getElementsByClassName('partName')[0].innerHTML;
                        $.post(""/api/Inventory/addCount"", count, content)
                            .done(function(data) {
                                alert(""Stock successfully added!"");
                                editModal.style.display = ""none"";
                            })
                            .fail(function(data) {
                                alert(""Error"");
                            });
                    });
                    $(""#partRemoveButton"").click(function() {
                        var count = $(""#partAddBox"").val();
                        var content = document.getElementsByClassName('partName')[0].innerHTML;
                        $.post(""/api/Inventory/removeCount"", count, content)
                            .done(function(data) {
                                alert(""Stock successfully removed!"");
                                editModal.style.display = ""none"";
                            })
                            .fail(function(data) {
                                alert(""Error"");
                            });
                    });
                </script>
            </div>
        </div>
    </div>
    <div");

WriteLiteral(" id=\"partSystemModal\"");

WriteLiteral(" class=\"w3-modal\"");

WriteLiteral(" style=\"z-index:2000\"");

WriteLiteral(">\n        <div");

WriteLiteral(" class=\"w3-modal-content w3-animate-right\"");

WriteLiteral(">\n            <span");

WriteLiteral(" class=\"close\"");

WriteLiteral(">&times;</span>\n            <p>Add to System</p>\n            <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\n                <div");

WriteLiteral(" id=\"partSystemTable\"");

WriteLiteral("></div>\n                <script>\n                     GenerateTable(\"/api/Invento" +
"ry/table/\", \"partSystem\", \"partSystemTable\");\n                </script>\n        " +
"    </div>\n        </div>\n    </div>\n    <div");

WriteLiteral(" id=\"addPartSystemModal\"");

WriteLiteral(" class=\"w3-modal\"");

WriteLiteral(" style=\"z-index:2001\"");

WriteLiteral(">\n        <div");

WriteLiteral(" class=\"w3-modal-content w3-animate-right\"");

WriteLiteral(">\n            <span");

WriteLiteral(" class=\"close\"");

WriteLiteral(">&times;</span>\n            <p>Add to System</p>\n            <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\n                <label");

WriteLiteral(" class=\"partName\"");

WriteLiteral("></label><br />\n                <label>Available: </label>\n                <label" +
"");

WriteLiteral(" class=\"partCount\"");

WriteLiteral("></label><br />\n                <button");

WriteLiteral(" class=\"partButton\"");

WriteLiteral(">Add: </button>\n                <input");

WriteLiteral(" id=\"addPartSystemBox\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" style=\"width:45px; height: 40px\"");

WriteLiteral("/>\n            </div>\n        </div>\n    </div>\n    <div");

WriteLiteral(" id=\"systemModal\"");

WriteLiteral(" class=\"w3-modal\"");

WriteLiteral(" style=\"z-index:1999\"");

WriteLiteral(">\n        <!-- Modal content -->\n        <div");

WriteLiteral(" class=\"w3-modal-content w3-animate-right\"");

WriteLiteral(">\n            <span");

WriteLiteral(" class=\"close\"");

WriteLiteral(">&times;</span>\n            <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\n                <label>System Name: </label>\n                <label");

WriteLiteral(" class=\"systemName\"");

WriteLiteral("></label>\n                <br /><br />\n                <label>SKU: </label>\n     " +
"           <label");

WriteLiteral(" class=\"systemSku\"");

WriteLiteral("></label>\n                <br /><br />\n                <table");

WriteLiteral(" id=\"systemTable\"");

WriteLiteral("></table>\n                <button");

WriteLiteral(" class=\"editButton\"");

WriteLiteral(" accesskey=\"systemEdit\"");

WriteLiteral(">Open Edit Modal</button>\n                <button");

WriteLiteral(" class=\"editButton\"");

WriteLiteral(" accesskey=\"systemBuild\"");

WriteLiteral(">Build New System</button>\n            </div>\n        </div>\n    </div>\n    <div");

WriteLiteral(" id=\"systemEditModal\"");

WriteLiteral(" class=\"w3-modal\"");

WriteLiteral(" style=\"z-index: 2000\"");

WriteLiteral(">\n        <div");

WriteLiteral(" class=\"w3-modal-content w3-animate-right\"");

WriteLiteral(">\n            <span");

WriteLiteral(" class=\"close\"");

WriteLiteral(">&times;</span>\n            <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\n                <label>System Name: </label>\n                <label");

WriteLiteral(" class=\"systemName\"");

WriteLiteral("></label>\n                <br />\n                <label>SKU: </label>\n           " +
"     <label");

WriteLiteral(" class=\"systemSku\"");

WriteLiteral("></label>\n                <br />\n                <div");

WriteLiteral(" id=\"systemEditTable\"");

WriteLiteral("></div>\n                <script>\n                    GenerateTable(\"/api/Inventor" +
"y/table/\", \"systemEdit\", \"systemEditTable\");\n                </script>\n         " +
"   </div>\n        </div>\n    </div>\n    <div>\n    <div");

WriteLiteral(" id=\"systemBuildModal\"");

WriteLiteral(" class=\"w3-modal\"");

WriteLiteral(" style=\"z-index: 2000\"");

WriteLiteral(">\n        <div");

WriteLiteral(" class=\"w3-modal-content w3-animate-right\"");

WriteLiteral(">\n            <span");

WriteLiteral(" class=\"close\"");

WriteLiteral(">&times;</span>\n            <p>Build New System</p>\n        </div>\n    </div>\n   " +
" <div");

WriteLiteral(" id=\"addSystemPartModal\"");

WriteLiteral(" class=\"w3-modal\"");

WriteLiteral(" style=\"z-index: 2001\"");

WriteLiteral(">\n        <div");

WriteLiteral(" class=\"w3-modal-content w3-animate-right\"");

WriteLiteral(">\n            <span");

WriteLiteral(" class=\"close\"");

WriteLiteral(">&times;</span>\n            <label>System: </label>\n            <label");

WriteLiteral(" class=\"systemName\"");

WriteLiteral("></label><br />\n            <label>Part: </label>\n            <label");

WriteLiteral(" class=\"partName\"");

WriteLiteral("></label><br />\n            <label>Available: </label>\n            <label");

WriteLiteral(" class=\"partCount\"");

WriteLiteral("></label><br />\n            <button");

WriteLiteral(" class=\"partButton\"");

WriteLiteral(">Add: </button>\n            <input");

WriteLiteral(" id=\"addSystemPartBox\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" style=\"width:45px; height: 40px\"");

WriteLiteral("/>\n        </div>\n    </div>\n        <h2");

WriteLiteral(" id=\"Mainlbl\"");

WriteLiteral(">Inventory</h2>\n        <label");

WriteLiteral(" id=\"Srchlbl\"");

WriteLiteral(" style=\"padding-left: 15px\"");

WriteLiteral(">Keyword: </label>\n        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"SearchBox\"");

WriteLiteral(@" style=""
            width: 130px;
            box-sizing: border-box;
            border: 2px solid #ccc;
            border-radius: 4px;
            font-size: 16px;
            background-color: white;
            background-image: url(Downloads/searchicon.png);
            background-position: 10px 10px;
            background-repeat: no-repeat;
            padding: 12px 20px 12px 40px; }""");

WriteLiteral(" placeholder=\"Search...\"");

WriteLiteral(" /><br />\n        <div");

WriteLiteral(" id=\"divTable\"");

WriteLiteral(">Loading...</div>\n        <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\n        GenerateTable(\"/api/Inventory/table/\", \"part\", \"divTable\");\n\n          " +
"  $(document).ready(function(){\n                $(\"#SearchBox\").on(\"keyup\", func" +
"tion() {\n                    var value = $(this).val().toLowerCase();\n          " +
"          $(\"#TableBody tr\").filter(function() {\n                        $(this)" +
".toggle($(this).text().toLowerCase().indexOf(value) > -1)\n                    })" +
";\n                });\n            });\n\n            var modal = document.getEleme" +
"ntById(\'myModal\');\n            var editModal = document.getElementById(\'editModa" +
"l\');\n            var sendModal = document.getElementById(\'sendModal\');\n         " +
"   var span = document.getElementsByClassName(\"close\")[0];\n\n            $(\".edit" +
"Button\").click(function() {\n                openModal(this.accessKey);\n         " +
"   });\n\n            function openModal(row) {\n               if(modal.style.disp" +
"lay == \"block\" && editModal.style.display == \"block\") {\n                    if(e" +
"ditModal.id == \"partSystemModal\") {\n                        sendModal = document" +
".getElementById(\'addPartSystemModal\');\n                        var name = docume" +
"nt.getElementsByClassName(\'systemName\');\n                        [].slice.call( " +
"name ).forEach(function ( name ) {\n                            name.innerHTML = " +
"row[1].innerText;\n                        });\n                    }\n            " +
"        if(editModal.id == \"systemEditModal\") {\n                        sendModa" +
"l = document.getElementById(\'addSystemPartModal\');\n                        var n" +
"ame = document.getElementsByClassName(\'partName\');\n                        [].sl" +
"ice.call( name ).forEach(function ( name ) {\n                            name.in" +
"nerHTML = row[1].innerText;\n                        });\n                    }\n  " +
"                  sendModal.style.display = \"block\";\n               }\n          " +
"     else if(modal.style.display == \"block\") {\n                    if(row == \"pa" +
"rtEdit\") {\n                        editModal = document.getElementById(\'partEdit" +
"Modal\');\n                    }\n                    else if(row == \"partAdd\") {\n " +
"                       editModal = document.getElementById(\'partSystemModal\');\n " +
"                   }\n                    else if(row == \"systemEdit\") {\n        " +
"                editModal = document.getElementById(\'systemEditModal\');\n        " +
"            }\n                    else if(row == \"systemBuild\") {\n              " +
"          editModal = document.getElementById(\'systemBuildModal\');\n             " +
"       }\n                    editModal.style.display = \"block\";\n               }" +
"\n               else {\n                    var sku = row[1].innerText;\n         " +
"           $.get(\"/api/Inventory/modalData/\", {sku}, function(data){\n           " +
"             if (data.itemType == \"part\") {\n                            modal = " +
"document.getElementById(\'partModal\');\n                            var name = doc" +
"ument.getElementsByClassName(\'partName\');\n                            [].slice.c" +
"all( name ).forEach(function ( name ) {\n                                name.inn" +
"erHTML = data.name;\n                            });\n                            " +
"var sku = document.getElementsByClassName(\'partSku\');\n                          " +
"  [].slice.call( sku ).forEach(function ( sku ) {\n                              " +
"  sku.innerHTML = data.SKU;\n                            });\n                    " +
"        var count = document.getElementsByClassName(\'partCount\');\n              " +
"              [].slice.call( count ).forEach(function ( count ) {\n              " +
"                  count.innerHTML = data.count;\n                            });\n" +
"                        }\n                        else if(data.itemType == \"syst" +
"em\") {\n                            modal = document.getElementById(\'systemModal\'" +
");\n                            var name = document.getElementsByClassName(\'syste" +
"mName\');\n                            [].slice.call( name ).forEach(function ( na" +
"me ) {\n                                name.innerHTML = data.name;\n             " +
"               });\n                            var sku = document.getElementsByC" +
"lassName(\'systemSku\');\n                            [].slice.call( sku ).forEach(" +
"function ( sku ) {\n                                sku.innerHTML = data.SKU;\n   " +
"                         });\n                        }\n                        m" +
"odal.style.display = \"block\";\n                    });\n               }\n         " +
"   }\n\n            span.onclick = function() {\n                if(editModal.style" +
".display == \"none\") {\n                    modal.style.display = \"none\";\n        " +
"        }\n                else editModal.style.display = \"none\";\n            }\n\n" +
"            window.onclick = function(event) {\n                if (event.target " +
"== modal) {\n                    modal.style.display = \"none\";\n                }\n" +
"                if (event.target == editModal) {\n                    editModal.s" +
"tyle.display = \"none\";\n                }\n                if (event.target == sen" +
"dModal) {\n                    sendModal.style.display = \"none\";\n                " +
"}\n            }</script>\n    </div>\n</body>\n</html>\n");

}
}

// NOTE: this is the default generated helper class. You may choose to extract it to a separate file 
// in order to customize it or share it between multiple templates, and specify the template's base 
// class via the @inherits directive.
public abstract class InventoryBase
{

		// This field is OPTIONAL, but used by the default implementation of Generate, Write, WriteAttribute and WriteLiteral
		//
		System.IO.TextWriter __razor_writer;

		// This method is OPTIONAL
		//
		/// <summary>Executes the template and returns the output as a string.</summary>
		/// <returns>The template output.</returns>
		public string GenerateString ()
		{
			using (var sw = new System.IO.StringWriter ()) {
				Generate (sw);
				return sw.ToString ();
			}
		}

		// This method is OPTIONAL, you may choose to implement Write and WriteLiteral without use of __razor_writer
		// and provide another means of invoking Execute.
		//
		/// <summary>Executes the template, writing to the provided text writer.</summary>
		/// <param name="writer">The TextWriter to which to write the template output.</param>
		public void Generate (System.IO.TextWriter writer)
		{
			__razor_writer = writer;
			Execute ();
			__razor_writer = null;
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>Writes a literal value to the template output without HTML escaping it.</summary>
		/// <param name="value">The literal value.</param>
		protected void WriteLiteral (string value)
		{
			__razor_writer.Write (value);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>Writes a literal value to the TextWriter without HTML escaping it.</summary>
		/// <param name="writer">The TextWriter to which to write the literal.</param>
		/// <param name="value">The literal value.</param>
		protected static void WriteLiteralTo (System.IO.TextWriter writer, string value)
		{
			writer.Write (value);
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>Writes a value to the template output, HTML escaping it if necessary.</summary>
		/// <param name="value">The value.</param>
		/// <remarks>The value may be a Action<System.IO.TextWriter>, as returned by Razor helpers.</remarks>
		protected void Write (object value)
		{
			WriteTo (__razor_writer, value);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>Writes an object value to the TextWriter, HTML escaping it if necessary.</summary>
		/// <param name="writer">The TextWriter to which to write the value.</param>
		/// <param name="value">The value.</param>
		/// <remarks>The value may be a Action<System.IO.TextWriter>, as returned by Razor helpers.</remarks>
		protected static void WriteTo (System.IO.TextWriter writer, object value)
		{
			if (value == null)
				return;

			var write = value as Action<System.IO.TextWriter>;
			if (write != null) {
				write (writer);
				return;
			}

			//NOTE: a more sophisticated implementation would write safe and pre-escaped values directly to the
			//instead of double-escaping. See System.Web.IHtmlString in ASP.NET 4.0 for an example of this.
			writer.Write(System.Net.WebUtility.HtmlEncode (value.ToString ()));
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>
		/// Conditionally writes an attribute to the template output.
		/// </summary>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="prefix">The prefix of the attribute.</param>
		/// <param name="suffix">The suffix of the attribute.</param>
		/// <param name="values">Attribute values, each specifying a prefix, value and whether it's a literal.</param>
		protected void WriteAttribute (string name, string prefix, string suffix, params Tuple<string,object,bool>[] values)
		{
			WriteAttributeTo (__razor_writer, name, prefix, suffix, values);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>
		/// Conditionally writes an attribute to a TextWriter.
		/// </summary>
		/// <param name="writer">The TextWriter to which to write the attribute.</param>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="prefix">The prefix of the attribute.</param>
		/// <param name="suffix">The suffix of the attribute.</param>
		/// <param name="values">Attribute values, each specifying a prefix, value and whether it's a literal.</param>
		///<remarks>Used by Razor helpers to write attributes.</remarks>
		protected static void WriteAttributeTo (System.IO.TextWriter writer, string name, string prefix, string suffix, params Tuple<string,object,bool>[] values)
		{
			// this is based on System.Web.WebPages.WebPageExecutingBase
			// Copyright (c) Microsoft Open Technologies, Inc.
			// Licensed under the Apache License, Version 2.0
			if (values.Length == 0) {
				// Explicitly empty attribute, so write the prefix and suffix
				writer.Write (prefix);
				writer.Write (suffix);
				return;
			}

			bool first = true;
			bool wroteSomething = false;

			for (int i = 0; i < values.Length; i++) {
				Tuple<string,object,bool> attrVal = values [i];
				string attPrefix = attrVal.Item1;
				object value = attrVal.Item2;
				bool isLiteral = attrVal.Item3;

				if (value == null) {
					// Nothing to write
					continue;
				}

				// The special cases here are that the value we're writing might already be a string, or that the 
				// value might be a bool. If the value is the bool 'true' we want to write the attribute name instead
				// of the string 'true'. If the value is the bool 'false' we don't want to write anything.
				//
				// Otherwise the value is another object (perhaps an IHtmlString), and we'll ask it to format itself.
				string stringValue;
				bool? boolValue = value as bool?;
				if (boolValue == true) {
					stringValue = name;
				} else if (boolValue == false) {
					continue;
				} else {
					stringValue = value as string;
				}

				if (first) {
					writer.Write (prefix);
					first = false;
				} else {
					writer.Write (attPrefix);
				}

				if (isLiteral) {
					writer.Write (stringValue ?? value);
				} else {
					WriteTo (writer, stringValue ?? value);
				}
				wroteSomething = true;
			}
			if (wroteSomething) {
				writer.Write (suffix);
			}
		}
		// This method is REQUIRED. The generated Razor subclass will override it with the generated code.
		//
		///<summary>Executes the template, writing output to the Write and WriteLiteral methods.</summary>.
		///<remarks>Not intended to be called directly. Call the Generate method instead.</remarks>
		public abstract void Execute ();

}
}
#pragma warning restore 1591
