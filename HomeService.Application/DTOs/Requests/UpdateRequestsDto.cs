using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.DTOs.Requests
{
    public class UpdateRequestsDto
    {
        public int ReqId { get; set; }
        public int CustomerId { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
        public int? WorkerId { get; set; }
        public DateTime? DateAssigned { get; set; }
        public DateTime DateRequested { get; set; }
    }
}
