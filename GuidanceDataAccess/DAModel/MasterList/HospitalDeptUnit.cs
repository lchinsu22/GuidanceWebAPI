using GuidanceDataAccess.DAModel.Form;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuidanceDataAccess.DAModel.MasterList
{

    [Table("refHospitalDeptUnit")]
    public partial class HospitalDeptUnit
    {
        [Key]
        public int HospitalDeptUnitId { get; set; }

        [Required]
        [StringLength(100)]
        public string HospitalDeptUnitName { get; set; }

        public bool Inactive { get; set; }

        public int SortIndex { get; set; }

        public virtual List<Patient> Patients { get; set; }
    }

}
