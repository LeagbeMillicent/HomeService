using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain
{
    public class tblAdmin
    {
        public int AdminId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
