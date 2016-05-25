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

        public GetTypesViewModel(int id)
        {
            PokedexEntities context = new PokedexEntities();
           listPok = context.GetPokemonByType(id).ToList();
            typeRelation = context.GetTypeRelations(id).FirstOrDefault();
        }


    }
}