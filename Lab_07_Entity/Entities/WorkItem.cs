using Lab_07_Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class WorkItem
{

    public int Id { get; set; }
    public string State { get; set; }
    [Column(TypeName ="varchar(200)")]
    public string Area { get; set; }
    [Column("Iteration_Path")]
    public string IterationPath { get; set; }
    public int Priority { get; set; }


    public DateTime? StartDate { get; set; }
    public DateTime? EndtDate { get; set; }
    [Column(TypeName ="decimal(5,2)")]
    public decimal Efford { get; set; }
    public string Activity { get; set; }
    public decimal RemaningWork { get; set; }

    public string Type { get; set; }

    public List<Comment> Coments { get; set; } = new List<Comment>();
    public User Author  { get; set; }
    public Guid AuthorId { get; set; }
    //public List<WorkItemTag> WorkItemTags { get; set; } = new List<WorkItemTag>();

    public List<Tag> Tags { get; set; } = new List<Tag>();

}
