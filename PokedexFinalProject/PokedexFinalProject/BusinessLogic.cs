using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PokedexFinalProject.Models;

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
        public List<SP_ConexionesActivas_Result> GetActiveConnections()
        {
            Starttime = DateTime.Now.Millisecond;
            List<SP_ConexionesActivas_Result> result = context.SP_ConexionesActivas().ToList();
            Endtime = DateTime.Now.Millisecond;
            AddLog(new LogData() { nombre = "SP_ConexionesActivas", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;

        }
        internal IEnumerable<SP_ListaIndices_Result> GetIndexes()
        {
            Starttime = DateTime.Now.Millisecond;
            List<SP_ListaIndices_Result> result = context.SP_ListaIndices().ToList();
            Endtime = DateTime.Now.Millisecond; new NotImplementedException();
            AddLog(new LogData() { nombre = "SP_ListaIndices", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;

        }

        internal IEnumerable<SP_Lista_Tablas_Result> TableWithCounts()
        {
            Starttime = DateTime.Now.Millisecond;
            List<SP_Lista_Tablas_Result> result = context.SP_Lista_Tablas().ToList();
            Endtime = DateTime.Now.Millisecond; new NotImplementedException();
            AddLog(new LogData() { nombre = "SP_Lista_Tablas", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;
        }
        internal IEnumerable<SP_Lista_Mil_Registros_Result> Table1000()
        {
            Starttime = DateTime.Now.Millisecond;
            List<SP_Lista_Mil_Registros_Result> result = context.SP_Lista_Mil_Registros().ToList();
            Endtime = DateTime.Now.Millisecond; new NotImplementedException();
            AddLog(new LogData() { nombre = "SP_Lista_Mil_Registros", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;
        }

        internal IEnumerable<string> UnusedSP()
        {
            Starttime = DateTime.Now.Millisecond;
            List<string> result = context.UnusedSP().ToList();
            Endtime = DateTime.Now.Millisecond; new NotImplementedException();
            AddLog(new LogData() { nombre = "UnusedSP", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;
        }

        internal IEnumerable<SP_ListaColumnas_Result> GetColumns(string name)
        {
            Starttime = DateTime.Now.Millisecond;
            List<SP_ListaColumnas_Result> result = context.SP_ListaColumnas(name).ToList();
            Endtime = DateTime.Now.Millisecond; new NotImplementedException();
            AddLog(new LogData() { nombre = "SP_ListaColumnas", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;

        }

        internal IEnumerable<SPCount_Result> ExecCount()
        {
            Starttime = DateTime.Now.Millisecond;
            List<SPCount_Result> result = context.SPCount().ToList();
            Endtime = DateTime.Now.Millisecond; new NotImplementedException();
            AddLog(new LogData() { nombre = "SPCount", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;
        }

        internal IEnumerable<SPExecAverage_Result> ExecAvg()
        {
            Starttime = DateTime.Now.Millisecond;
            List<SPExecAverage_Result> result = context.SPExecAverage().ToList();
            Endtime = DateTime.Now.Millisecond; new NotImplementedException();
            AddLog(new LogData() { nombre = "SPExecAverage", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;
        }

        internal IEnumerable<GetUserSubtotals_Result> GetUsersSubtotals()
        {
            Starttime = DateTime.Now.Millisecond;
            List<GetUserSubtotals_Result> result = context.GetUserSubtotals().ToList();
            Endtime = DateTime.Now.Millisecond; new NotImplementedException();
            AddLog(new LogData() { nombre = "GetUserSubtotals", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;
        }
        internal IEnumerable<GetUserContains_Result> GetUserContains(string patron)
        {
            Starttime = DateTime.Now.Millisecond;
            List<GetUserContains_Result> result = context.GetUserContains(patron).ToList();
            Endtime = DateTime.Now.Millisecond; new NotImplementedException();
            AddLog(new LogData() { nombre = "GetUserContains", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;
        }

        internal IEnumerable<SPByUser_Result> SPByUser(int id)
        {
            Starttime = DateTime.Now.Millisecond;
            List<SPByUser_Result> result = context.SPByUser(id).ToList();
            Endtime = DateTime.Now.Millisecond; new NotImplementedException();
            AddLog(new LogData() { nombre = "SPByUser", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;
        }

        internal IEnumerable<InactiveUsers_Month_Result> InactiveUsers()
        {
            Starttime = DateTime.Now.Millisecond;
            List<InactiveUsers_Month_Result> result = context.InactiveUsers_Month().ToList();
            Endtime = DateTime.Now.Millisecond; new NotImplementedException();
            AddLog(new LogData() { nombre = "InactiveUsers_Month", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;
        }
    
    
        internal IEnumerable<GetLoginDays_Result> HotDays()
        {
            Starttime = DateTime.Now.Millisecond;
            List<GetLoginDays_Result> result = context.GetLoginDays().ToList();
            Endtime = DateTime.Now.Millisecond; new NotImplementedException();
            AddLog(new LogData() { nombre = "GetLoginDays", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;
        }
        internal IEnumerable<GetLoginHours_Result> HotHours()
        {
            Starttime = DateTime.Now.Millisecond;
            List<GetLoginHours_Result> result = context.GetLoginHours().ToList();
            Endtime = DateTime.Now.Millisecond; new NotImplementedException();
            AddLog(new LogData() { nombre = "GetLoginHours", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;
        }


        internal IEnumerable<SP_ListaViews_Result> GetViews()
        {
            Starttime = DateTime.Now.Millisecond;
            List<SP_ListaViews_Result> result = context.SP_ListaViews().ToList();
            Endtime = DateTime.Now.Millisecond; new NotImplementedException();
            AddLog(new LogData() { nombre = "SP_ListaViews", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;

        }


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
        public List<GetSPByHour_Result> GetSPbyHour(int a , int b )
        {
            Starttime = DateTime.Now.Millisecond;
            List<GetSPByHour_Result> result = context.GetSPByHour(a , b).ToList();
            Endtime = DateTime.Now.Millisecond;

            AddLog(new LogData() { nombre = "GetSPByHour", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;
        }

        public List<SP_ListaViews_Result> GetViews(int a, int b)
        {
            Starttime = DateTime.Now.Millisecond;
            List<SP_ListaViews_Result> result = context.SP_ListaViews().ToList();
            Endtime = DateTime.Now.Millisecond;

            AddLog(new LogData() { nombre = "SP_ListaViews", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;
        }
        public List<SP_InfoSp_Result> MaxMinSP()
        {
            Starttime = DateTime.Now.Millisecond;
            List<SP_InfoSp_Result> result = context.SP_InfoSp().ToList();
            Endtime = DateTime.Now.Millisecond;

            AddLog(new LogData() { nombre = "SP_InfoSp", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;
        }


        public List<SPInRange_Result> SPInRange(int low , int high)
        {
            Starttime = DateTime.Now.Millisecond;
            List<SPInRange_Result> result = context.SPInRange(low , high).ToList();
            Endtime = DateTime.Now.Millisecond;

            AddLog(new LogData() { nombre = "SPInRange", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            return result;
        }




        //public GetPokemonDetail_Result GetPokemonDetails(int id)
        //{
        //    Starttime = DateTime.Now.Millisecond;
        //    GetPokemonDetail_Result result = context.getpo(id).FirstOrDefault();
        //    Endtime = DateTime.Now.Millisecond;

        //    AddLog(new LogData() { nombre = "GetPokemonDetail", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
        //    return result;

        //}

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
                new SelectListItem {Value = "3" , Text = "DB Indexes" },
                new SelectListItem { Value = "4" , Text= "SP Range By Hours"},
                new SelectListItem {Value = "5" , Text = "Active DB Connections" },
                new SelectListItem {Value = "6" , Text = "DB Tables with Count" },
                new SelectListItem {Value = "7" , Text = "Table Columns" },
                new SelectListItem {Value = "8" , Text = "Table Over 100 Rows" },
               new SelectListItem {Value = "9" , Text = "DB Views" },
                new SelectListItem {Value = "10" , Text = "Most Used SP" },
                 new SelectListItem {Value = "11" , Text = "SP in Range" },
                new SelectListItem {Value = "12" , Text = " Unused SP" },
                  new SelectListItem {Value = "13" , Text = "Average SP Execution" },
                new SelectListItem {Value = "14" , Text = "SP Executions" },
                 new SelectListItem {Value = "15" , Text = "Inactive Users Month " },
                new SelectListItem {Value = "16" , Text = " Most Visited Days" },
                new SelectListItem {Value = "17" , Text = " Most Visited Hours" },
                new SelectListItem {Value = "18" , Text = "SP by User" },
                new SelectListItem {Value = "19" , Text = " User Subtotal" },
                new SelectListItem {Value = "20" , Text = " Search users" }





            };

            return options;}
        static void CreateMongo(string FirstName, string LastName, string pass, int Admin, string Username, string mail, DateTime DOB , int userid)
        {
            var mongo = new MongoClient("mongodb://localhost:27017");
            var db = mongo.GetDatabase("users");
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
            var collections = db.GetCollection<Usuario>("users");
            collections.InsertOne(user);
        }
    }
}