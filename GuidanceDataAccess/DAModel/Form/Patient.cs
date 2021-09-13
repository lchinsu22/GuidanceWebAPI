using GuidanceDataAccess.DAModel.MasterList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidanceDataAccess.DAModel.Form
{

    public class Patient
    {
        [Key]
        public long PatientID { get; set; }

        [Required]
        public string PatientName { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int GenderId { get; set; }

        public string City { get; set; }

        public int? PostalCode { get; set; }

        public int? WardId { get; set; }

        public string Bed { get; set; }

        public int? HospitalDeptUnitId { get; set; }      

        [Required]
        [Column(TypeName = "date")]
        public DateTime AdmissionDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DischargedDate { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public virtual Ward Ward { get; set; }
        public virtual HospitalDeptUnit HospitalDeptUnit { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
