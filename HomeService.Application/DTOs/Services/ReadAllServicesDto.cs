using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.DTOs.Services
{
    public class ReadAllServicesDto
    {
        public int CategoryId { get; set; }
        public string? CategoryType { get; set; }
        public string? CategoryName { get; set; }
    }
}
