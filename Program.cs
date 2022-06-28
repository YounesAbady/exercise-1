using System;

namespace exercise_1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("For adding a category please enter 1");
            Console.WriteLine("For adding a recipe please enter 2");
            Console.WriteLine("For listing categories please enter 3");
            Console.WriteLine("For listing recipes please enter 4");
            Console.WriteLine("For Editing categories please enter 5");
            var userInput = Console.ReadLine();
            string input = null;
            while (userInput != "x")
            {
                switch (userInput)
                {

                    case "1":
                        Console.WriteLine("Enter Category name");
                        var category = Console.ReadLine();
                        Categories.AddCategory(category);
                        break;
                    case "2":
                        Recipe recipe = new Recipe();
                        Console.WriteLine("Enter recipe name");
                        recipe.Title = Console.ReadLine();
                        for (int counter = 1; input != "x"; counter++)
                        {
                            Console.WriteLine($"Enter ingredient number {counter} or x to go to the next step");
                            input = Console.ReadLine();
                            if (input == "x") break;
                            recipe.Ingredients.Add(input);
                        }
                        input = null;

                        for (int counter = 1; input != "x"; counter++)
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
                            Console.WriteLine($"Enter Category number from list or x to go to the next step");
                            input = Console.ReadLine();
                            if (input == "x") break;
                            recipe.Categories.Add(Categories.CategoriesNames[int.Parse(input) - 1]);
                        }
                        DataHandler.AddRecipe(recipe);
                        break;
                    case "3":
                        Categories.ListCategories();
                        break;
                    case "4":
                        DataHandler.ListRecipes();
                        break;
                    case "5":
                        Categories.ListCategories();
                        Console.WriteLine("Please select number of category to edit");
                        input = Console.ReadLine();
                        Console.WriteLine("If you want to delete it enter x or enter new name to edit it");
                        string newName = Console.ReadLine();
                        if (newName == "x") { Categories.DeleteCategory(Categories.CategoriesNames[int.Parse(input) - 1]); break; }
                        Categories.CategoriesNames[int.Parse(input) - 1] = newName;
                        break;
                    default:
                        Console.WriteLine("Enter a valid number!");
                        break;
                }

                Console.WriteLine("Enter number for new opreation or x for closing the app");
                userInput = Console.ReadLine();
            }

        }


    }
}
