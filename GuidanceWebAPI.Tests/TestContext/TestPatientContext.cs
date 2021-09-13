using GuidanceDataAccess.DAModel;
using GuidanceDataAccess.DAModel.Form;
using GuidanceWebAPI.Tests.DbSet;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidanceWebAPI.Tests.TestContext
{

    public class TestPatientContext : IFormContext
    {
        public TestPatientContext()
        {
            this.patients = new TestPatientDbSet();
        }

        public DbSet<Patient> patients { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void Dispose() { }

        public Patient FindPatient(long Id)
        {
            return this.patients.Find(Id);
        }

        public Patient SavePatient(Patient patient)
        {
            if(patient.PatientID == 0)
            {
                this.patients.Add(patient);
            }
            else
            {
                this.patients.Attach(patient);
            }
            
            return patient;
        }

        public int DeletePatient(long Id)
        {
            var result = this.patients.Find(Id);
            if (result == null)
                return 0;
            this.patients.Remove(this.patients.Find(Id));           
            return (this.patients.Find(Id) == null)?1:0;
        }

        public List<Patient> GetAllPatients()
        {
            return this.patients.ToList();
        }
    }
}
