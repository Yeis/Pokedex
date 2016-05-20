using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokedexFinalProject.Models
{
    public class StatsViewModel
    {
        [DisplayName("Select Option")]
        public int Selectedid { get; set; }
        public IEnumerable<SelectListItem> Options { get; set; }
        public string partialName { get; set; }




        //Stats Collection
        public IEnumerable<ActiveUsers_Month_Result> ActiveUsersMonth { get; set; }
        public IEnumerable<ActiveUsers_Week_Result> ActiveUsersWeek { get; set; }

    }
}