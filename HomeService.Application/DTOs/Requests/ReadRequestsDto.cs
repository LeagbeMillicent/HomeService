using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.DTOs.Requests
{
    public class ReadRequestsDto
    {
        public int ReqId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DateRequested { get; set; }
        public int? WorkerId { get; set; }
        public string? WorkerName { get; set; }
        public DateTime? DateAssigned { get; set; }
    }
}
