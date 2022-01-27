using Avanade.Allocation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Allocation.Core.Mock.Storage
{
    public static class AllocationMockStorage
    {
        public static IList<User> Users { get; set; }
        public static IList<Employee> Employees { get; set; }

        public static void Initialize()
        {
            #region USER
            //creazione della lista vuota
            Users = new List<User>();

            //Aggiunta di utenti base
            Users.Add(new User
            {
                Id = 1111,
                UserName = "mario.rossi",
                Password = "12345",
                Email = "mario@gmail.com"
            });
            Users.Add(new User
            {
                Id = 2222,
                UserName = "giuseppe.verdi",
                Password = "abcdefh",
                Email = "giuseppe@gmail.com"
            });
            #endregion

            #region EMPLOYEE
            Employees = new List<Employee>();
            Employees.Add(
                new Employee
                {
                    Id = 123,
                    FirstName = "Luciano",
                    LastName = "Ligabue",
                    Email = "luciano@gmail.com",
                    DateOfBirth = new DateTime(1970, 2, 4),
                    IsEnabled = true,
                    Salary = 12342.0
             });
            Employees.Add(
                new Employee
                {
                    Id = 122,
                    FirstName = "Federica",
                    LastName = "Pellegrini",
                    Email = "federica@gmail.com",
                    DateOfBirth = new DateTime(1980, 2, 4),
                    IsEnabled = true,
                    Salary = 12222.0
                });

            #endregion
        }
    }
}
