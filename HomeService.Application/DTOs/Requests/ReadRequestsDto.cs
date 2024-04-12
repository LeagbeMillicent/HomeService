using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.DTOs.Requests
{
    public class ReadRequestsDto
    {
        //public int RequestId { get; set; }
        public string? UserName { get; set; }

        public string? Location { get; set; }

        public string? Contact { get; set; }

        public string? ServiceDescription { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime? UpdatedAt { get; set; }

        //public bool IsCompleted { get; set; }
    }
}
