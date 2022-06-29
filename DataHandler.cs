using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    internal class DataHandler
    {
        private static List<Recipe> _Recipes { get; set; } = new List<Recipe>();
        static int counter;
        public static void AddRecipe(Recipe recipe)
        {
            _Recipes.Add(recipe);
        }
        public static void ListRecipes()
        {

            var root = new Tree("Recipes");
            foreach (Recipe recipe in _Recipes)
            {
                var recipeTitle = root.AddNode($"[maroon]{recipe.Title}[/]");
                //Console.WriteLine($"Recipe title:{recipe.Title} \n Ingredients : \n");
                //counter = 1;
                var ingerdientsNode = recipeTitle.AddNode("Ingredients:");
                foreach (var ingerdient in recipe.Ingredients)
                {
                    ingerdientsNode.AddNode($"{ingerdient}");
                    //Console.WriteLine($"{counter}-{ingerdient} \n");
                    //counter++;
                }
                var instructionsNode = recipeTitle.AddNode("Instructions:");
                //Console.WriteLine("Instructions : \n");
                //counter = 1;
                foreach (var instructions in recipe.Instructions)
                {
                    instructionsNode.AddNode($"{instructions}");
                    //Console.WriteLine($"{counter}-{instructions} \n");
                    //counter++;

                }
                //counter = 1;
                var categoriesNode = recipeTitle.AddNode("Categories:");
                //Console.WriteLine("Categories : \n");
                foreach (var category in recipe.Categories)
                {
                    categoriesNode.AddNode($"{category}");
                    //Console.WriteLine($"{counter}-{category} \n");
                    //counter++;

                }
                AnsiConsole.Write(root);

            }
        }


    }
}
