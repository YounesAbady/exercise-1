using System;
using Spectre.Console;
namespace exercise_1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userInput = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("What's your [green]option[/]?")
        .PageSize(6)
        .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
        .AddChoices(new[] {
                    "For adding a category", "For adding a recipe", "For listing categories",
                    "For listing recipes", "For Editing categories","Close the application"

        }));
            string input = null;
            while (userInput != "x")
            {
                switch (userInput)
                {

                    case "For adding a category":
                        Console.WriteLine("Enter Category name");
                        var category = Console.ReadLine();
                        Categories.AddCategory(category);
                        break;
                    case "For adding a recipe":
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
                            Console.WriteLine("Enter Category number from list or x to go to the next step");
                            input = Console.ReadLine();
                            if (input == "x") break;
                            recipe.Categories.Add(Categories.CategoriesNames[int.Parse(input) - 1]);
                        }
                        DataHandler.AddRecipe(recipe);
                        break;
                    case "For listing categories":
                        Categories.ListCategories();
                        break;
                    case "For listing recipes":
                        DataHandler.ListRecipes();
                        break;
                    case "For Editing categories":
                        Categories.ListCategories();
                        Console.WriteLine("Please select number of category to edit");
                        input = Console.ReadLine();
                        Console.WriteLine("If you want to delete it enter x or enter new name to edit it");
                        string newName = Console.ReadLine();
                        if (newName == "x") { Categories.DeleteCategory(Categories.CategoriesNames[int.Parse(input) - 1]); break; }
                        Categories.CategoriesNames[int.Parse(input) - 1] = newName;
                        break;
                    case "Close the application":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter a valid number!");
                        break;
                }

                //Console.WriteLine("Enter number for new opreation or x for closing the app");
                userInput = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("What's your [green]option[/]?")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
        .AddChoices(new[] {
            "For adding a category", "For adding a recipe", "For listing categories",
            "For listing recipes", "For Editing categories","Close the application"

        }));
                Console.Clear();
                //userInput = Console.ReadLine();
            }

        }


    }
}
