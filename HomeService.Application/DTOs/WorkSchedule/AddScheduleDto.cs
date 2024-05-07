using HomeService.Application.DTOs.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.DTOs.WorkSchedule
{
    public class AddScheduleDto
    {
        public int WorkerId { get; set; }
        public DateTime Date { get; set; }
        public ReadWorkersDetailsDto WorkersDetailsDto { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
