using System.Collections.Generic;
using GuidanceWebAPI.DAService;
using GuidanceWebAPI.DTOModel.Form;

namespace GuidanceWebAPI.DTOService
{

    public class FormDTOService : IFormDTOService
    {
        private IFormDAService _formDAService;

        public FormDTOService(IFormDAService formDAService)
        {
            _formDAService = formDAService;
        }

        //public List<PatientSearchResultDTO> GetPatientSearchResultDTO(PatientSearchFilterDTO patientSearchFilterDTO)
        //{
        //    List<PatientSearchResult> patientInfoSearchResultList = _afnapsDAService.GetSearchPatientResult(patientSearchFilterDTO.getDA());
        //    return new PatientSearchResultDTO().getDTOs(patientInfoSearchResultList);
        //}

        public int DeletePatient(long Id)
        {
            return _formDAService.DeletePatient(Id);
        }

        public PatientDTO SavePatientDetail(PatientDTO patient)
        {
            var item = _formDAService.SavePatient(patient.getDA());
            return new PatientDTO().getDTO(item);
        }

        public PatientDTO Find(long Id)
        {
            var item = _formDAService.FindPatient(Id);
            return new PatientDTO().getDTO(item);
        }

        public List<PatientDTO> GetAllPatients()
        {
            var item = _formDAService.GetAllPatients();
            return new PatientDTO().getDTOs(item);
        }
    }
}