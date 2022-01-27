using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.Core.Mock.Storage;
using Avanade.Allocation.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Allocation.Core.Mock.Repositories
{
    public class EmployeeRepositoryMock : IEmployeeRepository
    {
        public void Create(Employee employee)
        {
            var newId = AllocationMockStorage.Employees.Max(e => e.Id) + 1;
            employee.Id = newId;
            AllocationMockStorage.Employees.Add(employee);
        }

        public void Delete(Employee employee)
        {
            //cerco l'impiegato con id passato in input
            var existingEmployee = AllocationMockStorage.Employees.FirstOrDefault(e => e.Id == employee.Id);
            AllocationMockStorage.Employees.Remove(existingEmployee);
        }

        public IList<Employee> FetchAll()
        {
            return AllocationMockStorage
                .Employees
                .OrderBy(x => x.LastName)
                .ToList();
        }

        public void Update(Employee oldEmp, Employee newEmp)
        {
            var existingEmployee = AllocationMockStorage.Employees.FirstOrDefault(e => e.Id == newEmp.Id);
            //Rimuovo l'elemento esistente dalla lista e lo riaggiungo quello passato in input subito dopo
            AllocationMockStorage.Employees.Remove(oldEmp);

            AllocationMockStorage.Employees.Add(newEmp);
        }
    }
}
