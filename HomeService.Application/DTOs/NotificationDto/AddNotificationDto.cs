using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.DTOs.NotificationDto
{
    public class AddNotificationDto
    {
        public int RecipientId { get; set; }
        public string? Message { get; set; }
        public DateTime DateSent { get; set; }
        public bool IsRead { get; set; }
    }
}
