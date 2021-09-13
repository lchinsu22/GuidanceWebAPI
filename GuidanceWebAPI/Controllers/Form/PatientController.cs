using System.Collections.Generic;
using System.Web.Http;
using GuidanceDataAccess.DAModel.Form;
using GuidanceWebAPI.DTOModel.Form;
using GuidanceWebAPI.DTOService;
using GuidanceWebAPI.ExceptionFilter;

namespace GuidanceWebAPI.Controllers.Form
{
    [Authorize]
    public class PatientController : ApiController
    {
        private IFormDTOService _formDTOService;

        public PatientController(IFormDTOService formDTOService)
        {
            _formDTOService = formDTOService;
        }

        [HttpPost]
        [Route("api/Patient")]
        [CustomControllerExceptionFilter]
        [CustomControllerActionFilter]
        public IHttpActionResult AddPatient(PatientDTO PatientDTO)
        {
            PatientDTO result = _formDTOService.SavePatientDetail(PatientDTO);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("api/Patient/{id}")]
        [CustomControllerExceptionFilter]
        [CustomControllerActionFilter]
        public IHttpActionResult FindPatient(int id)
        {
            PatientDTO result = _formDTOService.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("api/Patient")]
        [CustomControllerExceptionFilter]
        [CustomControllerActionFilter]
        public IHttpActionResult GetAllPatient()
        {
            List<PatientDTO> result = _formDTOService.GetAllPatients();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpDelete]
        [Route("api/Patient/{id}")]
        [CustomControllerExceptionFilter]
        [CustomControllerActionFilter]
        public int Delete(long id)
        {
            return _formDTOService.DeletePatient(id);
        }

    }
}