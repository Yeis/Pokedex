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
        public IEnumerable<SP_ConexionesActivas_Result> ActiveConnections { get; set; }
        public IEnumerable<SP_ListaIndices_Result> Indexes { get; set; }
        public IEnumerable<SP_Lista_Tablas_Result> Tablas { get; set; }
        public IEnumerable<SP_Lista_Mil_Registros_Result> TablasMil { get; set; }
        public IEnumerable<SP_InfoSp_Result> MaxMinSP { get; set; }
        public IEnumerable<SP_ListaViews_Result> Vistas { get; set; }
        public IEnumerable<SPExecAverage_Result> ExecAverage { get; set; }
        public IEnumerable<GetLoginDays_Result> Dias { get; set; }
        public IEnumerable<GetLoginHours_Result> Horas { get; set; }
        public IEnumerable<InactiveUsers_Month_Result> Inactive { get; set; }
        public IEnumerable<SPCount_Result> SPCounts { get; set; }
        public IEnumerable<GetUserSubtotals_Result> Subtotals { get; set; }

        //  public IEnumerable<UnusedSP_> Vistas { get; set; }
        public GetUserContains _GetUserContains { get; set; }
        public SPByUserViewModel _SPByUserViewModel { get; set; }

        public SPRangeViewModel _SPRangeViewModel { get; set; }
        public SPbyHourViewModel _SPbyHourViewModel { get; set; }
        public  ColumnsViewModel _ColumnsViewModel { get; set; }



    }
}