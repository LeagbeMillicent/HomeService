using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain
{
    public class tblRequest
    {

        public int ReqId { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public tblCustomer? Customer { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
        public DateTime DateRequested { get; set; }
        public int? WorkerId { get; set; }
        [ForeignKey("WorkerId")]
        public tblWorker? Worker { get; set; }
        public DateTime? DateAssigned { get; set; }



    }


}
