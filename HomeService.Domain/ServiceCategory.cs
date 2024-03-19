using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain
{
    public class ServiceCategory
    {
        public int CategoryId { get; set; }
        public string? CategoryType { get; set; }
        public string? CategoryName { get; set; }
    }
}
