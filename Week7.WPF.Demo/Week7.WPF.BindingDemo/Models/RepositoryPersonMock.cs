using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.BindingDemo.Models
{
    public class RepositoryPersonMock : IRepositoryPerson
    {
        private IList<Person> _people = new List<Person>()
        {
            new Person{ FirstName = "Mario", LastName = "Rossi"},
            new Person { FirstName = "Luca", LastName = "Bianchi"},
            new Person { FirstName = "Giuseppe", LastName = "Verdi"}
        };
        public IList<Person> GetAll()
        {
            return _people;
        }
    }
}
