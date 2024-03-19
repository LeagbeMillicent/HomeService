using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.DTOs.WorkUnits
{
    public class UpdateWorkUnitsDto
    {
        public int WorkUnitsId { get; set; }
        public string? WorkUnitsName { get; set; }
        public string? WorkUnitsDescription { get; set; }
        public int WorkUnitDuration { get; set; }
    }
}
