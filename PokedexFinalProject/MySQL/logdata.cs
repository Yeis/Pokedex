//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MySQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class logdata
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> exec_time { get; set; }
        public Nullable<int> UserId { get; set; }
    }
}