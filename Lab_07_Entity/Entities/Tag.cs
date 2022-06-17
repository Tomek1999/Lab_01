using Lab_07_Entity.Entities;
using System;
using System.Collections.Generic;

namespace Lab_07_Entity.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        public string Value { get; set; }
        public List<WorkItem> WorkItems { get; set; } = new List<WorkItem>();
        //public List<WorkItemTag> WorkItemTags { get; set; } = new List<WorkItemTag>();

    }
}
