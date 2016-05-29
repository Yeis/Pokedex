using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokedexFinalProject.Models
{
    public class SPByUserViewModel
    {
        public string UserID { get; set; }
        public IEnumerable<SPByUser_Result> Procedures { get; set; }
        public IEnumerable<MYSQLProj .SPByUser_Result> MyProcedures { get; set; }


    }
}