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
                    CreateMongo(SQLuser.Nombre, SQLuser.Apellido, SQLuser.Password, SQLuser.Admin.Value, SQLuser.Username, SQLuser.email, SQLuser.DoB.Value , SQLuser.UserId);
                    AddLog(new LogData() { nombre = SQLuser.Username, tipo = "Login", fecha = DateTime.Now, UserId = SQLuser.UserId, exec_time = (Endtime - Starttime) });

                    return new LocalUser(SQLuser.UserId, SQLuser.Nombre, SQLuser.Apellido, SQLuser.DoB, SQLuser.Username, SQLuser.Password, SQLuser.email, SQLuser.Admin, false);

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
        //public List<SP_ConexionesActivas_Result> GetActiveConnections()
        //{
        //    Starttime = DateTime.Now.Millisecond;
        //    List<SP_ConexionesActivas_Result> result = context.SP_ConexionesActivas().ToList();
        //    Endtime = DateTime.Now.Millisecond;

        //    AddLog(new LogData() { nombre = "SP_ConexionesActivas", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
        //    return result;


        //}
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

                AddLog(new LogData() { nombre = "ActiveUsers_Week", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
                return result;
        }
        public GetPokemonDetail_Result GetPokemonDetails(int id)
        {
            Starttime = DateTime.Now.Millisecond;
            GetPokemonDetail_Result result = context.GetPokemonDetail(id).FirstOrDefault();
            Endtime = DateTime.Now.Millisecond;

            AddLog(new LogData() { nombre = "GetPokemonDetail", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;

        }

        public void LogOut()
        {
            AddLog(new LogData() { nombre = SharedInstance.AppUser.Username, tipo = "Logout", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            SharedInstance.AppUser = null;
        }
        public void AddLog(LogData log )
        {
            log.id = context.LogDatas.Count() + 1;
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
                new SelectListItem {Value = "2" , Text = "Active Users Month" },
                new SelectListItem {Value = "3" , Text = "Active Users Month" },
                new SelectListItem { Value = "4" , Text= "SP Range By Hours"},
                new SelectListItem {Value = "5" , Text = "Active DB Connections" },
                new SelectListItem {Value = "6" , Text = "DB Tables with Count" },
                new SelectListItem {Value = "7" , Text = "Table Columns" }


            };

            return options;}
        static void CreateMongo(string FirstName, string LastName, string pass, int Admin, string Username, string mail, DateTime DOB , int userid)
        {
            var mongo = new MongoClient("mongodb://localhost:27017");
            var db = mongo.GetDatabase("users");
            var collections = db.GetCollection<Usuario>("users");
            var x = collections.Find(_id => true).Sort("{UserId:-1}").Limit(1);
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
    }
}