using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace PokedexFinalProject
{
    public class LocalUser
    {

        
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? Admin { get; set; }
        ObjectId Id { get; set; }
        // FALSE IGUAL MS-SQLSERVER   TRUE = MYSQL 
        public bool Connection { get; set; }

        public LocalUser()
        {
                //empty constructor
        }
        public LocalUser(int id, string firstname , string lastname, DateTime? dob , string username , string password , string email , int? admin , bool connection)
        {
            this.UserID = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.DOB = dob;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Admin = admin;
            this.Connection = connection;
        }
    }
}