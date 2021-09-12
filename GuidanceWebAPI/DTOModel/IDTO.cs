using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;

namespace GuidanceWebAPI.DTOModel
{
    public interface IDTO<DTO, DA>
    {
        DTO getDTO(DA data);
        List<DTO> getDTOs(List<DA> list);
        DA getDA();
        void setLinks(UrlHelper url);

    }
}
