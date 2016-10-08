using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class ProductOptionViewModel
    {
        public int? CategoryId { get; set; }
        //public IGrouping<int?, ProductOption> ProductOptions;
        public IEnumerable<Product> ProductOptions;

    }
    //public class Group<T, K>
    //{
    //    public int? Key;
    //    public IGrouping<int?, ProductOption> Values;
    //}
}