using PokedexFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokedexFinalProject.Controllers
{
    public class LoginController : Controller
    {

        BusinessLogic BL = new BusinessLogic();
        // GET: Login
        public ActionResult Index(string mensaje)
        {

            var poke = BL.GetPokemonDetails(2);
            ViewBag.Message = mensaje;
            return View();
        }
        //Index despues de login  
        [HttpPost]
        public ActionResult Index(LoginViewModels model)
        {
            //logica del login 
            SharedInstance.AppUser = BL.Login(model.Username, model.Password);
            if (SharedInstance.AppUser == null)
            {
                //el usuario fue incorrecto
                ViewBag.Message = "Usuario Incorrecto";
                return RedirectToAction("Index" , new { mensaje = "Usuario Incorrecto" });
            }
            else
            {
                //el usuario fue correcto 
                return RedirectToAction("Index","Overview");
            }
          
        }

        //[HttpPost]
        //public ActionResult Index(string mensaje)
        //{
        //    ViewBag.Message = mensaje;
        //    return View();
        //}

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModels model)
        {
            //logica de registro 
            return View();
        }

    }
}
      