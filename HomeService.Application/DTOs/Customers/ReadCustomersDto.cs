using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.DTOs.Customers
{
    public class ReadCustomersDto
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerLocation { get; set; }
        public int? CustomerContact { get; set; }
        public string? CustomerAddress { get; set; }
    }
}
