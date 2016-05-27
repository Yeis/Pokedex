using MongoDB.Driver;
using MYSQLProj;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PokedexFinalProject.BusinessLayer
{
    public class MyBusinessLogic
    {
        int Starttime;
        long final;
        Stopwatch watch;

        pokedexEntities context;
        public MyBusinessLogic()
        {
             context = new pokedexEntities();
             watch = new Stopwatch();

        }

        public List<MYSQLProj.ActiveUsers_Month_Result> Acitve_Users_Month()
        {
            watch.Start();

            List<MYSQLProj.ActiveUsers_Month_Result> result = context.ActiveUsers_Month().ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "ActiveUsers_Month", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
  
            return result;
        }
        public IEnumerable<string> UnusedSP()
        {
            Starttime = DateTime.Now.Millisecond;
            List<string> result = context.UnusedSP().ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "UnusedSP", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }
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
                    final = watch.ElapsedMilliseconds;
                    watch.Stop();
                    AddLog(new logdata() { nombre = MySQLuser.Username, tipo = "Login", fecha = DateTime.Now, UserId = MySQLuser.UserId, exec_time = (int)final });

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
                final = watch.ElapsedMilliseconds;
                watch.Stop();
                AddLog(new logdata() { nombre = mongousuario.Username, tipo = "Login", fecha = DateTime.Now, UserId = mongousuario.UserId, exec_time = (int)final });

                return mongousuario;
            }



        }

        internal IEnumerable<MYSQLProj.SPInRange_Result> SPInRange(int v1, int v2)
        {
            watch.Start();
            List<MYSQLProj.SPInRange_Result> result = context.SPInRange(v1,v2).ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "SPInRange", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<MYSQLProj.SPByUser_Result> SPByUser(int v)
        {
            watch.Start();
            List<MYSQLProj.SPByUser_Result> result = context.SPByUser(v).ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "SPByUser", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<MYSQLProj.SP_ListaColumnas_Result> MyGetColumns(string nombreTabla)
        {
            watch.Start();
            List<MYSQLProj.SP_ListaColumnas_Result> result = context.SP_ListaColumnas(nombreTabla).ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "SP_ListaColumnas", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<MYSQLProj.GetUserContains_Result> GetUserContains(string patron)
        {
            int prueba;
            List<MYSQLProj.GetUserContains_Result> result = new List<MYSQLProj.GetUserContains_Result>();

            if (int.TryParse(patron, out prueba))
            {
                watch.Start();
                var query = from st in context.usuarios where st.UserId == prueba select st;
                var user = query.FirstOrDefault<usuario>();
                final = watch.ElapsedMilliseconds; watch.Stop();
                result = new List<MYSQLProj.GetUserContains_Result>();
                result.Add(new MYSQLProj.GetUserContains_Result() { UserID = user.UserId, Admin = user.Admin , Apellido = user.Apellido, DoB = user.DoB, email = user.email, Nombre = user.Nombre, Password = user.Password, Username = user.Username });

            }
            else
            {
                watch.Start();
                result = context.GetUserContains(patron).ToList();
                final = watch.ElapsedMilliseconds; watch.Stop();
            }
            AddLog(new logdata() { nombre = "GetUserContains", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
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
            AddLog(new logdata() { nombre = SharedInstance.AppUser.Username, tipo = "Logout", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = 0 });
            SharedInstance.AppUser = null;
        }
        public void AddLog(logdata log)
        {
           // log.id = context.logdatas.Count() + 1;
          //  context.logdatas.Add(log);
        //context.SaveChanges();
        }

        internal IEnumerable<MYSQLProj.ActiveUsers_Week_Result> Acitve_Users_Week()
        {
            watch.Start();
            List<MYSQLProj.ActiveUsers_Week_Result> result = context.ActiveUsers_Week().ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "ActiveUsers_Week", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<MYSQLProj.SP_ListaIndices_Result> GetIndexes()
        {
            watch.Start();
            List<MYSQLProj.SP_ListaIndices_Result> result = context.SP_ListaIndices().ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "SP_ListaIndices", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<MYSQLProj.SP_ConexionesActivas_Result> GetActiveConnections()
        {
            watch.Start();
            List<MYSQLProj.SP_ConexionesActivas_Result> result = context.SP_ConexionesActivas().ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "SP_ConexionesActivas", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<MYSQLProj.SP_Lista_Tablas_Result> TableWithCounts()
        {
            watch.Start();
            List<MYSQLProj.SP_Lista_Tablas_Result> result = context.SP_Lista_Tablas().ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "SP_Lista_Tablas", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<SP_InfoSP_Result> MaxMinSP()
        {
            watch.Start();
            List<MYSQLProj.SP_InfoSP_Result> result = context.SP_InfoSP().ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "SP_InfoSP", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<MYSQLProj.SP_ListaViews_Result> GetViews()
        {
            watch.Start();
            List<MYSQLProj.SP_ListaViews_Result> result = context.SP_ListaViews().ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "SP_ListaViews", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<MYSQLProj.SP_Lista_Mil_Registros_Result> Table1000()
        {
            watch.Start();
            List<MYSQLProj.SP_Lista_Mil_Registros_Result> result = context.SP_Lista_Mil_Registros().ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "SP_Lista_Mil_Registros", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<MYSQLProj.GetUserSubtotals_Result> GetUsersSubtotals()
        {
            watch.Start();
            List<MYSQLProj.GetUserSubtotals_Result> result = context.GetUserSubtotals().ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "GetUserSubtotals", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<MYSQLProj.GetLoginHours_Result> HotHours()
        {
            watch.Start();
            List<MYSQLProj.GetLoginHours_Result> result = context.GetLoginHours().ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "GetLoginHours", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<MYSQLProj.GetLoginDays_Result> HotDays()
        {
            watch.Start();
            List<MYSQLProj.GetLoginDays_Result> result = context.GetLoginDays().ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "GetLoginDays", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<MYSQLProj.SPExecAverage_Result> ExecAvg()
        {
            watch.Start();
            List<MYSQLProj.SPExecAverage_Result> result = context.SPExecAverage().ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "SPExecAverage", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<MYSQLProj.InactiveUsers_Month_Result> InactiveUsers()
        {
            watch.Start();
            List<MYSQLProj.InactiveUsers_Month_Result> result = context.InactiveUsers_Month().ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "InactiveUsers_Month", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }

        internal IEnumerable<MYSQLProj.SPCount_Result> ExecCount()
        {
            watch.Start();
            List<MYSQLProj.SPCount_Result> result = context.SPCount().ToList();
            final = watch.ElapsedMilliseconds;
            watch.Stop();
            AddLog(new logdata() { nombre = "SPCount", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (int)final });
            return result;
        }
    }
}