using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp_Level1
{
    class Program
    {
        static void Main(string[] args)
        {
     
        

            Console.ReadKey();
        }

        static void Task1()
        {
            Console.WriteLine("\nTask 1 : Print all numbers from 10 to 50 separated by commas");
            Console.WriteLine(string.Join(",",Enumerable.Range(10,50)));
        }

        static void Task2()
        {
            Console.WriteLine("\nTask 2 : Print only that numbers from 10 to 50 that can be divided by 3");
            Console.WriteLine(string.Join(",", Enumerable.Range(10, 50).Where(i => i % 3 == 0)));
        }

        static void Task3()
        {
            Console.WriteLine("\nTask 3 : Output word Linq 10 times");
            Console.WriteLine(string.Join(",",Enumerable.Repeat("Linq",10)));
        }

        static void Task4()
        {
            Console.WriteLine("\nTask 4 : Output all words with letter 'a' in string aaa; abb; ccc; dap");
            Console.WriteLine(string.Join(",", "aaa; abb; ccc; dap".Split(';')
                             .Where(i => i.Contains('a'))));
        }

        static void Task5()
        {
            Console.WriteLine("\nTask 5 : Output number of letters 'a' in the words with this letter in string  aaa; abb; ccc; dap separated by comma");
            Console.WriteLine(string.Join(",", "aaa; abb; ccc; dap".Split(';')
                              .Where(i => i.Contains('a'))
                               .Select(i =>i.Count(litera => litera=='a'))));
        }

        static void Task6()
        {
            Console.WriteLine("Task 6 : Output true if word abb exists in line  aaa; xabbx; abb; ccc; dap, otherwise false");
            Console.WriteLine(string.Join(",", "aaa; xabbx; abb; ccc; dap".Split(';')
                              .Select(i => i.Contains("abb"))));
        }

        static void Task7()
        {
            Console.WriteLine("\nTask 7 :  Get the longest word in string aaa; xabbx; abb; ccc; dap");
            Console.WriteLine("aaa; xabbx; abb; ccc; dap".Split(';')
                              .First(str => "aaa; xabbx; abb; ccc; dap".Split(';')
                               .Max(s => s.Length)==str.Length));
        }

        static void Task8()
        {
            Console.WriteLine("\nTask 8 : Calculate average length of word in string aaa; xabbx; abb; ccc; dap");
            Console.WriteLine(" aaa; xabbx; abb; ccc; dap".Split(';')
                             .Average(str => str.Length));
        }

        static void Task9()
        {
            Console.WriteLine("\nTask 9 : Print the shortest word reversed in string ak; xabbx; abb; ccc; dap; zha ");
            Console.WriteLine("ak; xabbx; abb; ccc; dap; zha".Split(';')
                             .Last(str => "ak; xabbx; abb; ccc; dap; zh".Split(';')
                              .Min(s => s.Length)==str.Length)
                              .Reverse().ToArray());
        }

        static void Task10()
        {
            Console.WriteLine("\nTask 10 : " +
                "            Print true if in the first word that starts from aa all letters are 'a' " +
                "            otherwise false baaa; aabb; xabbx; abb; ccc; dap; zh");
            Console.WriteLine("baaa; aabb; xabbx; abb; ccc; dap; zh".Split(';')
                             .FirstOrDefault(str=> str.StartsWith("aa"))
                              .Any(ch => ch=='a'));
        }

        static void Task11()
        {
            Console.WriteLine("\nTask 11 :  Print last word in sequence that excepting first two elements that ends with bb");
            Console.WriteLine("baaa; aabb; xabbx; abb; ccc; dap; zh".Split(';')
                             .SkipWhile((str,index) => str.EndsWith("bb")&& index <2)
                             .Last());
        }


    }
}
