using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workplace.Shared.Schedule
{
    public class Group
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Student[]? Students { get; set; }
    }
}
