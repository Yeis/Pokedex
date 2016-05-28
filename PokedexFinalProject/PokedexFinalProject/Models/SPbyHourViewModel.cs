using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokedexFinalProject.Models
{
    public class SPbyHourViewModel
    { 
        public string  Hour1 { get; set; }
        public string Hour2 { get; set; }
        public IEnumerable<GetSPByHour_Result> SPByHour { get; set; }

    }
}