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
public partial class Contacts : ContactsBase
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

WriteLiteral("></script>\n    <script>\n        $(document).ready(function(){\n            $(\"#Sea" +
"rchBox\").on(\"keyup\", function() {\n                var value = $(this).val().toLo" +
"werCase();\n                $(\"#TableBody tr\").filter(function() {\n              " +
"      $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)\n         " +
"       });\n            });\n        });\n    </script>\n\n    <style>\n        body {" +
"\n            margin: 0;\n            font-family: Arial, Helvetica, sans-serif;\n " +
"       }\n\n        h2 {\n            padding-left: 15px;\n        }\n\n        table " +
"{\n            border: 1px solid #ccc;\n            border-collapse: collapse;\n   " +
"         width: 80%;\n        }\n\n            table th {\n                backgroun" +
"d-color: #F7F7F7;\n                color: #333;\n                font-weight: bold" +
";\n                text-align: left;\n            }\n\n            table th, table t" +
"d {\n                padding: 15px;\n                text-align: left;\n           " +
"     border-bottom: 1px solid #ddd;\n                text-overflow: ellipsis;\n   " +
"         }\n\n            tr:hover {\n                background-color: #f5f5f5;\n  " +
"          }\n\n\n\n        .topnav {\n            overflow: hidden;\n            backg" +
"round-color: #25275A;\n        }\n\n            .topnav a {\n                float: " +
"left;\n                color: #f2f2f2;\n                text-align: center;\n      " +
"          padding: 14px 16px;\n                text-decoration: none;\n           " +
"     font-size: 17px;\n            }\n\n                .topnav a:hover {\n         " +
"           background-color: #B0EEFA;\n                    color: black;\n        " +
"        }\n\n                .topnav a.active {\n                    background-col" +
"or: #7ED8F9;\n                    color: #343E46;\n                }\n    </style>\n" +
"</head>\n<body>\n    <div");

WriteLiteral(" class=\"topnav\"");

WriteLiteral(">\n        <a");

WriteLiteral(" href=\"Inventory\"");

WriteLiteral(">Inventory</a>\n        <a");

WriteLiteral(" href=\"Equipment\"");

WriteLiteral(">Equipment</a>\n        <a");

WriteLiteral(" class=\"active\"");

WriteLiteral(" href=\"Contacts\"");

WriteLiteral(">Contacts</a>\n    </div>\n    <div>\n        <h2");

WriteLiteral(" id=\"Mainlbl\"");

WriteLiteral(">Contacts Page</h2>\n        <label");

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

WriteLiteral("/><br />\n        <label");

WriteLiteral(" id=\"Categorylbl\"");

WriteLiteral(" style=\"padding-left: 15px\"");

WriteLiteral(">Category: </label>\n        <select");

WriteLiteral(" id=\"Category\"");

WriteLiteral(">\n            <option");

WriteLiteral(" value=\"All\"");

WriteLiteral(">All</option>\n            <option");

WriteLiteral(" value=\"Id\"");

WriteLiteral(">Id</option>\n            <option");

WriteLiteral(" value=\"Name\"");

WriteLiteral(">Name</option>\n            <option");

WriteLiteral(" value=\"Phone\"");

WriteLiteral(">Phone</option>\n            <option");

WriteLiteral(" value=\"Email\"");

WriteLiteral(">Email</option>\n        </select>\n        <button");

WriteLiteral(" id=\"SearchButton\"");

WriteLiteral(">Search</button>\n        <div");

WriteLiteral(" id=\"divTable\"");

WriteLiteral("></div>\n        <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
            GenerateTable(""/api/Contacts/table/"");
            $(""#SearchButton"").click(function() {
                var model = {
                    Username: $(""#SearchBox"").val(),
                    Password: $(""#Category"").val()
                };
                $.post(""/api/Contact/SearchRequest"", model)
                    .done(function (data) {
                        GenerateTable(""/api/Contact/SearchInfo/"");
                    })
                    .fail(function() {
                        alert(""error"");
                    });
            });     
        </script>
    </div>
</body>
</html>");

}
}

// NOTE: this is the default generated helper class. You may choose to extract it to a separate file 
// in order to customize it or share it between multiple templates, and specify the template's base 
// class via the @inherits directive.
public abstract class ContactsBase
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
