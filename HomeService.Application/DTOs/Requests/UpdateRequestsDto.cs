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
        public string? UserName { get; set; }

        public string? Location { get; set; }

        public string? Contact { get; set; }

        public string? ServiceDescription { get; set; }
    }
}
