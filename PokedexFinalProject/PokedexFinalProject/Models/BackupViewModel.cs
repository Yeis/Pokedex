using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokedexFinalProject.Models
{
    public class BackupViewModel
    {
        [DisplayName("Select Option")]
        public int Selectedid { get; set; }
        public IEnumerable<SelectListItem> Options { get; set; }
        public string backupPath { get; set; }
        public BackupViewModel()
        {
           Options = new[] { new SelectListItem { Value = "0", Text = "" },
                new SelectListItem { Value = "1", Text = "Microsoft SQL Server" },
                new SelectListItem { Value = "2", Text = "MySQL" }};
        }
    }
}