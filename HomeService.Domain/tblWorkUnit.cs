﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain
{
    public class tblWorkUnit
    {
        public int UnitId { get; set; }
        public int WorkerId { get; set; }
        [ForeignKey("WorkerId")]
        public tblWorker? Worker { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
