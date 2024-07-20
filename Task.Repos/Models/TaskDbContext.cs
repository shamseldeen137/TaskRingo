using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Task.Repos.Models;

public  class TaskDbContext : DbContext
{

  
    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Department> Departments { get; set; }
    public DbSet<Reminder> Reminders { get; set; }


    public override void Dispose()
    {

        Console.WriteLine("disposed");
        // Call the base class's Dispose method.
        base.Dispose();
    }
 
}
