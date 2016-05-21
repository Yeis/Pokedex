using PokedexFinalProject.Models;
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
        // GET: Stats
        [HttpGet]
        public ActionResult Index( )
        {
                var model = new StatsViewModel();
                  model.Options = BL.GetOptions();
                return View(model);
            //ListItem item = new ListItem();
            //List<ActiveUsers_Month_Result> temp = BL.Acitve_Users_Month();
        }
    
        [HttpPost]
        public ActionResult Index(StatsViewModel model)
        {
            model.Options = BL.GetOptions();

            switch (model.Selectedid)
            {
                case 1:
                    model.partialName = "ActiveUsersWeek";
                    model.ActiveUsersWeek = BL.Acitve_Users_Week();
                    break;
                case 2:
                    model.partialName = "ActiveUsersMonth";
                    model.ActiveUsersMonth = BL.Acitve_Users_Month();
                    break;
                case 3:
                    model.partialName = "ActiveUsersMonth";
                    model.ActiveUsersMonth = BL.Acitve_Users_Month();
                    break;
                case 4:
                    model.partialName = "ActiveUsersMonth";
                    model.ActiveUsersMonth = BL.Acitve_Users_Month();
                    break;
                case 5:
                    model.partialName = "SP_ConexionesActivas";
                    model.ActiveConnections = BL.GetActiveConnections();
                    break;
                case 6:
                    model.partialName = "ActiveUsersMonth";
                    model.ActiveUsersMonth = BL.Acitve_Users_Month();
                    break;
                case 7:
                    model.partialName = "ActiveUsersMonth";
                    model.ActiveUsersMonth = BL.Acitve_Users_Month();
                    break;
                default:
                    break;
            }

            return View(model);
        }


        public PartialViewResult ActiveUsersWeek(IEnumerable<PokedexFinalProject.ActiveUsers_Week_Result> weeks)
        {
            return PartialView(weeks);
        }

        public PartialViewResult ActiveUsersMonth(IEnumerable<PokedexFinalProject.ActiveUsers_Month_Result> months)
        {
            return PartialView(months);
        }


    }
}