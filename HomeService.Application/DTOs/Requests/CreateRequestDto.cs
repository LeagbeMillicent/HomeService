using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.DTOs.Requests
{
    public class CreateRequestDto
    {
        public DateTime RequestDate { get; set; }
        public string? RequestTitle { get; set; }
    }
}
