using Backend.Templates.TemplateComponents;
using System;
using System.Collections.Generic;

namespace Backend.Templates
{
    public class Template
    {
        int systemTemplateID { get; set; }
        String name { get; set; }

        List<TemplateComponent> components { get; set; }
    }
}
