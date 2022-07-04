using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace exercise_1.Models
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
            foreach (Recipe recipe in DataHandler.Recipes)
            {
                if (recipe.Categories.Contains(category))
                    recipe.Categories.Remove(category);
            }
            CategoriesNames.Remove(category);
        }
        public static void EditCategory()
        {
            string input = String.Empty;
            ListCategories();
            Console.WriteLine("Please select number of category to edit");
            input = Console.ReadLine();
            Console.WriteLine("If you want to delete it enter x or enter new name to edit it");
            string newName = Console.ReadLine();
            if (newName == "x") { DeleteCategory(CategoriesNames[int.Parse(input) - 1]); }
            else
            {
                foreach (Recipe recipe in DataHandler.Recipes)
                {
                    if (recipe.Categories.Contains(CategoriesNames[int.Parse(input) - 1]))
                    {
                        recipe.Categories[recipe.Categories.IndexOf(CategoriesNames[int.Parse(input) - 1])] = newName;
                    }
                }
                CategoriesNames[int.Parse(input) - 1] = newName;
            }
        }
        public static void Serialize()
        {
            string startupPath = Environment.CurrentDirectory;
            string fileName = @$"{startupPath}\Categories.json";
            string jsonString = JsonSerializer.Serialize(CategoriesNames);
            File.WriteAllText(fileName, jsonString);
        }
        public static void Deserialize()
        {
            string startupPath = Environment.CurrentDirectory;
            string fileName = @$"{startupPath}\Categories.json";
            string jsonString = File.ReadAllText(fileName);
            CategoriesNames = JsonSerializer.Deserialize<List<string>>(jsonString);
        }
    }
}
