using MongoDB.Driver;
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
        pokedexEntities context;
        public MyBusinessLogic()
        {
             context = new pokedexEntities();

        }

        public List<MYSQLProj.ActiveUsers_Month_Result> Acitve_Users_Month()
        {
            Starttime = DateTime.Now.Millisecond;
            List<MYSQLProj.ActiveUsers_Month_Result> result = context.ActiveUsers_Month().ToList();
            Endtime = DateTime.Now.Millisecond;
            AddLog(new logdata() { nombre = "ActiveUsers_Month", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (Endtime - Starttime) });
  
            return result;
        }
        //internal IEnumerable<string> UnusedSP()
        //{
        //    Starttime = DateTime.Now.Millisecond;
        //    List<string> result = context..ToList();
        //    Endtime = DateTime.Now.Millisecond;
        //    AddLog(new logdata() { nombre = "UnusedSP", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (Endtime - Starttime) });
        //    return result;
        //}
        public LocalUser Login(string username, string password)
        {
            Starttime = DateTime.Now.Millisecond;
            //Buscamos primero en Mongo
            LocalUser mongousuario = FindMongo(username, password);
            if (mongousuario == null)
            {
                //BUscamos en SQL 
                usuario MySQLuser = FindMySQL(username, password);
                if (MySQLuser != null)
                {
                    CreateMongo(MySQLuser.Nombre, MySQLuser.Apellido, MySQLuser.Password, MySQLuser.Admin.Value, MySQLuser.Username, MySQLuser.email, MySQLuser.DoB.Value, MySQLuser.UserId);
                    AddLog(new logdata() { nombre = MySQLuser.Username, tipo = "Login", fecha = DateTime.Now, UserId = MySQLuser.UserId, exec_time = (Endtime - Starttime) });

                    return new LocalUser(MySQLuser.UserId, MySQLuser.Nombre, MySQLuser.Apellido, MySQLuser.DoB, MySQLuser.Username, MySQLuser.Password, MySQLuser.email, MySQLuser.Admin, false);

                }
                else
                {
                    return null;
                }

            }
            else
            {
                //Si se encuentra en mongo 
                AddLog(new logdata() { nombre = mongousuario.Username, tipo = "Login", fecha = DateTime.Now, UserId = mongousuario.UserId, exec_time = (Endtime - Starttime) });

                return mongousuario;
            }



        }

        private void CreateMongo(string FirstName, string LastName, string pass, int Admin, string Username, string mail, DateTime DOB, int userid)
        {
            var mongo = new MongoClient("mongodb://localhost:27017");
            var db = mongo.GetDatabase("users");
            var collections = db.GetCollection<Usuario>("users");
            var x = collections.Find(_id => true).Sort("{UserId:-1}").Limit(1).ToList();
            var user = new Usuario
            {
                Nombre = FirstName,
                Apellido = LastName,
                Password = pass,
                email = mail,
                Admin = Admin,
                Username = Username,
                DoB = DOB,
                UserId = userid
            };
            collections.InsertOne(user);
        }

        private LocalUser FindMongo(string username, string password)
        {
            var mongo = new MongoClient("mongodb://localhost:27017");
            var db = mongo.GetDatabase("users");
            var collections = db.GetCollection<LocalUser>("users");
            var users = from u in collections.AsQueryable<LocalUser>()
                        where u.Username == username && u.Password == password
                        select u;
            if (users.Count() != 0)
            {
                return users.ToList<LocalUser>().First();
            }
            return null;
        }

        private usuario FindMySQL(string username, string password)
        {
            usuario user = context.usuarios.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            return user;
        }

        public void LogOut()
        {
            AddLog(new logdata() { nombre = SharedInstance.AppUser.Username, tipo = "Logout", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (Endtime - Starttime) });
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