using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj nazwe kategorii");
            String catName = Console.ReadLine();
            Category category = new Category {Name = catName};
            ProdContext productContext = new ProdContext();
            try
            {
                productContext = new ProdContext();
                productContext.Categories.Add(category);

                productContext.Categories.Add(new Category { Name = "AAA" });
                productContext.Categories.Add(new Category { Name = "BBB" });
                productContext.Categories.Add(new Category { Name = "AB" });
                productContext.SaveChanges();

            }
            catch (InvalidOperationException exception)
            {

                Debug.WriteLine(exception.ToString());
            }

            var query = (from item in productContext.Categories
                select item).ToList();

            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }

            CategoryForm categoryForm = new CategoryForm();
            categoryForm.Show();

            catName = Console.ReadLine();
        }
    }
}
