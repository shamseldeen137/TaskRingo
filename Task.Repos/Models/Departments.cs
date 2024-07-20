using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Repos.Models;

public partial class Departments
{
    [Key]
    public Guid DepartmentId { get; set; }

    [Required]
    [StringLength(255)]
    public string? DepartmentName { get; set; } 
    [NotMapped]
    public int Level { get; set; }
    public Guid? ParentId { get; set; }

    [ForeignKey("ParentId")]
    public virtual Department ParentDepartment { get; set; }

    public virtual ICollection<Department> SubDepartments { get; set; }


    [StringLength(255)]
    public string? Logo { get; set; }
    public  bool IsDeleted {  get; set; }=false;

    public Departments()
    {
        DepartmentId = Guid.NewGuid();
        SubDepartments = new HashSet<Department>();
    }
}
