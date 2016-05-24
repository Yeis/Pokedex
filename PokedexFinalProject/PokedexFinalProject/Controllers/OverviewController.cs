using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokedexFinalProject.Controllers
{
    public class OverviewController : Controller
    {
        PokedexEntities context = new PokedexEntities();
        // GET: Overview
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPokemon()
        {
            var lista = context.Pokemons.ToList();
            return View(lista);
        }
        [HttpGet]
        public ActionResult GetDetails(int id)
        {
            var pokemon = context.GetPokemonDetail(id).First();
            return View(pokemon);
        }
    }
}