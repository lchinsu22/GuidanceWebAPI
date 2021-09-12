using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Routing;
using GuidanceDataAccess.DAModel.MasterList;

namespace GuidanceWebAPI.DTOModel.MasterList
{
    public class WardDTO : IDTO<WardDTO, Ward>
    {

        public int WardId { get; set; }
        public string WardName { get; set; }
        public bool Inactive { get; set; }
        public int SortIndex { get; set; }

        public List<Link> links { get; set; }

        

        public WardDTO getDTO(Ward data)
        {
            if (data != null)
            {
                WardId = data.WardId;
                WardName = data.WardName;
                Inactive = data.Inactive;
                SortIndex = data.SortIndex;
                return this;
            }
            else
            {
                return null;
            }
        }

        public List<WardDTO> getDTOs(List<Ward> list)
        {
            List<WardDTO> dtos = new List<WardDTO>();
            foreach (Ward item in list)
            {
                dtos.Add(new WardDTO().getDTO(item));
            }
            dtos = dtos.OrderBy(p => p.SortIndex).ToList();
            return dtos;
        }

        public Ward getDA()
        {
            return new Ward
            {
                WardId = this.WardId,
                WardName = this.WardName,
                Inactive = this.Inactive,
                SortIndex = this.SortIndex
            };
        }

        public void setLinks(UrlHelper url)
        {
            var idObj = new { id = WardId };
            links.Add(new Link(url.Link("Get", idObj), "self", "GET"));
            links.Add(new Link(url.Link("Get", idObj), "Update-Ward", "PUT"));
            links.Add(new Link(url.Link("Get", idObj), "delete-Ward", "DELETE"));
        }

        
    }
}