
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07_Entity.Homework
{
    class Roles
    {

        public int Id { get; set; }
        public string Name { get; set; }


        public User User { get; set; }
        public int UserId { get; set; }


        public List<Tasks> Tasks { get; set; } = new List<Tasks>();

    }
}
