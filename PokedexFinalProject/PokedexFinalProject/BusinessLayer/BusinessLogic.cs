using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PokedexFinalProject.Models;
using System.Diagnostics;
using MYSQLProj;

namespace PokedexFinalProject
{
    public class BusinessLogic
    {
      
        long final;
        PokedexEntities context;
        Stopwatch watch;
        public BusinessLogic()
        {
            context = new PokedexEntities();
            watch = new Stopwatch();

        }

        public LocalUser Login(string username, string password)
        {
            //watch.Start();
            //Buscamos primero en Mongo
            LocalUser mongousuario = FindMongo(username, password);
            if (mongousuario == null)
            {
                //BUscamos en SQL 
                Usuario SQLuser = FindSQL(username, password);
                if (SQLuser != null)
                {
                    CreateMongo(SQLuser.Nombre, SQLuser.Apellido, SQLuser.Password, SQLuser.Admin.Value, SQLuser.Username, SQLuser.email, SQLuser.DoB.Value, SQLuser.UserId);
                    AddLog(new LogData() { nombre = SQLuser.Username, tipo = "Login", fecha = DateTime.Now, UserId = SQLuser.UserId, exec_time = (int)final });

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
                AddLog(new LogData() { nombre = mongousuario.Username, tipo = "Login", fecha = DateTime.Now, UserId = mongousuario.UserId, exec_time = (int)final });

                return mongousuario;

            }
        }
        internal IEnumerable<SP_ListaIndices_Result> GetIndexes()
        {
            watch.Start();
            List<SP_ListaIndices_Result> result = context.SP_ListaIndices().ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new LogData() { nombre = "SP_ListaIndices", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;

        }

        internal IEnumerable<MYSQLProj.SP_ListaColumnas_Result> MyGetColumns(string nombreTabla)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<SP_Lista_Tablas_Result> TableWithCounts()
        {
            watch.Start();
            List<SP_Lista_Tablas_Result> result = context.SP_Lista_Tablas().ToList();
           final = watch.ElapsedMilliseconds;   watch.Stop(); 
            AddLog(new LogData() { nombre = "SP_Lista_Tablas", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }
        internal IEnumerable<SP_Lista_Mil_Registros_Result> Table1000()
        {
            watch.Start();
            List<SP_Lista_Mil_Registros_Result> result = context.SP_Lista_Mil_Registros().ToList();
           final = watch.ElapsedMilliseconds;   watch.Stop(); 
            AddLog(new LogData() { nombre = "SP_Lista_Mil_Registros", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<string> UnusedSP()
        {
            watch.Start();
            List<string> result = context.UnusedSP().ToList();
           watch.Stop();
            AddLog(new LogData() { nombre = "UnusedSP", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<SP_ListaColumnas_Result> GetColumns(string name)
        {
            watch.Start();
            List<SP_ListaColumnas_Result> result = context.SP_ListaColumnas(name).ToList();
           final = watch.ElapsedMilliseconds;   watch.Stop(); 
            AddLog(new LogData() { nombre = "SP_ListaColumnas", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;

        }

        internal IEnumerable<SPCount_Result> ExecCount()
        {
            watch.Start();
            List<SPCount_Result> result = context.SPCount().ToList();
           final = watch.ElapsedMilliseconds;   watch.Stop(); 
            AddLog(new LogData() { nombre = "SPCount", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<SPExecAverage_Result> ExecAvg()
        {
            watch.Start();
            List<SPExecAverage_Result> result = context.SPExecAverage().ToList();
           final = watch.ElapsedMilliseconds;   watch.Stop(); 
            AddLog(new LogData() { nombre = "SPExecAverage", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<GetUserSubtotals_Result> GetUsersSubtotals()
        {
            watch.Start();
            List<GetUserSubtotals_Result> result = context.GetUserSubtotals().ToList();
           final = watch.ElapsedMilliseconds;   watch.Stop(); 
            AddLog(new LogData() { nombre = "GetUserSubtotals", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }
        internal IEnumerable<GetUserContains_Result> GetUserContains(string patron)
        {
            int prueba;
            List<GetUserContains_Result> result = new List<GetUserContains_Result>();

            if (int.TryParse(patron, out prueba))
            {
                watch.Start();
                var query = from st in context.Usuarios where st.UserId == prueba select st;
                var user = query.FirstOrDefault<Usuario>();
               final = watch.ElapsedMilliseconds;   watch.Stop(); 
                result = new List<GetUserContains_Result>();
                result.Add(new GetUserContains_Result() { UserId = user.UserId, Admin = user.Admin, Apellido = user.Apellido, DoB = user.DoB, email = user.email, Nombre = user.Nombre, Password = user.Password, Username = user.Username });

            }
            else
            {
                watch.Start();
                result = context.GetUserContains(patron).ToList();
               final = watch.ElapsedMilliseconds;   watch.Stop(); 
            }
            AddLog(new LogData() { nombre = "GetUserContains", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<SPByUser_Result> SPByUser(int id)
        {
            watch.Start();
            List<SPByUser_Result> result = context.SPByUser(id).ToList();
           final = watch.ElapsedMilliseconds;   watch.Stop(); 
            AddLog(new LogData() { nombre = "SPByUser", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<InactiveUsers_Month_Result> InactiveUsers()
        {
            watch.Start();
            List<InactiveUsers_Month_Result> result = context.InactiveUsers_Month().ToList();
           final = watch.ElapsedMilliseconds;   watch.Stop(); 
            AddLog(new LogData() { nombre = "InactiveUsers_Month", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }


        internal IEnumerable<GetLoginDays_Result> HotDays()
        {
            watch.Start();
            List<GetLoginDays_Result> result = context.GetLoginDays().ToList();
           final = watch.ElapsedMilliseconds;   watch.Stop(); 
            AddLog(new LogData() { nombre = "GetLoginDays", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }
        internal IEnumerable<GetLoginHours_Result> HotHours()
        {
            watch.Start();
            List<GetLoginHours_Result> result = context.GetLoginHours().ToList();
           final = watch.ElapsedMilliseconds;   watch.Stop(); 
            AddLog(new LogData() { nombre = "GetLoginHours", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }


        internal IEnumerable<SP_ListaViews_Result> GetViews()
        {
            watch.Start();
            List<SP_ListaViews_Result> result = context.SP_ListaViews().ToList();
           final = watch.ElapsedMilliseconds;   watch.Stop(); 
            AddLog(new LogData() { nombre = "SP_ListaViews", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;

        }

        public List<SP_ConexionesActivas_Result> GetActiveConnections() { 

        //Si se encuentra en mongo User.Now.Millisecond;
        List<SP_ConexionesActivas_Result> result = context.SP_ConexionesActivas().ToList();
       final = watch.ElapsedMilliseconds;   watch.Stop(); 
                AddLog(new LogData() { nombre = "SP_ConexionesActivas", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
                return result;
            }

       
        public List<ActiveUsers_Month_Result> Acitve_Users_Month()
        {
                watch.Start();
                List<ActiveUsers_Month_Result> result = context.ActiveUsers_Month().ToList();
               final = watch.ElapsedMilliseconds;   watch.Stop(); 
               
                AddLog(new LogData() {   nombre = "ActiveUsers_Month", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
                return result;
        }
        public List<ActiveUsers_Week_Result> Acitve_Users_Week()
        {
                watch.Start();
                List<ActiveUsers_Week_Result> result = context.ActiveUsers_Week().ToList();
               final = watch.ElapsedMilliseconds;   watch.Stop(); 

                AddLog(new LogData() { nombre = "ActiveUsers_Week", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
                return result;
        }
        public List<GetSPByHour_Result> GetSPbyHour(int a , int b )
        {
            watch.Start();
            List<GetSPByHour_Result> result = context.GetSPByHour(a , b).ToList();
           final = watch.ElapsedMilliseconds;   watch.Stop(); 

            AddLog(new LogData() { nombre = "GetSPByHour", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        public List<SP_ListaViews_Result> GetViews(int a, int b)
        {
            watch.Start();
            List<SP_ListaViews_Result> result = context.SP_ListaViews().ToList();
           final = watch.ElapsedMilliseconds;   watch.Stop(); 

            AddLog(new LogData() { nombre = "SP_ListaViews", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }
        public List<SP_InfoSp_Result> MaxMinSP()
        {
            watch.Start();
            List<SP_InfoSp_Result> result = context.SP_InfoSp().ToList();
           final = watch.ElapsedMilliseconds;   watch.Stop(); 

            AddLog(new LogData() { nombre = "SP_InfoSp", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }


        public List<SPInRange_Result> SPInRange(int low , int high)
        {
            watch.Start();
            List<SPInRange_Result> result = context.SPInRange(low , high).ToList();
           final = watch.ElapsedMilliseconds;   watch.Stop(); 

            AddLog(new LogData() { nombre = "SPInRange", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }




        //public GetPokemonDetail_Result GetPokemonDetails(int id)
        //{
        //    watch.Start();
        //    GetPokemonDetail_Result result = context.getpo(id).FirstOrDefault();
        //   final = watch.ElapsedMilliseconds;   watch.Stop(); 

        //    AddLog(new LogData() { nombre = "GetPokemonDetail", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
        //    return result;

        //}

        public void LogOut()
        {
            AddLog(new LogData() { nombre = SharedInstance.AppUser.Username, tipo = "Logout", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
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
       
       
        public void CreateMongo(string FirstName, string LastName, string pass, int Admin, string Username, string mail, DateTime DOB , int userid)
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