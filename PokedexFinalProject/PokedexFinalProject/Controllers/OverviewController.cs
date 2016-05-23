using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokedexFinalProject.Controllers
{
    public class OverviewController : Controller
    {
        PokedexEntities context;
        // GET: Overview
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPokemon()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetDetails(/*int id*/)
        {
            //context = new PokedexEntities();
            //var test = context.GetPokemonDetail(id);
            return View();
        }
    }
}