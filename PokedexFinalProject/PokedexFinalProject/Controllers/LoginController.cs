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
        public ActionResult Index()
        {
            return View();
        }
        //Index despues de login incorrecto 
        [HttpPost]
        public ActionResult Index(LoginViewModels model)
        {
            //logica del login 
            SharedInstance.AppUser = BL.Login(model.Username, model.Password);
            if (SharedInstance.AppUser == null)
            {
                //el usuario fue incorrecto
                return RedirectToAction("Index", new { mensaje = "Oops EL usuario no existe!" });
            }
            else
            {
                //el usuario fue correcto 
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            SharedInstance.AppUser = BL.Login(username, password);

            if (SharedInstance.AppUser == null)
            {
                //el usuario fue incorrecto
                return RedirectToAction("Index", new { mensaje = "Oops EL usuario no existe!" });
            }
            else
            {
                //el usuario fue correcto 
            }
            return View();
        }

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
      