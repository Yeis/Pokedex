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
        BusinessLogic BL = new BusinessLogic();
        int Starttime, Endtime;
        // GET: Overview
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult Index(string searchBar)
        {
            return View();
        }

        public ActionResult GetPokemon()
        {
            var lista = context.Pokemons.ToList();
          
            return View(lista.ToList());
        }
        [HttpGet]
        public ActionResult GetDetails(string SearchString)
        {
            int id;
            if(Int32.TryParse(SearchString, out id))
            {
                var pokemon = new PokemonViewModel(id);
                return View(pokemon);
            }
            else
            {
                Starttime = DateTime.Now.Millisecond;
                var pokemon = context.GetPokemonByName(SearchString).FirstOrDefault();
                Endtime = DateTime.Now.Millisecond;
                BL.AddLog(new LogData() { nombre = "GetPokemonByName", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (Endtime - Starttime) });
                if (pokemon != null)
                {
                    var det = new PokemonViewModel(pokemon.PokemonID);
                    return View(det);
                }
                else
                {

                    return View(new PokemonViewModel());
                }
            }
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

        [HttpGet]
        public ActionResult GetMoves()
        {
            var moves = context.Moves.ToList();
            return View(moves);
        }
        [HttpGet]
        public ActionResult searchbar()
        {
            return View();
        }
    }
}