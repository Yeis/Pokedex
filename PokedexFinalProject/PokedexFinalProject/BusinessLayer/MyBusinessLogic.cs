using MYSQLProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokedexFinalProject.BusinessLayer
{
    public class MyBusinessLogic
    {
        int Starttime;
        int Endtime;
        MyPokedexEntities context;
        public MyBusinessLogic()
        {
             context = new MyPokedexEntities();

        }

        public List<MYSQLProj.ActiveUsers_Month_Result> Acitve_Users_Month()
        {
            Starttime = DateTime.Now.Millisecond;
            List<MYSQLProj.ActiveUsers_Month_Result> result = context.ActiveUsers_Month().ToList();
            Endtime = DateTime.Now.Millisecond;
            AddLog(new logdata() { nombre = "ActiveUsers_Month", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
  
            return result;
        }
        //internal IEnumerable<string> UnusedSP()
        //{
        //    Starttime = DateTime.Now.Millisecond;
        //    List<string> result = context..ToList();
        //    Endtime = DateTime.Now.Millisecond;
        //    AddLog(new logdata() { nombre = "UnusedSP", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
        //    return result;
        //}

        public void LogOut()
        {
            AddLog(new logdata() { nombre = SharedInstance.AppUser.Username, tipo = "Logout", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            SharedInstance.AppUser = null;
        }
        public void AddLog(logdata log)
        {
            log.id = context.logdatas.Count() + 1;
            context.logdatas.Add(log);
            context.SaveChanges();
        }
    }
}