using GuidanceDataAccess.DAModel.Form;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuidanceDataAccess.DAModel.MasterList
{

    [Table("refGender")]
    public partial class Gender
    {
        [Key]
        public int GenderId { get; set; }

        [Required]
        [StringLength(100)]
        public string GenderName { get; set; }

        public bool Inactive { get; set; }

        public int SortIndex { get; set; }

        public virtual List<Patient> Patients { get; set; }
    }
}
