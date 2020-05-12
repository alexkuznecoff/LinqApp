using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp_Level2
{
    class Actor
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

    abstract class ArtObject
    {

        public string Author { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
    class Film : ArtObject
    {

        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }
    class Book : ArtObject
    {

        public int Pages { get; set; }
    }
    class Program
    {
    
        static List<object>Data()
        {
            var data = new List<object>() {
                        "Hello",
                        new Book() { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
                        new List<int>() {4, 6, 8, 2},
                        new string[] {"Hello inside array"},
                        new Film() { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                            new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                            new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                            new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                        }},
                        new Film() { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                            new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                            new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                        }},
                        new Book() { Author = "Stephen King", Name="Finders Keepers", Pages = 200},
                        "Leonardo DiCaprio"
                    };
            return data;
        }
        static void Main(string[] args)
        {
           

            Console.ReadLine();
        }

        static void Task1()
        {
            var data = Data();
            Console.WriteLine("\nTask 1 :  Output all elements excepting ArtObjects");
            Console.WriteLine(string.Join(",", data.Except(data.OfType<ArtObject>())));
        }

        static void Task2()
        {
            var data = Data();
            Console.WriteLine("\nTask 2 : Output all actors names\n");
            Console.WriteLine(string.Join("\n", data.OfType<Film>()
                             .SelectMany(film => film.Actors,(film, actor)=> actor.Name)
                             .Distinct()));
        }
               
        static void Task3()
        {
            var data = Data();
            Console.WriteLine("\nTask 3 : Output number of actors born in august\n");
            Console.WriteLine(data.OfType<Film>()
                             .SelectMany(film => film.Actors
                             .Where(a => a.Birthdate.Month == 8))
                             .GroupBy(a => a.Name, birthday => birthday.Birthdate)
                             .Count());
                           
        }

        static void Task4()
        {
            Console.WriteLine("\nTask 4 : Output two oldest actors names\n");
            Console.WriteLine(string.Join("\n", Data().OfType<Film>()
                           .SelectMany(film => film.Actors).OrderBy(actor =>actor.Birthdate.Year)
                           .Select(actor => actor.Name).Take(2)));
        }

        static void Task5()
        {
           Console.WriteLine("\nTask 5 : Output number of books per authors\n");
            Console.WriteLine(string.Join("\n",Data().OfType<Book>()
                            .GroupBy(book => book.Author)
                            .Select(gr => $"{gr.Key} : {gr.Count()}")));
        }

        static void Task6()
        {
            Console.WriteLine("\nTask 6 : Output number of books per authors and films per director\n");
            Console.WriteLine(string.Join("\n",Data().OfType<ArtObject>()
                             .GroupBy(o => o.Author)
                             .Select(gr => $"{gr.Key} : {gr.Count()}")));
        }

        static void Task7()
        {
            Console.WriteLine("\nTask 7 : Output how many different letters used in all actors names\n");
            Console.WriteLine(Data().OfType<Film>()
                            .SelectMany(film => film.Actors,(film,actor) =>actor.Name)
                            .Distinct()
                            .SelectMany(name =>name).Where(ch => ch != ' ')
                            .Select(litera => litera)
                            .Count());
        }

        static void Task8()
        {
            Console.WriteLine("\nTask 8 : Output names of all books ordered by names of their authors and number of pages\n");
            Console.WriteLine(string.Join("\n", Data().OfType<Book>()
                              .OrderBy(book => book.Author).ThenBy(book => book.Pages)
                              .Select(b => $"{b.Author} : {b.Pages}")));
                            
        } 

        static void Task9()
        {
            var data = Data();

            Console.WriteLine("T\nask 9 : Output actor name and all films with this actor\n");
            Console.WriteLine(string.Join("\n", data.OfType<Film>()
                             .SelectMany(film => film.Actors)
                             .GroupBy(actor => actor.Name, actor => data.OfType<Film>()
                             .Where(film => film.Actors.Contains(actor))
                             .Select(film => film.Name))
                             .Select(gr => $" Actor : {gr.Key} - {string.Join("\n\t", gr.SelectMany(film => film))}")));
         
        }

        static void Task10()
        {
            Console.WriteLine("\nTask 10. Output sum of total number of pages in all books and all int values inside all sequences in data\n");
            Console.WriteLine(Data().OfType<Book>().Select(book => book.Pages).Sum()
                               +Data().OfType<IEnumerable<int>>().Sum(sum => sum.Sum()));
        }

        static void Task11()
        {
            Console.WriteLine("\nTask 11. Get the dictionary with the key - book author, value - list of author's books\n");
            Console.WriteLine(string.Join("\n",Data().OfType<Book>()
                              .ToDictionary(book => book.Author)
                               .Select(dict => $"{dict.Key}  - {dict.Value.Name}")));
        }

        static void Task12()
        {
            var data = Data();
            Console.WriteLine("\nTask 12 : Output all films of Matt Damon excluding films with actors whose name are presented in data as strings\n");
            Console.WriteLine(string.Join("\n",data.OfType<Film>()
                              .Where(film => film.Actors.Any(actor => actor.Name =="Matt Damon")
                              &&film.Actors.All(actor => !data.OfType<string>()
                              .Contains(actor.Name)))
                              .Select(film => film.Name)));
        }
    }
}
