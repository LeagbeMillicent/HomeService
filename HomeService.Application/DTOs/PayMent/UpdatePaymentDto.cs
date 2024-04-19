using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.DTOs.PayMent
{
    public class UpdatePaymentDto
    {
        public int PaymentId { get; set; }
        public int RequestId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
    }
}
