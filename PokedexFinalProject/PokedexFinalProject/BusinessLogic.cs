using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokedexFinalProject
{
    public class BusinessLogic
    {
        int Starttime;
        int Endtime;
        PokedexEntities context;
        public BusinessLogic()
        {
            context = new PokedexEntities();
        }

        public LocalUser Login(string username, string password)
        {  
                Starttime = DateTime.Now.Millisecond;
                IQueryable<Usuario> usuario = context.Usuarios.Where(u => u.Username == username && u.Password == password);
                Endtime = DateTime.Now.Millisecond;
                List<Usuario> user = new List<Usuario>(usuario);

                //checamos si las credenciales fueron correctas 
                if (user.Count > 0)
                {
                    AddLog(new LogData() {  nombre = user[0].Username, tipo = "Login", fecha = DateTime.Now, UserId = user[0].UserID , exec_time = (Endtime - Starttime)});
                    return new LocalUser(user[0].UserID, user[0].FirstName, user[0].LastName, user[0].DOB, user[0].Username, user[0].Password, user[0].Email, user[0].Admin, false);
                }
                else
                {
                    return null;
                }
            
        }
        public List<ActiveUsers_Month_Result> Acitve_Users_Month()
        {
                Starttime = DateTime.Now.Millisecond;
                List<ActiveUsers_Month_Result> result = context.ActiveUsers_Month().ToList();
                Endtime = DateTime.Now.Millisecond;
               
                AddLog(new LogData() {   id= 10, nombre = "ActiveUsers_Month", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
                return result;
        }
        public List<ActiveUsers_Week_Result> Acitve_Users_Week()
        {
                Starttime = DateTime.Now.Millisecond;
                List<ActiveUsers_Week_Result> result = context.ActiveUsers_Week().ToList();
                Endtime = DateTime.Now.Millisecond;

                AddLog(new LogData() { id = 10, nombre = "ActiveUsers_Week", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
                return result;
        }
        public void AddLog(LogData log )
        {
               // context.LogDatas.Add(log);
                //context.SaveChanges();
        }
    }
}