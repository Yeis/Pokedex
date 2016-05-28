using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokedexFinalProject.Models
{
    public class PokemonViewModel
    {
        public Evolucion evo { get; set; }
        public Pokemon ant { get; set; }
        public Pokemon sig { get; set; }
        public GetPokemonDetail_Result detail { get; set; }
        public List<GetMoveRelation_Result> moves { get; set; }
        public string nameTipo1 { get; set; }
        public string nameTipo2 { get; set; }
        public string nameHab { get; set; }

        public PokemonViewModel()
        {

        }
        public PokemonViewModel(int id)
        {
            BusinessLogic BL = new BusinessLogic();
            PokedexEntities context = new PokedexEntities();
            int Starttime = DateTime.Now.Millisecond;
            detail = context.GetPokemonDetail(id).First();
            int Endtime = DateTime.Now.Millisecond;
            BL.AddLog(new LogData() { nombre = "GetPokemonDetail", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            evo = (from e in context.Evolucions
                  where e.PokeID == id
                  select e).FirstOrDefault();
            if (evo != null)
            {
                ant = (from a in context.Pokemons
                       where a.PokemonID == evo.AntID
                       select a).FirstOrDefault();
                sig = (from a in context.Pokemons
                       where a.PokemonID == evo.SigId
                       select a).FirstOrDefault();
            }
            Starttime = DateTime.Now.Millisecond;
            moves = context.GetMoveRelation(id).ToList();
            Endtime = DateTime.Now.Millisecond;
            BL.AddLog(new LogData() { nombre = "GetMoveRelation", tipo = "SP", fecha = DateTime.Now, UserId = SharedInstance.AppUser.UserID, exec_time = (Endtime - Starttime) });
            nameTipo1 = (from t in context.Tipoes
                        where t.TipoID == detail.TpID
                        select t.Nombre).FirstOrDefault();
            nameTipo2 = (from t in context.Tipoes
                         where t.TipoID == detail.TpID2
                         select t.Nombre).FirstOrDefault();
            nameHab = (from t in context.Habilidads
                       where t.HabilidadID == detail.HabID
                       select t.Name).FirstOrDefault();
        }
    }
}