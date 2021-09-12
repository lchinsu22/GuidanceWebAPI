using GuidanceDataAccess.DAModel.MasterList;
using GuidanceWebAPI.DTOModel.MasterList;
using GuidanceWebAPI.DTOService;
using System.Web.Http;

namespace GuidanceWebAPI.Controllers.MasterList
{
    [Authorize]
    public class HospitalDeptUnitController : CRUDController<HospitalDeptUnitDTO, HospitalDeptUnit>
    {
        public HospitalDeptUnitController(ICRUDDTOService<HospitalDeptUnitDTO, HospitalDeptUnit> dtoService) : base(dtoService)
        {
        }
    }
}