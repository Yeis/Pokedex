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
        public IEnumerable<string> Unused { get; set; }

        //  public IEnumerable<UnusedSP_> Vistas { get; set; }
        public GetUserContains _GetUserContains { get; set; }
        public SPByUserViewModel _SPByUserViewModel { get; set; }

        public SPRangeViewModel _SPRangeViewModel { get; set; }
        public SPbyHourViewModel _SPbyHourViewModel { get; set; }
        public  ColumnsViewModel _ColumnsViewModel { get; set; }

        //Stats de MYSQL
        public IEnumerable<MYSQLProj.ActiveUsers_Month_Result> MyActiveUsersMonth { get; set; }
        public IEnumerable<MYSQLProj.ActiveUsers_Week_Result> MyActiveUsersWeek { get; set; }
        public IEnumerable<MYSQLProj.SP_ConexionesActivas_Result> MyActiveConnections { get; set; }
        public IEnumerable<MYSQLProj.SP_ListaIndices_Result> MyIndexes { get; set; }
        public IEnumerable<MYSQLProj.SP_Lista_Tablas_Result> MyTablas { get; set; }
        public IEnumerable<MYSQLProj.SP_Lista_Mil_Registros_Result> MyTablasMil { get; set; }
        public IEnumerable<MYSQLProj.SP_InfoSP_Result> MyMaxMinSP { get; set; }
        public IEnumerable<MYSQLProj.SP_ListaViews_Result> MyVistas { get; set; }
        public IEnumerable<MYSQLProj.SPExecAverage_Result> MyExecAverage { get; set; }
        public IEnumerable<MYSQLProj.GetLoginDays_Result> MyDias { get; set; }
        public IEnumerable<MYSQLProj.GetLoginHours_Result> MyHoras { get; set; }
        public IEnumerable<MYSQLProj.InactiveUsers_Month_Result> MyInactive { get; set; }
        public IEnumerable<MYSQLProj.SPCount_Result> MySPCounts { get; set; }
        public IEnumerable<MYSQLProj.GetUserSubtotals_Result> MySubtotals { get; set; }
        public IEnumerable<string> MyUnused { get; set; }

    

        public StatsViewModel()
        {
            Options = new[]
                {
                new SelectListItem { Value = "0" , Text= ""},
                new SelectListItem {Value = "1" , Text = "Active Users Week" },
                new SelectListItem {Value = "2" , Text = "Active Users Month" },
                new SelectListItem {Value = "3" , Text = "DB Indexes" },
                new SelectListItem { Value = "4" , Text= "SP Range By Hours"},
                new SelectListItem {Value = "5" , Text = "Active DB Connections" },
                new SelectListItem {Value = "6" , Text = "DB Tables with Count" },
                new SelectListItem {Value = "7" , Text = "Table Columns" },
                new SelectListItem {Value = "8" , Text = "Table Over 100 Rows" },
               new SelectListItem {Value = "9" , Text = "DB Views" },
                new SelectListItem {Value = "10" , Text = "Most Used SP" },
                 new SelectListItem {Value = "11" , Text = "SP in Range" },
                new SelectListItem {Value = "12" , Text = " Unused SP" },
                  new SelectListItem {Value = "13" , Text = "Average SP Execution" },
                new SelectListItem {Value = "14" , Text = "SP Executions" },
                 new SelectListItem {Value = "15" , Text = "Inactive Users Month " },
                new SelectListItem {Value = "16" , Text = " Most Visited Days" },
                new SelectListItem {Value = "17" , Text = " Most Visited Hours" },
                new SelectListItem {Value = "18" , Text = "SP by User" },
                new SelectListItem {Value = "19" , Text = " User Subtotal" },
                new SelectListItem {Value = "20" , Text = " Search users" }
                };
        }
    }
}