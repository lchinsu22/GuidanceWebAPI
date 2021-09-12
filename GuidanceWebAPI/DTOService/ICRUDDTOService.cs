using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidanceWebAPI.DTOService
{
    public interface ICRUDDTOService<DTO, DA>
    {
        List<DTO> getDTOs();
        DTO getDTO(int id);
        DTO AddDTO(DTO dto);
        DTO UpdateDTO(DTO dto);
        int RemoveDTO(int id);
        void Dispose();
    }
}
