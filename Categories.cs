using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    internal class Categories
    {
        public static List<string> CategoriesNames { get; set; } = new List<string>();

        public static void AddCategory(string category)
        {
            CategoriesNames.Add(category);
        }
        public static void ListCategories()
        {
            // Create the tree
            var root = new Tree("Categories");
            foreach (var category in CategoriesNames)
            {
                // Add some nodes
                var node = root.AddNode($"[aqua]{category}[/]");
            }

            // Render the tree
            AnsiConsole.Write(root);  


            //int counter = 1;
            //Console.WriteLine("All available categories : \n");
            //foreach (string category in CategoriesNames)
            //{
            //    Console.WriteLine($"{counter}-{category} \n");
            //    counter++;
            //}
        }
        public static void DeleteCategory(string category)
        {
            CategoriesNames.Remove(category);
        }

    }
}
