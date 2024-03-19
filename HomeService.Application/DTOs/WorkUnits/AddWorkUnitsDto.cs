using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.DTOs.WorkUnits
{
    public class AddWorkUnitsDto
    {
        public string? WorkUnitsName { get; set; }
        public string? WorkUnitsDescription { get; set; }
        public int WorkUnitDuration { get; set; }
    }
}
