using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Routing;
using GuidanceDataAccess.DAModel.MasterList;

namespace GuidanceWebAPI.DTOModel.MasterList
{

    public class DoctorDTO : IDTO<DoctorDTO, Doctor>
    {

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public bool Inactive { get; set; }
        public int SortIndex { get; set; }

        public List<Link> links { get; set; }



        public DoctorDTO getDTO(Doctor data)
        {
            if (data != null)
            {
                DoctorId = data.DoctorId;
                DoctorName = data.DoctorName;
                Inactive = data.Inactive;
                SortIndex = data.SortIndex;
                return this;
            }
            else
            {
                return null;
            }
        }

        public List<DoctorDTO> getDTOs(List<Doctor> list)
        {
            List<DoctorDTO> dtos = new List<DoctorDTO>();
            foreach (Doctor item in list)
            {
                dtos.Add(new DoctorDTO().getDTO(item));
            }
            dtos = dtos.OrderBy(p => p.SortIndex).ToList();
            return dtos;
        }

        public Doctor getDA()
        {
            return new Doctor
            {
                DoctorId = this.DoctorId,
                DoctorName = this.DoctorName,
                Inactive = this.Inactive,
                SortIndex = this.SortIndex
            };
        }

        public void setLinks(UrlHelper url)
        {
            var idObj = new { id = DoctorId };
            links.Add(new Link(url.Link("Get", idObj), "self", "GET"));
            links.Add(new Link(url.Link("Get", idObj), "Update-Doctor", "PUT"));
            links.Add(new Link(url.Link("Get", idObj), "delete-Doctor", "DELETE"));
        }


    }
}