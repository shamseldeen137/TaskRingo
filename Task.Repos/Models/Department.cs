using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Repos.Models;

public partial class Department
{
    [Key]
    public Guid DepartmentId { get; set; }

    [Required]
    [StringLength(255)]
    [Display(Name = "Department Name")]

    public string? DepartmentName { get; set; } 
  
    public Guid? ParentId { get; set; }

    [ForeignKey("ParentId")]
    [Display(Name = "Direct Parent")]

    public virtual Department ParentDepartment { get; set; }
    [Display(Name = "Direct Sub Departments")]

    public virtual ICollection<Department> SubDepartments { get; set; }


    [StringLength(255)]
    public string? Logo { get; set; } = null!;
    public  bool IsDeleted {  get; set; }=false;







    [NotMapped]
    [Display(Name ="Level to selected department")]
    public int Level { get; set; }
    [NotMapped]
    public IFormFile LogoFile { get; set; }
    public Department()
    {
        DepartmentId = Guid.NewGuid();
        SubDepartments = new HashSet<Department>();
    }
}
