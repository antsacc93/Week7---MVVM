using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avanade.Allocation.Core.Entities;

namespace Avanade.Allocation.WPF.Messaging.Employee
{
    public class ShowUpdateEmployeeMessage
    {
        //qui ho dovuto specificare per intero il namespace dal momento che 
        //ho chiamato la cartella Employee
        public Avanade.Allocation.Core.Entities.Employee Entity { get; set; }
    }
}
