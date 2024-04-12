using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain
{
    public class tblRequest
    {
     
            public int ReqId { get; set; }

            [Required]
            public string? UserName { get; set; }

            [Required]
            public string? Location { get; set; }

            [Required]
            public string? Contact { get; set; }

            [Required]
            public string? ServiceDescription { get; set; }

   
        
    }


}
