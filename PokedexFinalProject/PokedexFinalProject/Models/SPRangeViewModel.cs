using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokedexFinalProject.Models
{
    public class SPRangeViewModel
    {

        public string limite_inferior { get; set; }
        public string limite_superior { get; set; }

        public IEnumerable<SPInRange_Result> _SPRange { get; set; }

        public IEnumerable<MYSQLProj.SPInRange_Result> _MySPRange { get; set; }


    }
}