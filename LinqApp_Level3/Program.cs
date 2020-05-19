using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinqApp_Level3
{
    class Film
    {
        public string Name { get; set; }
        public string Director { get; set; }
    }
    class Director
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }


    class Program
    {
            static void Main(string[] args)
        {

            List<Film> films = new List<Film>()
                        {
                            new Film { Name = "The Silence of the Lambs", Director ="Jonathan Demme" },
                            new Film { Name = "The World's Fastest Indian", Director ="Roger Donaldson" },

                            new Film { Name = "The Recruit", Director ="Roger Donaldson" }
                        };
            List<Director> directors = new List<Director>()
                        {
                            new Director {Name="Jonathan Demme", Country="USA"},
                            new Director {Name="Roger Donaldson", Country="New Zealand"},
                        };

           
            Console.WriteLine("\nTask 1. Implement extension method on int that calculates Factorial\n");

            var arr = new int[] { 1, 2, 3, 4, 5 };
            var d = arr.Aggregate((i, j) => i+j);
            Console.WriteLine(d);

            Console.WriteLine("\nTask 2. Output all films in such format: FilmName DirectorName (DirectorCountry)\n");
            Console.WriteLine(string.Join("\n",films.Join(directors, film => film.Director
                                                  , dir=> dir.Name
                                                  ,(film, dir) 
                                                  => new { FilmName = film.Name, DirectorFilm = dir.Name,dir.Country })
                                                  .Select((f)=>$" {f.FilmName} : {f.DirectorFilm} ({f.Country})")));

            Console.WriteLine("\nTask 3. Output all films of each director separated by commas");
            Console.WriteLine(string.Join("\n",films.GroupBy(film => film.Director,f=> f.Name)
                                                .Select(gr => $"Director {gr.Key} : \n\t{string.Join("",gr.SelectMany(name=> name))};")));



            Console.ReadLine();
        }
    }
}
