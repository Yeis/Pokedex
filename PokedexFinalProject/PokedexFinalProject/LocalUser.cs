using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokedexFinalProject
{
    public class LocalUser
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Admin { get; set; }
        // FALSE IGUAL MS-SQLSERVER   TRUE = MYSQL 
        public bool Connection { get; set; }
    }
}