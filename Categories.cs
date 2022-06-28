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
            int counter = 1;
            Console.WriteLine("All available categories : \n");
            foreach (string category in CategoriesNames)
            {
                Console.WriteLine($"{counter}-{category} \n");
                counter++;
            }
        }

    }
}
