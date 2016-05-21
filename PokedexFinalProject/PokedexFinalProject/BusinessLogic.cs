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
            LocalUser mongousuario = FindMongo(username, password);
            if (mongousuario == null)
            {
                //BUscamos en SQL 
                Usuario SQLuser = FindSQL(username, password);
                if (SQLuser != null)
                {
                    CreateMongo(SQLuser.FirstName, SQLuser.LastName, SQLuser.Password, SQLuser.Admin.Value, SQLuser.Username, SQLuser.Email, SQLuser.DOB.Value);
                    AddLog(new LogData() { nombre = SQLuser.Username, tipo = "Login", fecha = DateTime.Now, UserId = SQLuser.UserID, exec_time = (Endtime - Starttime) });

                    return new LocalUser(SQLuser.UserID, SQLuser.FirstName, SQLuser.LastName, SQLuser.DOB, SQLuser.Username, SQLuser.Password, SQLuser.Email, SQLuser.Admin, false);

                }
                else
                {
                    return null;
                }
              
            }
            else
            {
                //Si se encuentra en mongo 
                AddLog(new LogData() { nombre = mongousuario.Username, tipo = "Login", fecha = DateTime.Now, UserId = mongousuario.UserID, exec_time = (Endtime - Starttime) });

                return mongousuario;
            }

         
            
        }
        public List<ActiveUsers_Month_Result> Acitve_Users_Month()
        {
                Starttime = DateTime.Now.Millisecond;
                List<ActiveUsers_Month_Result> result = context.ActiveUsers_Month().ToList();
                Endtime = DateTime.Now.Millisecond;
               
                AddLog(new LogData() {   nombre = "ActiveUsers_Month", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
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

        public void LogOut()
        {
            AddLog(new LogData() { nombre = SharedInstance.AppUser.Username, tipo = "Logout", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            SharedInstance.AppUser = null;
        }
        public void AddLog(LogData log )
        {
               context.LogDatas.Add(log);
                context.SaveChanges();
        }
 public Usuario FindSQL(string username, string password) 
        {
            Usuario user = context.Usuarios.Where(u => u.Username == username && u.Password == password).FirstOrDefault(); 
            return user;
        }
        public LocalUser FindMongo(string username, string pass)
        {
            var mongo = new MongoClient("mongodb://localhost:27017");
            var db = mongo.GetDatabase("users");
            var collections = db.GetCollection<LocalUser>("users");
            var users = from u in collections.AsQueryable<LocalUser>()
                        where u.Username == username && u.Password == pass
                        select u;
            if (users.Count() != 0)
            {
                return users.ToList<LocalUser>().First();
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