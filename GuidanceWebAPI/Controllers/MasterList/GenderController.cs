using System.Web.Http;
using GuidanceDataAccess.DAModel.MasterList;
using GuidanceWebAPI.DTOModel.MasterList;
using GuidanceWebAPI.DTOService;

namespace GuidanceWebAPI.Controllers.MasterList
{

    [Authorize]
    public class GenderController : CRUDController<GenderDTO, Gender>
    {
        public GenderController(ICRUDDTOService<GenderDTO, Gender> dtoService) : base(dtoService)
        {
        }
    }
}