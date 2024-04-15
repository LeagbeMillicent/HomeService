using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain
{
    public class tblWorkSchedule
    {
        public int ScheduleId { get; set; }
        public int WorkerId { get; set; }
        [ForeignKey("WorkerId")]
        public tblWorker Worker { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
