using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.Esercitazione1.Models
{
    public interface IProductRepository
    {
        public IList<Product> GetAll();
    }
}
