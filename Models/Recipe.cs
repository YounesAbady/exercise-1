using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1.Models
{
    internal class Recipe
    {
        public Recipe()
        {
        }
        public Recipe(string title, List<string> ingredients, List<string> instructions, List<string> categories)
        {
            Title = title;
            Ingredients = ingredients;
            Instructions = instructions;
            Categories = categories;
        }

        public string Title { get; set; } = string.Empty;
        public List<string> Ingredients { get; set; } = new List<string>();
        public List<string> Instructions { get; set; } = new List<string>();
        public List<string> Categories { get; set; } = new List<string>();
    }
}
