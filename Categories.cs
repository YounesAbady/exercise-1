using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace exercise_1
{
    internal class Categories
    {
        public static List<string> CategoriesNames { get; set; } = new List<string>();

        public static void AddCategory()
        {
            Console.WriteLine("Enter Category name");
            var category = Console.ReadLine();
            CategoriesNames.Add(category);
        }
        public static void ListCategories()
        {
            int counter = 1;
            // Create the tree
            var root = new Tree("Categories");
            foreach (var category in CategoriesNames)
            {
                // Add some nodes
                var node = root.AddNode($"{counter}-[aqua]{category}[/]");
                counter++;
            }

            // Render the tree
            AnsiConsole.Write(root);
        }
        public static void DeleteCategory(string category)
        {
            CategoriesNames.Remove(category);
        }
        public static void EditCategory()
        {
            string input = null;
            Categories.ListCategories();
            Console.WriteLine("Please select number of category to edit");
            input = Console.ReadLine();
            Console.WriteLine("If you want to delete it enter x or enter new name to edit it");
            string newName = Console.ReadLine();
            if (newName == "x") { Categories.DeleteCategory(Categories.CategoriesNames[int.Parse(input) - 1]); }
            else { Categories.CategoriesNames[int.Parse(input) - 1] = newName; }
        }
        public static void Serialize()
        {
            string fileName = @"C:\Users\youne\source\repos\exercise-1\exercise-1\Categories.json";
            string jsonString = JsonSerializer.Serialize(CategoriesNames);
            File.WriteAllText(fileName, jsonString);
        }
        public static void Deserialize()
        {
            string fileName = @"C:\Users\youne\source\repos\exercise-1\exercise-1\Categories.json";
            string jsonString = File.ReadAllText(fileName);
            CategoriesNames = JsonSerializer.Deserialize<List<string>>(jsonString);
        }
    }
}
