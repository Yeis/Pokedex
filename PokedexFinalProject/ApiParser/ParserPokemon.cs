using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiParser
{
    public class ParserPokemon
    {
        public int id { get; set; }
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public List<ParserHabilidad> abilities { get; set; }
        public spriteParser sprites { get; set; }
        public List<ParserType> types { get; set; }
        public List<ParserStats> stats { get; set; }
        public List<relmove> moves { get; set; }

    }
    public class spriteParser
    {
        public string front_default { get; set; }
    }
    public class ParserHabilidad
    {
        public commonParser ability { get; set; }
        //public int HabilidadID { get; set; }
        //public string Name { get; set; }
        //public string Descripcion { get; set; }
    }
    public class ParserStats
    {
        public int base_stat { get; set; }
        public commonParser stat { get; set; }

        //public int HabilidadID { get; set; }
        //public string Name { get; set; }
        //public string Descripcion { get; set; }
    }
    public class ParserType
    {
        public commonParser type { get; set; }

        //public int HabilidadID { get; set; }
        //public string Name { get; set; }
        //public string Descripcion { get; set; }
    }
    public class commonParser
    {
        public string name { get; set; }
        public string url { get; set; }
    }




    //PARSEO DE EVOLUCION A PARTIR DE AQUI 
    public class ParserEvolucion
    {
        public chain chain { get; set; }

    }
    public class species
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    public class chain
    {
        public species species { get; set; }
        public List<evolves> evolves_to { get; set; }
    }
    public class evolves
    {
        public species species { get; set; }
        public List<evolves> evolves_to { get; set; }
        public evolutiondetails evolution_details { get; set; }

    }
    public class evolutiondetails
    {
        public int min_level { get; set; }
        public trigger trigger { get; set; }
    }
    public class trigger
    {
        public string name { get; set; }
    }


    // CLASES DE PARSEO DE MOVIMIENTOS
    public class ParserMoves
    {
        public string name { get; set; }
        public int? accuracy { get; set; }
        public int? pp { get; set; }
        public int? power { get; set; }
        public commonParser type { get; set; }
        public commonParser generation { get; set; }

    }
    public class relmove
    {
        public commonParser move { get; set; }
    }
    //PARSEANDO TYPES Y TYPE RELATIONS 
    public class ParserTypes
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<commonParser> no_damage_to { get; set; }
        public List<commonParser> half_damage_to { get; set; }
        public List<commonParser> double_damage_to { get; set; }

    }
    //PARSER HABILIDADES
    public class ParserAbility
    {
        public string name { get; set; }
        public List<effect> effect_entries { get; set; }
    }
    public class effect
    {
        public string short_effect { get; set; }
    }
    //PARSEO DE RELACION POKEMON GENERACION
    public class ParserGenerationRel
    {
        public int id { get; set; }
        public List<commonParser> pokemon_species { get; set; }
    }
}
