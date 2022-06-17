using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07_Entity.Entities
{
    class WorkItemTag
    {
        public int id { get; set; }

        public WorkItem WorkItem { get; set; }
        public int WorkItemId { get; set; }

        public Tag Tag { get; set; }
        public int TagId { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
