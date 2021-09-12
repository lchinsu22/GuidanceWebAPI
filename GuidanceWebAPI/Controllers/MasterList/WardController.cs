using GuidanceDataAccess.DAModel.MasterList;
using GuidanceWebAPI.DTOModel.MasterList;
using GuidanceWebAPI.DTOService;
using System.Web.Http;

namespace GuidanceWebAPI.Controllers.MasterList
{
    [Authorize]
    public class WardController : CRUDController<WardDTO, Ward>
    {
        public WardController(ICRUDDTOService<WardDTO, Ward> dtoService) : base(dtoService)
        {
        }
    }
}