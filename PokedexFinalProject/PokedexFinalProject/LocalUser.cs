using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace PokedexFinalProject
{
    public class LocalUser
    {

        
        public int UserId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? DoB { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        public int? Admin { get; set; }
        public ObjectId Id { get; set; }
        public bool logeoCorrecto = false;
        // FALSE IGUAL MS-SQLSERVER   TRUE = MYSQL 
        public bool Connection { get; set; }
        

        public LocalUser()
        {
            //empty constructor
            logeoCorrecto = false;
        }
        public LocalUser(int id, string firstname , string lastname, DateTime? dob , string username , string password , string email , int? admin , bool connection)
        {
            this.UserId = id;
            this.Nombre = firstname;
            this.Apellido = lastname;
            this.DoB = dob;
            this.Username = username;
            this.Password = password;
            this.email = email;
            this.Admin = admin;
            this.Connection = connection;
            logeoCorrecto = false;
        }
    }
}