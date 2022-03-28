using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contracts
{
    public interface IProductService
    {
        (bool created, string error) Create(CreateViewModel model);

        IEnumerable<ProductListViewModel> GetProducts();
    }
}
