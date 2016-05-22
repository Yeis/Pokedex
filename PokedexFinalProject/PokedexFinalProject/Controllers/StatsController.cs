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
        public ActionResult Index(StatsViewModel Model , bool diferente )
        {
           // if (Model.Selectedid < 1)
            //{
                var model = new StatsViewModel();
                model.Options = new[]
                {
                new SelectListItem {Value = "1" , Text = "Active Users Week" },
                new SelectListItem {Value = "2" , Text = "Active Users Month" }

            };
                return View(model);
            //}
            if (true)
            {

            }
            else
            {
                return View(model);
            }
            //ListItem item = new ListItem();
            //List<ActiveUsers_Month_Result> temp = BL.Acitve_Users_Month();
        }
    
        [HttpPost]
        public ActionResult Index(StatsViewModel model)
        {
            switch (model.Selectedid)
            {
                case 1:
                    model.partialName = "ActiveUsersWeek";
                    model.ActiveUsersWeek = BL.Acitve_Users_Week();
                    return RedirectToAction("Index", model);
                case 2:
                    model.partialName = "ActiveUsersMonth";
                    model.ActiveUsersMonth = BL.Acitve_Users_Month();
                    return RedirectToAction("Index", model);
                default:
                    break;
            }

            return View();
        }
      
    }
}