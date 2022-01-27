using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.Core.Repositories;
using Avanade.Allocation.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Allocation.Core.BusinessLayer
{
    public class MainBusinessLayer
    {
        private IEmployeeRepository _EmployeeRepository;

        public MainBusinessLayer(IEmployeeRepository repoEmp)
        {
            _EmployeeRepository = repoEmp;
        }

        //Restituire la lista di dipendenti
        public IList<Employee> FetchAllEmployees()
        {
            //Semplice chiamata al repository per la restituzione i dipendenti
            return _EmployeeRepository.FetchAll();
        }

        public Response CreateEmployee(Employee entity)
        {
            //validazione dell'argomento
            if (entity == null)
                return new Response { Success = false, Message = "Invalid entity" };

            if (entity.Salary < 0.0)
                return new Response { Success = false, Message = "Salary must be positive" };
            
            _EmployeeRepository.Create(entity);
            //Emetto la risposta con esito positivo
            return new Response { 
                Success = true, 
                Message = $"Employee: {entity.FirstName} {entity.LastName} created" 
            };
        }

        public Response DeleteEmployee(Employee entity)
        {
            if (entity == null)
                return new Response { Success = false, Message = "Invalid entity" };
            if (entity.Id < 0)
                return new Response { Success = false, Message = "Invalid ID" };
            var employeeToDelete = FetchAllEmployees().FirstOrDefault(x => x.Id == entity.Id);
            if (employeeToDelete == null)
                return new Response
                {
                    Success = false,
                    Message = $"No employee with ID: {entity.Id}"
                };
            _EmployeeRepository.Delete(employeeToDelete);

            return new Response { Success = true, Message = $"Employee deleted" };
        }

        public Response UpdateEmployee(Employee entity)
        {
            //Validazione argomenti
            if (entity == null)
                return new Response() { Success = false, Message = "Incorrect entity" };

            //CERCARE L'IMPIEGATO DA MODIFICARE
            var employeeToUpdate = FetchAllEmployees().FirstOrDefault(x => x.Id == entity.Id);

            //Se invece la lista è vuota significa che è andato tutto bene
            _EmployeeRepository.Update(employeeToUpdate, entity);

            //Emetto comunque la lista (vuota) per segnalare che è andato tutto bene
            return new Response() { Success = true, Message = "Employee updated" };
        }

    }
}
