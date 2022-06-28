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
        public static void PrintDetails(Recipe recipe)
        {
            Console.WriteLine($"Recipe title:{recipe.Title} \n Ingredients : \n");
            counter = 1;
            foreach (var ingerdient in recipe.Ingredients)
            {
                Console.WriteLine($"{counter}-{ingerdient} \n");
                counter++;
            }
            Console.WriteLine("Instructions : \n");
            counter = 1;
            foreach (var instructions in recipe.Instructions)
            {
                Console.WriteLine($"{counter}-{instructions} \n");
                counter++;

            }
            counter = 1;
            Console.WriteLine("Categories : \n");
            foreach (var category in recipe.Categories)
            {
                Console.WriteLine($"{counter}-{category} \n");
                counter++;

            }

        }
        public static void AddRecipe(Recipe recipe)
        {
            _Recipes.Add(recipe);
        }
        public static void ListRecipes()
        {
            foreach (Recipe recipe in _Recipes)
            {
                PrintDetails(recipe);
            }
        }


    }
}
