using PokedexFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokedexFinalProject.Controllers
{
    public class BackupController : Controller
    {
        // GET: Backup
        public ActionResult Index()
        {
            BackupViewModel model = new BackupViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Backup(BackupViewModel model)
        {
            DataBaseManager DM = new DataBaseManager();
            string succeded;
            switch (model.Selectedid)
            {
                case 1:
                    //Backup SQL Server
                    try
                    {
                       succeded = DM.BackupSQL();
                    }
                    catch (Exception)
                    {
                        model.backupPath = "Hubo un error, no se pudo hacer el backup";
                        return View("Index",model);
                        throw;
                    }
                    model.backupPath = "El respaldo se completo exitosamente en " + succeded;
                    return View("Index",model);
                case 2:
                    //Backup MySQL
                    try
                    {
                        succeded = DM.BackupMySQL();
                    }
                    catch (Exception)
                    {
                        model.backupPath = "Hubo un error, no se pudo hacer el backup";
                        return View("Index", model);
                        throw;
                    }
                    model.backupPath = "El respaldo se completo exitosamente en " + succeded;
                    return View("Index", model);
                default:
                    model.backupPath = "Seleciona una opcion Valida";
                    return View("Index", model);
                  
            }
      
        }
    }
}