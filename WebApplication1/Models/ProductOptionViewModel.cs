using System.Linq;

namespace WebApplication1.Models
{
    public class ProductOptionViewModel
    {
        public int? CategoryId { get; set; }
        public IGrouping<int?, ProductOption> ProductOptions;
    }
    //public class Group<T, K>
    //{
    //    public int? Key;
    //    public IGrouping<int?, ProductOption> Values;
    //}
}