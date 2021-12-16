namespace mvc4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.Instructor")]
    public partial class Instructor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Instructor()
        {
            Ins_Course = new HashSet<Ins_Course>();
            Departments = new HashSet<Department>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage ="ID Required")]
        public int Ins_Id { get; set; }

        [StringLength(50,MinimumLength =5,ErrorMessage ="short name !?")]
        [Required(ErrorMessage ="*")]
        public string Ins_Name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="*")]
        public string Ins_Degree { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage ="*")]
        [Range(1000,15000,ErrorMessage ="salary must be between 1000 and 15000")]
        public decimal? Salary { get; set; }

        public string photo { get; set; }

        public int? Dept_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ins_Course> Ins_Course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Departments { get; set; }

        public virtual Department Department { get; set; }
    }
}
