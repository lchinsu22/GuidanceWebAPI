using GuidanceDataAccess.DAModel.MasterList;
using GuidanceWebAPI.DTOModel.MasterList;
using GuidanceWebAPI.DTOService;
using System.Web.Http;

namespace GuidanceWebAPI.Controllers.MasterList
{
    [Authorize]
    public class DoctorController : CRUDController<DoctorDTO, Doctor>
    {
        public DoctorController(ICRUDDTOService<DoctorDTO, Doctor> dtoService) : base(dtoService)
        {
        }
    }
}