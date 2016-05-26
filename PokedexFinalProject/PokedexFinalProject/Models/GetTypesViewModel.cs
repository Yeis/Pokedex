using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokedexFinalProject.Models
{
    public class GetTypesViewModel
    {
        public GetTypeRelations_Result typeRelation { get; set; }
        public List<GetPokemonByType_Result> listPok { get; set; }
        BusinessLogic BL = new BusinessLogic();
        int Endtime, Starttime;

        public GetTypesViewModel(int id)
        {
            PokedexEntities context = new PokedexEntities();
            Starttime = DateTime.Now.Millisecond;
            listPok = context.GetPokemonByType(id).ToList();
            Endtime = DateTime.Now.Millisecond;
            BL.AddLog(new LogData() { nombre = "GetPokemonByType", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (Endtime - Starttime) });
            Starttime = DateTime.Now.Millisecond;
            typeRelation = context.GetTypeRelations(id).FirstOrDefault();
            Endtime = DateTime.Now.Millisecond;
            BL.AddLog(new LogData() { nombre = "GetTypeRelations", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserId, exec_time = (Endtime - Starttime) });
        }


    }
}