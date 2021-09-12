using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;
using GuidanceDataAccess.DAModel.MasterList;

namespace GuidanceWebAPI.DTOModel.MasterList
{

    public class HospitalDeptUnitDTO : IDTO<HospitalDeptUnitDTO, HospitalDeptUnit>
    {

        public int HospitalDeptUnitId { get; set; }
        public string HospitalDeptUnitName { get; set; }
        public bool Inactive { get; set; }
        public int SortIndex { get; set; }

        public List<Link> links { get; set; }



        public HospitalDeptUnitDTO getDTO(HospitalDeptUnit data)
        {
            if (data != null)
            {
                HospitalDeptUnitId = data.HospitalDeptUnitId;
                HospitalDeptUnitName = data.HospitalDeptUnitName;
                Inactive = data.Inactive;
                SortIndex = data.SortIndex;
                return this;
            }
            else
            {
                return null;
            }
        }

        public List<HospitalDeptUnitDTO> getDTOs(List<HospitalDeptUnit> list)
        {
            List<HospitalDeptUnitDTO> dtos = new List<HospitalDeptUnitDTO>();
            foreach (HospitalDeptUnit item in list)
            {
                dtos.Add(new HospitalDeptUnitDTO().getDTO(item));
            }
            dtos = dtos.OrderBy(p => p.SortIndex).ToList();
            return dtos;
        }

        public HospitalDeptUnit getDA()
        {
            return new HospitalDeptUnit
            {
                HospitalDeptUnitId = this.HospitalDeptUnitId,
                HospitalDeptUnitName = this.HospitalDeptUnitName,
                Inactive = this.Inactive,
                SortIndex = this.SortIndex
            };
        }

        public void setLinks(UrlHelper url)
        {
            var idObj = new { id = HospitalDeptUnitId };
            links.Add(new Link(url.Link("Get", idObj), "self", "GET"));
            links.Add(new Link(url.Link("Get", idObj), "Update-HospitalDeptUnit", "PUT"));
            links.Add(new Link(url.Link("Get", idObj), "delete-HospitalDeptUnit", "DELETE"));
        }


    }
}