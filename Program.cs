using System;
using exercise_1.Models;
using Spectre.Console;
namespace exercise_1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataHandler.Deserialize();
            Categories.Deserialize();
            var userInput = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("What's your [green]option[/]?")
        .PageSize(7)
        .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
        .AddChoices(new[] {
                    "For adding a category", "For adding a recipe", "For listing categories",
                    "For listing recipes", "For editing categories","For editing recipes","[red]Close the application[/]"
        }));
            while (userInput != "x")
            {
                switch (userInput)
                {
                    case "For adding a category":
                        Categories.AddCategory();
                        break;
                    case "For adding a recipe":
                        DataHandler.AddRecipe();
                        break;
                    case "For listing categories":
                        Categories.ListCategories();
                        break;
                    case "For listing recipes":
                        DataHandler.ListRecipes();
                        break;
                    case "For editing categories":
                        Categories.EditCategory();
                        break;
                    case "[red]Close the application[/]":
                        DataHandler.Serialize();
                        Categories.Serialize();
                        Environment.Exit(0);
                        break;
                    case "For editing recipes":
                        DataHandler.EditRecipe();
                        break;
                    default:
                        Console.WriteLine("Enter a valid option!");
                        break;
                }
                userInput = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("What's your [green]option[/]?")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
        .AddChoices(new[] {
            "For adding a category", "For adding a recipe", "For listing categories",
            "For listing recipes", "For editing categories","For editing recipes","[red]Close the application[/]"
        }));
                Console.Clear();
            }
        }
    }
}
