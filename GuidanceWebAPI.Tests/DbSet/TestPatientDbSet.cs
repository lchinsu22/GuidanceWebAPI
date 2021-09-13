using GuidanceDataAccess.DAModel.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidanceWebAPI.Tests.DbSet
{
    class TestPatientDbSet : TestDbSet<Patient>
    {
        public override Patient Find(params object[] keyValues)
        {
            return this.SingleOrDefault(patient => patient.PatientID == (long)keyValues.Single());
        }
    }
}
