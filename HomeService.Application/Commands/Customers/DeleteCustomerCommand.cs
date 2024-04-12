using HomeService.Application.DTOs.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Customers
{
    public class DeleteCustomerCommand
    {
        public DeleteCustomersDto dto { get; set; }
    }
}
