using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuidanceWebAPI.DTOModel.Form;

namespace GuidanceWebAPI.DTOService
{
    public interface IFormDTOService
    {
        //List<PatientSearchResultDTO> GetPatientSearchResultDTO(PatientSearchFilterDTO patientSearchFilterDTO);
        PatientDTO SavePatientDetail(PatientDTO patient);
        PatientDTO Find(long Id);
        int DeletePatient(long Id);
    }
}
