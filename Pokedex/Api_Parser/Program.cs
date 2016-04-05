using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Api_Parser
{
    public class Pokemon
    {
        public int id { get; set; }
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 700; i++)
            {
                RunAsync(i.ToString()).Wait();
            }
           
            //   client.BaseAddress = new Uri("http://pokeapi.co/api/v2/pokemon/");
            Console.ReadLine();
        }


        static async Task RunAsync(string parameter)
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
                    Pokemon poke = await response.Content.ReadAsAsync < Pokemon > ();
                    Console.WriteLine("{0}\t${1}\t{2}", poke.name, poke.weight, poke.id);
                }
            }
        }
     
    

    } 
}
