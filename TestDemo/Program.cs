using System;
using System.Linq;

namespace TestDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDemoEntities db = new ProductDemoEntities();

            //var query = from p in db.Products
            //            join po in db.ProductOptions on p.Id equals po.OptionId
            //            where po.ProductId == 4
            //            group p by p.CategoryId
            //    into g


            //            select new
            //            {
            //                CategoryId = g.Key,
            //                Options = g.Select(x => x.Name)
            //            };

            var query = db.ProductOptions.Where(x => x.ProductId == 4).GroupBy(x => x.Product.CategoryId).Select(g => new
            {
                CategoryId = g.Key,
                Products = g.Select(x => x.Product)

            });

            //var query = db.Products.Include(x => x.ProductOptions1).GroupBy(x => x.CategoryId).Select(g => new
            //{
            //    CategoryId = g.Key,
            //    Products = g.Select(x => x.ProductOptions1)

            //});


            foreach (var item in query)
            {

                Console.WriteLine("Category: " + item.CategoryId);

                foreach (var option in item.Products)
                {
                    Console.WriteLine("\t " + option.Name);
                }

            }
            Console.ReadLine();
        }
    }
}
