using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace exercise_1
{
    internal class DataHandler
    {
        private static List<Recipe> _Recipes { get; set; } = new List<Recipe>();
        static int counter;
        
        public static void AddRecipe()
        {
            string input = null;
            Recipe recipe = new Recipe();
            Console.WriteLine("Enter recipe name");
            recipe.Title = Console.ReadLine();
            for (counter = 1; input != "x"; counter++)
            {
                Console.WriteLine($"Enter ingredient number {counter} or x to go to the next step");
                input = Console.ReadLine();
                if (input == "x") break;
                recipe.Ingredients.Add(input);
            }
            input = null;

            for (counter = 1; input != "x"; counter++)
            {
                Console.WriteLine($"Enter instruction number {counter} or x to go to the next step");
                input = Console.ReadLine();
                if (input == "x") break;
                recipe.Instructions.Add(input);
            }
            Categories.ListCategories();
            input = null;
            while (input != "x")
            {
                Console.WriteLine("Enter Category number from list or x to go to the next step");
                input = Console.ReadLine();
                if (input == "x") break;
                recipe.Categories.Add(Categories.CategoriesNames[int.Parse(input) - 1]);
            }
            input = null;
            _Recipes.Add(recipe);
        }
        public static void ListRecipes()
        {

            var root = new Tree("[lime]Recipes[/]");
            foreach (Recipe recipe in _Recipes)
            {
                var recipeTitle = root.AddNode($"[maroon]{recipe.Title}[/]");
                //Console.WriteLine($"Recipe title:{recipe.Title} \n Ingredients : \n");
                counter = 1;
                var ingerdientsNode = recipeTitle.AddNode("[red]Ingredients:[/]");
                foreach (var ingerdient in recipe.Ingredients)
                {
                    ingerdientsNode.AddNode($"{counter}-{ingerdient}");
                    //Console.WriteLine($"{counter}-{ingerdient} \n");
                    counter++;
                }
                var instructionsNode = recipeTitle.AddNode("[red]Instructions:[/]");
                //Console.WriteLine("Instructions : \n");
                counter = 1;
                foreach (var instructions in recipe.Instructions)
                {
                    instructionsNode.AddNode($"{counter}-{instructions}");
                    //Console.WriteLine($"{counter}-{instructions} \n");
                    counter++;

                }
                //counter = 1;
                var categoriesNode = recipeTitle.AddNode("[red]Categories:[/]");
                //Console.WriteLine("Categories : \n");
                foreach (var category in recipe.Categories)
                {
                    categoriesNode.AddNode($"{counter}-{category}");
                    //Console.WriteLine($"{counter}-{category} \n");
                    counter++;

                }
            }
            AnsiConsole.Write(root);
        }
        public static void Serialize()
        {
            string fileName = @"C:\Users\youne\source\repos\exercise-1\exercise-1\Recipes.json";
            string jsonString = JsonSerializer.Serialize(_Recipes);
            File.WriteAllText(fileName, jsonString);
        }
        public static void Deserialize()
        {
            string fileName = @"C:\Users\youne\source\repos\exercise-1\exercise-1\Recipes.json";
            string jsonString = File.ReadAllText(fileName);
            _Recipes = JsonSerializer.Deserialize<List<Recipe>>(jsonString);
        }


    }
}
