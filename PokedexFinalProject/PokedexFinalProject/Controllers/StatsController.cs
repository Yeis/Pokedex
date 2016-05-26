﻿using PokedexFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PokedexFinalProject.Controllers
{
    public class StatsController : Controller
    {
        BusinessLogic BL = new BusinessLogic();
        BusinessLayer.MyBusinessLogic MyBL = new BusinessLayer.MyBusinessLogic();
        // GET: Stats
        [HttpGet]
        public ActionResult Index( )
        {
                var model = new StatsViewModel();
             model.Horas = BL.HotHours();
            model.MaxMinSP = BL.MaxMinSP();
            model.SPCounts = BL.ExecCount();
            //model.MySPCo
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(StatsViewModel model)
        {
            //SQL_Server Case 
            if (SharedInstance.AppUser.Connection == false)
            {
                model = SQL_Action(model);
            }
            else
            {
                model = MYSQL_Action(model);
            }

            return View(model);
        }
        public ActionResult SPByHour(SPbyHourViewModel model)
        { 
            model.SPByHour = BL.GetSPbyHour(int.Parse(model.Hour1),int.Parse(model.Hour2));
            StatsViewModel temp = new StatsViewModel();
            temp._SPbyHourViewModel = model;
            temp.partialName = "SPRangeHours";
            return View("Index", temp);        
        }
        public ActionResult Columns(ColumnsViewModel model)
        {
            model.Columnas = BL.GetColumns(model.NombreTabla);
            StatsViewModel temp = new StatsViewModel();
            temp._ColumnsViewModel = model;
            temp.partialName = "TableColumns";
            return View("Index",temp);
        }
        public ActionResult SPRange(SPRangeViewModel model)
        {
            model._SPRange = BL.SPInRange(int.Parse(model.limite_inferior), int.Parse(model.limite_superior));
            StatsViewModel temp = new StatsViewModel();
            temp._SPRangeViewModel = model;
            temp.partialName = "SPRange";
            return View("Index", temp);
        }
        public ActionResult SPByUser(SPByUserViewModel model)
        {
            model.Procedures = BL.SPByUser(int.Parse(model.UserID));
            StatsViewModel temp = new StatsViewModel();
            temp._SPByUserViewModel = model;
            temp.partialName = "SPByUser";
            return View("Index", temp);
        }
        public ActionResult GetUserContains(GetUserContains model)
        {
            model.users = BL.GetUserContains(model.patron);
            StatsViewModel temp = new StatsViewModel();
            temp._GetUserContains = model;
            temp.partialName = "GetUserContains";
            return View("Index", temp);
        }



        public StatsViewModel SQL_Action(StatsViewModel model) 
        {
            switch (model.Selectedid)
            {
                case 1:
                    //Estadisticas 12.1
                    model.partialName = "ActiveUsersWeek";
                    model.ActiveUsersWeek = BL.Acitve_Users_Week();
                    break;
                case 2:
                    //Estadisticas 12.2
                    model.partialName = "ActiveUsersMonth";
                    model.ActiveUsersMonth = BL.Acitve_Users_Month();
                    break;
                case 3:
                    //Estadisticas 5
                    model.partialName = "DBIndexes";
                    model.Indexes = BL.GetIndexes();
                    break;
                case 4:
                    //Estadisticas 1  
                    model.partialName = "SPRangeHours";
                    model._SPbyHourViewModel = new SPbyHourViewModel();
                    break;
                case 5:
                    //Estaditicas 2
                    model.partialName = "SP_ConexionesActivas";
                    model.ActiveConnections = BL.GetActiveConnections();
                    break;
                case 6:
                    //Estadisticas 3 
                    model.partialName = "TablesWithCounts";
                    model.Tablas = BL.TableWithCounts();
                    break;
                case 7:
                    //Estadisticas 4 
                    model.partialName = "TableColumns";
                    model._ColumnsViewModel = new ColumnsViewModel();
                    break;
                case 8:
                    //Estadisticas 8
                    model.partialName = "Tables1000";
                    model.TablasMil = BL.Table1000();
                    break;
                case 9:
                    //Estadisticas 6
                    model.partialName = "Views";
                    model.Vistas = BL.GetViews();
                    break;
                case 10:
                    //Estadisticas 7 NO PROBADO 
                    model.partialName = "MaxMin_SP";
                    model.MaxMinSP = BL.MaxMinSP();
                    break;
                case 11:
                    //Estadisticas 9 
                    model.partialName = "SPRange";
                    model._SPRangeViewModel = new SPRangeViewModel();
                    break;
                case 12:
                    //Estadisticas 10  
                    model.partialName = "UnusedSP";
                    model.Unused = BL.UnusedSP();
                    break;
                case 13:
                    //Estadisticas 11.1 
                    model.partialName = "ExecAvg";
                    model.ExecAverage = BL.ExecAvg();
                    break;
                case 14:
                    //Estadisticas 11.2 
                    model.partialName = "ExecCount";
                    model.SPCounts = BL.ExecCount();
                    break;
                case 15:
                    //Estadisticas 12.3
                    model.partialName = "InactiveUsers";
                    model.Inactive = BL.InactiveUsers();
                    break;
                case 16:
                    //Estadisticas 12.4
                    model.partialName = "HotDays";
                    model.Dias = BL.HotDays();
                    break;
                case 17:
                    //Estadisticas 12.4  
                    model.partialName = "HotHours";
                    model.Horas = BL.HotHours();
                    break;
                case 18:
                    //Estadisticas 12.6
                    model.partialName = "SPByUser";
                    model._SPByUserViewModel = new SPByUserViewModel();
                    break;
                case 19:
                    //Estadisticas 12.7  
                    model.partialName = "GetUserSubtotals";
                    model.Subtotals = BL.GetUsersSubtotals();
                    break;
                case 20:
                    //Estadisticas 13
                    model.partialName = "GetUserContains";
                    model._GetUserContains = new GetUserContains();
                    break;

                default:
                    break;
            }
            return model;
        }
        public StatsViewModel MYSQL_Action(StatsViewModel model)
        {
            switch (model.Selectedid)
            {
                case 1:
                    //Estadisticas 12.1
                    model.partialName = "MyActiveUsersWeek";
                    model.ActiveUsersWeek = BL.Acitve_Users_Week();
                    break;
                case 2:
                    //Estadisticas 12.2
                    model.partialName = "MyActiveUsersMonth";
                    model.MyActiveUsersMonth = MyBL.Acitve_Users_Month();
                    break;
                case 3:
                    //Estadisticas 5
                    model.partialName = "MyDBIndexes";
                    model.Indexes = BL.GetIndexes();
                    break;
                case 4:
                    //Estadisticas 1  
                    model.partialName = "MySPRangeHours";
                    model._SPbyHourViewModel = new SPbyHourViewModel();
                    break;
                case 5:
                    //Estaditicas 2
                    model.partialName = "MySP_ConexionesActivas";
                    model.ActiveConnections = BL.GetActiveConnections();
                    break;
                case 6:
                    //Estadisticas 3 
                    model.partialName = "MyTablesWithCounts";
                    model.Tablas = BL.TableWithCounts();
                    break;
                case 7:
                    //Estadisticas 4 
                    model.partialName = "MyTableColumns";
                    model._ColumnsViewModel = new ColumnsViewModel();
                    break;
                case 8:
                    //Estadisticas 8
                    model.partialName = "MyTables1000";
                    model.TablasMil = BL.Table1000();
                    break;
                case 9:
                    //Estadisticas 6
                    model.partialName = "MyViews";
                    model.Vistas = BL.GetViews();
                    break;
                case 10:
                    //Estadisticas 7 NO PROBADO 
                    model.partialName = "MyMaxMin_SP";
                    model.MaxMinSP = BL.MaxMinSP();
                    break;
                case 11:
                    //Estadisticas 9 
                    model.partialName = "MySPRange";
                    model._SPRangeViewModel = new SPRangeViewModel();
                    break;
                case 12:
                    //Estadisticas 10  
                    model.partialName = "MyUnusedSP";
                    model.Unused = BL.UnusedSP();
                    break;
                case 13:
                    //Estadisticas 11.1 
                    model.partialName = "MyExecAvg";
                    model.ExecAverage = BL.ExecAvg();
                    break;
                case 14:
                    //Estadisticas 11.2 
                    model.partialName = "MyExecCount";
                    model.SPCounts = BL.ExecCount();
                    break;
                case 15:
                    //Estadisticas 12.3
                    model.partialName = "MyInactiveUsers";
                    model.Inactive = BL.InactiveUsers();
                    break;
                case 16:
                    //Estadisticas 12.4
                    model.partialName = "MyHotDays";
                    model.Dias = BL.HotDays();
                    break;
                case 17:
                    //Estadisticas 12.4  
                    model.partialName = "MyHotHours";
                    model.Horas = BL.HotHours();
                    break;
                case 18:
                    //Estadisticas 12.6
                    model.partialName = "MySPByUser";
                    model._SPByUserViewModel = new SPByUserViewModel();
                    break;
                case 19:
                    //Estadisticas 12.7  
                    model.partialName = "MyGetUserSubtotals";
                    model.Subtotals = BL.GetUsersSubtotals();
                    break;
                case 20:
                    //Estadisticas 13
                    model.partialName = "MyGetUserContains";
                    model._GetUserContains = new GetUserContains();
                    break;

                default:
                    break;
            }
            return model;
        }



    }
}