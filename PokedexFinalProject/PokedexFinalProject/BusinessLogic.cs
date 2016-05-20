using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            //Buscamos primero en Mongo
            Usuario usuario = FindMongo(username, password);
            if (usuario == null)
            {
                //BUscamos en SQL 
                usuario = FindSQL(username, password);
                if (usuario != null)
                {
                    CreateMongo(usuario.FirstName,usuario.LastName,usuario.Password,usuario.Admin.Value,usuario.Username,usuario.Email,usuario.DOB.Value);
                }
            }
            Endtime = DateTime.Now.Millisecond;
            //checamos si las credenciales fueron correctas 
            if (usuario != null)
            {
                AddLog(new LogData() {  nombre = usuario.Username, tipo = "Login", fecha = DateTime.Now, UserId = usuario.UserID , exec_time = (Endtime - Starttime)});
                return new LocalUser(usuario.UserID, usuario.FirstName, usuario.LastName, usuario.DOB, usuario.Username, usuario.Password, usuario.Email, usuario.Admin, false);
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
 public Usuario FindSQL(string username, string password) 
        {
            Usuario user = context.Usuarios.Where(u => u.Username == username && u.Password == password).FirstOrDefault(); 
            return user;
        }
        public Usuario FindMongo(string username, string pass)
        {
            var mongo = new MongoClient("mongodb://localhost:27017");
            var db = mongo.GetDatabase("users");
            var collections = db.GetCollection<Usuario>("users");
            var users = from u in collections.AsQueryable<Usuario>()
                        where u.Username == username && u.Password == pass
                        select u;
            if (users.Count() != 0)
            {
                return users.ToList<Usuario>().First();
            }
            return null;
        }
              public IEnumerable<SelectListItem> GetOptions()
        {
            IEnumerable<SelectListItem> options = new[]
                {
                new SelectListItem { Value = "0" , Text= ""},
                new SelectListItem {Value = "1" , Text = "Active Users Week" },
                new SelectListItem {Value = "2" , Text = "Active Users Month" }

            };

            return options;}
        static void CreateMongo(string FirstName, string LastName, string pass, int Admin, string Username, string mail, DateTime DOB)
        {
            var mongo = new MongoClient("mongodb://localhost:27017");
            var db = mongo.GetDatabase("users");
            var user = new Usuario
            {
                FirstName = FirstName,
                LastName = LastName,
                Password = pass,
                Email = mail,
                Admin = Admin,
                Username = Username,
                DOB = DOB
            };
            var collections = db.GetCollection<Usuario>("users");
            collections.InsertOne(user);
        }
    }
}