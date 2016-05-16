using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokedexFinalProject
{
    public class BusinessLogic
    {
        public BusinessLogic()
        {

        }

        public LocalUser Login(string username, string password)
        {
            using (var context = new PokedexEntities())
            {
                int startime = DateTime.Now.Millisecond;
                IQueryable<Usuario> usuario = context.Usuarios.Where(u => u.Username == username && u.Password == password);
                int endtime = DateTime.Now.Millisecond;
                List<Usuario> user = new List<Usuario>(usuario);

                //checamos si las credenciales fueron correctas 
                if (user.Count > 0)
                {
                    LogData log = new LogData()
                    {
                        nombre = user[0].Username,
                        tipo = "Login",
                        fecha = DateTime.Now,
                        UserId = user[0].UserID,
                        exec_time = (endtime - startime)
                    };
                    
                    context.LogDatas.Add(log);
                    context.SaveChanges();
                    return new LocalUser(user[0].UserID, user[0].FirstName, user[0].LastName, user[0].DOB, user[0].Username, user[0].Password, user[0].Email, user[0].Admin, false);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}