using GuidanceDataAccess.DAModel.Form;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuidanceDataAccess.DAModel.MasterList
{

    [Table("refHospitalDeptUnit")]
    public partial class HospitalDeptUnit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HospitalDeptUnit()
        {
            Patients = new HashSet<Patient>();
        }

        [Key]
        public int HospitalDeptUnitId { get; set; }

        [Required]
        [StringLength(100)]
        public string HospitalDeptUnitName { get; set; }

        public bool Inactive { get; set; }

        public int SortIndex { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patients { get; set; }
    }

}
