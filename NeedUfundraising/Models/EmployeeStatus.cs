using System;
using System.Collections.Generic;

#nullable disable

namespace NeedUfundraising.Models
{
    public partial class EmployeeStatus
    {
        public EmployeeStatus()
        {
            Employees = new HashSet<Employee>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
