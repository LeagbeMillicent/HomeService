﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.DTOs.Workers
{
    public class AddWorkersDto
    {
        public string? WorkerName { get; set; }
        public string? WorkerLocation { get; set; }
        public string? WorkerContact { get; set; }
        public string? WorkerEmail { get; set; }
    }
}
