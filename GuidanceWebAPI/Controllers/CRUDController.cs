using System.Collections.Generic;
using System.Web.Http;
using GuidanceWebAPI.DTOService;
using GuidanceWebAPI.ExceptionFilter;

namespace GuidanceWebAPI.Controllers
{

    public class CRUDController<DTO, DA> : ApiController
    {
        private ICRUDDTOService<DTO, DA> _dtoService;

        public CRUDController(ICRUDDTOService<DTO, DA> dtoService)
        {
            this._dtoService = dtoService;
        }


        [HttpGet]
        [CustomControllerExceptionFilter]
        [CustomControllerActionFilter]
        public IHttpActionResult Get()
        {
            List<DTO> dtos = _dtoService.getDTOs();
            if (dtos == null)
            {
                return NotFound();
            }
            return Ok(dtos);
        }

        //[HttpGet]
        //[Route("{id}")]
        //public DTO Get(int id)
        //{
        //    return _dtoService.getDTO(id);
        //}

        [HttpGet]
        [Route("{id}")]
        [CustomControllerExceptionFilter]
        [CustomControllerActionFilter]
        public IHttpActionResult Get(int id)
        {
            DTO result = _dtoService.getDTO(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [CustomControllerExceptionFilter]
        [CustomControllerActionFilter]
        public IHttpActionResult Post(DTO value)
        {
            DTO result = _dtoService.AddDTO(value);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        [CustomControllerExceptionFilter]
        [CustomControllerActionFilter]
        public IHttpActionResult Put(int id, DTO value)
        {
            DTO result = _dtoService.UpdateDTO(value);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public int Delete(int id)
        {
            return _dtoService.RemoveDTO(id);
        }
    }
}