using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuidanceDataAccess.DAModel;
using GuidanceDataAccess.DAModel.Form;

namespace GuidanceWebAPI.DAService.Entity_Framework
{

    public class EFFormDAService : IFormDAService
    {
        private IFormContext _formcontext;

        public EFFormDAService(IFormContext formcontext)
        {
            _formcontext = formcontext;
        }

        //public List<PatientSearchResult> GetSearchPatientResult(PatientSearchFilter patientSearchFilter)
        //{
        //    return _afnapscontext.SearchPatient(patientSearchFilter);
        //}  

        public Patient FindPatient(long Id)
        {
            return _formcontext.FindPatient(Id);
        }

        public Patient SavePatient(Patient patient)
        {
            return _formcontext.SavePatient(patient);
        }

        public int DeletePatient(long Id)
        {
            return _formcontext.DeletePatient(Id);
        }
    }
}