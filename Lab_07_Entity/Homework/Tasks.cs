using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07_Entity.Homework
{
    class Tasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Roles Roles { get; set; }
        public int RolesId { get; set; }
    }
}
