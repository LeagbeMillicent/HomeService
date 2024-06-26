﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.DTOs.Workers
{
    public class ReadWorkersDetailsDto
    {
        public int WorkerId { get; set; }
        public string? WorkerName { get; set; }
        public string? WorkerLocation { get; set; }
        public int WorkerContact { get; set; }
        public string? WorkerAddress { get; set; }
    }
}
