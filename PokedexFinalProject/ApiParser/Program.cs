using PokedexFinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Text.RegularExpressions;

namespace ApiParser
{
    class Program
    {

        static void Main(string[] args)
        {
            for (int i = 192; i < 1500; i++)
            {
                RunAsyncAbility(i.ToString()).Wait();
            }
            Console.ReadLine();
            
        }


        static async Task RunAsyncPokemon(string parameter, int param)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://pokeapi.co/api/v2/pokemon/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync(parameter);
                if (response.IsSuccessStatusCode)
                {
                    ParserPokemon poke = await response.Content.ReadAsAsync<ParserPokemon>();
                    Pokemon temp;
                    using (PokedexEntities context = new PokedexEntities())
                    {
                        
                         temp = context.Pokemons.Where(p => p.PokemonID == param).FirstOrDefault();
                    }
                    if (temp != null)
                    {
                        temp.pathImg = poke.sprites.front_default;
                    }
                    using (PokedexEntities pkcontext = new PokedexEntities())
                    {
                        pkcontext.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                        pkcontext.SaveChanges();
                    }



                    Console.WriteLine("foto agregada {0} ha sido agregado", poke.name );
                    
                }
                
            }
            
        }


        static async Task RunAsyncEvolutions(string parameter)
        {
            PokedexEntities context = new PokedexEntities();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://pokeapi.co/api/v2/evolution-chain/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync(parameter);
                if (response.IsSuccessStatusCode)
                {
                    ParserEvolucion evo = await response.Content.ReadAsAsync<ParserEvolucion>();
                    Regex regex = new Regex(@"/\d+/");
                    Match match = regex.Match(evo.chain.species.url);
                    int pkid = int.Parse(match.Value.Replace('/', ' '));

                    //Evoluciones de la primera cadena 
                    context.CreateEvolution(pkid, null, pkid + 1, evo.chain.evolves_to[0].evolution_details.trigger.name, evo.chain.evolves_to[0].evolution_details.min_level.ToString());
                    Console.WriteLine("{0} a {1} ha sido agregada", evo.chain.species.name , evo.chain.evolves_to[0].species.name);
                    //Evolucion de la segunda 
                    if (evo.chain.evolves_to[0].evolves_to[0] != null)
                    {
                        //existe una tercera evolucion
                        context.CreateEvolution(pkid + 1, pkid, pkid + 2, evo.chain.evolves_to[0].evolves_to[0].evolution_details.trigger.name, evo.chain.evolves_to[0].evolves_to[0].evolution_details.min_level.ToString());
                        Console.WriteLine("{0} a {1} ha sido agregada", evo.chain.evolves_to[0].species.name, evo.chain.evolves_to[0].evolves_to[0].species.name);
                    }
                }

            }
        }
        static async Task RunAsyncMoves(string parameter)
        {
            PokedexEntities context = new PokedexEntities();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://pokeapi.co/api/v2/move/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync(parameter);
                if (response.IsSuccessStatusCode)
                {
                    ParserMoves move = await response.Content.ReadAsAsync<ParserMoves>();
                    Regex regex = new Regex(@"/\d+/");
                    Match match = regex.Match(move.generation.url);
                    int generacion = int.Parse(match.Value.Replace('/', ' '));
                    match = regex.Match(move.type.url);
                    int type = int.Parse(match.Value.Replace('/', ' '));

                    context.CreateMove(type, move.name, move.accuracy, move.power, move.pp, generacion);
                    Console.WriteLine("Se ha agregado el move: {0} \n", move.name);
                }
            }
        }
        static async Task RunAsyncAbility(string parameter)
        {
            PokedexEntities context = new PokedexEntities();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://pokeapi.co/api/v2/ability/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync(parameter);
                if (response.IsSuccessStatusCode)
                {
                    ParserAbility ability = await response.Content.ReadAsAsync<ParserAbility>();

                    context.CreateAbility(ability.name, ability.effect_entries[0].short_effect);
                    Console.WriteLine("ability: {0}  added \n", ability.name);
                }
            }
        }
        static async Task RunAsyncGameRel(string parameter)
        {
            PokedexEntities context = new PokedexEntities();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://pokeapi.co/api/v2/generation/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync(parameter);
                if (response.IsSuccessStatusCode)
                {
                    ParserGenerationRel gen = await response.Content.ReadAsAsync<ParserGenerationRel>();
                    Regex regex = new Regex(@"/\d+/");

                    for (int i = 0; i < gen.pokemon_species.Count; i++)
                    {
                        Match match = regex.Match(gen.pokemon_species[i].url);
                        context.CreateGameRelation(int.Parse(match.Value.Replace('/', ' ')), gen.id);
                        Console.WriteLine("Pokemon: {0} , Generation: {1}",gen.pokemon_species[i].name , gen.id );
                    }

                    //    Console.WriteLine("ability: {0}  added \n", ability.name);
                }
            }
        }

        static async Task RunAsyncMovesRelations(string parameter)
        {
            PokedexEntities context = new PokedexEntities();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://pokeapi.co/api/v2/pokemon/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync(parameter);
                if (response.IsSuccessStatusCode)
                {
                    ParserPokemon poke = await response.Content.ReadAsAsync<ParserPokemon>();
                    Regex regex = new Regex(@"/\d+/");
                    for (int i = 0; i < poke.moves.Count; i++)
                    {
                        Match match = regex.Match(poke.moves[i].move.url);
                        context.CreateMoveRelation(poke.id, int.Parse(match.Value.Replace('/', ' ')));
                        Console.WriteLine("Creando relacion entre {0}  y {1} \n", poke.name, poke.moves[i].move.name);
                    }
                }
            }
        }


    }
}
