using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokedexFinalProject.Models
{
    public class ColumnsViewModel
    {
        public string NombreTabla { get; set; }
        public IEnumerable<SP_ListaColumnas_Result> Columnas { get; set; }



    }
}