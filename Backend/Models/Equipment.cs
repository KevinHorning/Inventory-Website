﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Equipment
    {
        public int equipmentID { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string notes { get; set; }
    }
}
