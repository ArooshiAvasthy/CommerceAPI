using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IHome
    {
        List<Product> DisplayAllProducts();
        List<Product> DisplayProductsByCategory(string CategoryName);
        int GetQuantity(string name);

        MovieList GetMovie(string movie);
    }
}
