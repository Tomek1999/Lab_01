using System;
using System.Collections.Generic;

public class User 
{
    public Guid id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public Address Address { get; set; }
    public List<WorkItem> WorkItems { get; set; } = new List<WorkItem>();

}