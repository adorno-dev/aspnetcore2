﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCore2.Mvc.ViewComponents.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public bool IsDone { get; set; }
        public string Name { get; set; }
    }
}
