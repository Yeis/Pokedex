using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokedexFinalProject.Models
{
    public class GetUserContains
    {
        public string patron { get; set; }
        public IEnumerable<GetUserContains_Result> users { get; set; }
        public IEnumerable<MYSQLProj.GetUserContains_Result> Myusers { get; set; }

    }
}