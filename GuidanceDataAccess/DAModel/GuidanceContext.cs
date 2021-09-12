using GuidanceDataAccess.DAModel.Form;
using GuidanceDataAccess.DAModel.MasterList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidanceDataAccess.DAModel
{
    public class GuidanceContext : DbContext
    {

        public GuidanceContext()
            : base("name=GuidanceDbService")
        {
        }

        //Associated Entities        
        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<Ward> Wards { get; set; }
        public virtual DbSet<HospitalDeptUnit> HospitalDeptUnits { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
    }
}
