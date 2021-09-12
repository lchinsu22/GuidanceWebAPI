using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuidanceWebAPI.DAService;
using GuidanceWebAPI.DTOModel;

namespace GuidanceWebAPI.DTOService
{
    public class CRUDDTOService<DTO, DA> : ICRUDDTOService<DTO, DA> where DTO : IDTO<DTO, DA>, new()
    {
        private ICRUDDAService<DA> _crudDAService;

        public CRUDDTOService(ICRUDDAService<DA> crudDAService)
        {
            _crudDAService = crudDAService;
        }

        public DTO AddDTO(DTO dto)
        {
            var item = _crudDAService.AddItem(dto.getDA());
            return new DTO().getDTO(item);
        }

        public DTO getDTO(int id)
        {
            var item = _crudDAService.GetItem(id);
            return new DTO().getDTO(item);
        }

        public List<DTO> getDTOs()
        {
            var item = _crudDAService.GetItems();
            return new DTO().getDTOs(item);
        }

        public int RemoveDTO(int id)
        {
            //var item = getDTO(id).getDA();
            return _crudDAService.RemoveItem(id);
        }

        public DTO UpdateDTO(DTO dto)
        {
            var item = _crudDAService.UpdateItem(dto.getDA());
            return new DTO().getDTO(item);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}