using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFOneToManyAssignment.Data.Entities
{
    public class EmployeeOrganizations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? OrgnizatinName { get; set; }
        public Employee? Employee { get; set; }
    }
}
