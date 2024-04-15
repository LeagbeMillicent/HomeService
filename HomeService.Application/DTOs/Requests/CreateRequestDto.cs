using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.DTOs.Requests
{
    public class CreateRequestDto
    {
       
            public int CustomerId { get; set; }
            public string? Description { get; set; }
            public DateTime DateRequested { get; set; }
            public int? WorkerId { get; set; }
       
    }
}
