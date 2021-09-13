using GuidanceDataAccess.DAModel.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidanceDataAccess.DAModel
{
    public interface IFormContext : IDisposable
    {
        //List<PatientSearchResult> SearchPatient(PatientSearchFilter patientSearchFilter);
        Patient FindPatient(long Id);
        Patient SavePatient(Patient patient);
        int DeletePatient(long Id);
        List<Patient> GetAllPatients();
    }
}
