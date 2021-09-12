using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Routing;
using GuidanceDataAccess.DAModel.MasterList;

namespace GuidanceWebAPI.DTOModel.MasterList
{

    public class GenderDTO : IDTO<GenderDTO, Gender>
    {

        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public bool Inactive { get; set; }
        public int SortIndex { get; set; }

        public List<Link> links { get; set; }



        public GenderDTO getDTO(Gender data)
        {
            if (data != null)
            {
                GenderId = data.GenderId;
                GenderName = data.GenderName;
                Inactive = data.Inactive;
                SortIndex = data.SortIndex;
                return this;
            }
            else
            {
                return null;
            }
        }

        public List<GenderDTO> getDTOs(List<Gender> list)
        {
            List<GenderDTO> dtos = new List<GenderDTO>();
            foreach (Gender item in list)
            {
                dtos.Add(new GenderDTO().getDTO(item));
            }
            dtos = dtos.OrderBy(p => p.SortIndex).ToList();
            return dtos;
        }

        public Gender getDA()
        {
            return new Gender
            {
                GenderId = this.GenderId,
                GenderName = this.GenderName,
                Inactive = this.Inactive,
                SortIndex = this.SortIndex
            };
        }

        public void setLinks(UrlHelper url)
        {
            var idObj = new { id = GenderId };
            links.Add(new Link(url.Link("Get", idObj), "self", "GET"));
            links.Add(new Link(url.Link("Get", idObj), "Update-Gender", "PUT"));
            links.Add(new Link(url.Link("Get", idObj), "delete-Gender", "DELETE"));
        }


    }
}