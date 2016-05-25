using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PokedexFinalProject.Models;

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
            var pokemon = context.GetPokemonDetail(id).FirstOrDefault();
            return View(pokemon);
        }

 
        public ActionResult GetTypes()
        {
            var tipos = context.Tipoes.ToList();
            return View(tipos);
        }

        [HttpGet]
        public ActionResult GetByType(int id)
        {
            //var pokemon = context.GetPokemonByType(id).ToList();
            var tipos = new GetTypesViewModel(id);
            return View(tipos);
        }
    }
}