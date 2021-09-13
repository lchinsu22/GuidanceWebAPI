using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuidanceDataAccess.DAModel.Form;

namespace GuidanceWebAPI.DAService
{
    public interface IFormDAService
    {
        Patient FindPatient(long Id);
        Patient SavePatient(Patient patient);
        int DeletePatient(long Id);
        List<Patient> GetAllPatients();
    }
}
