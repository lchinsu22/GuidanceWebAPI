using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;
using GuidanceDataAccess.DAModel.Form;

namespace GuidanceWebAPI.DTOModel.Form
{
    public class PatientDTO : IDTO<PatientDTO, Patient>
    {

        public long PatientID { get; set; }
        public string PatientName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public string City { get; set; }
        public int? PostalCode { get; set; }
        public int? WardId { get; set; }
        public string WardName { get; set; }
        public string Bed { get; set; }
        public int? HospitalDeptUnitId { get; set; }
        public string HospitalDeptUnitName { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? DischargedDate { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

        public List<Link> links { get; set; }



        public PatientDTO getDTO(Patient data)
        {
            if (data != null)
            {
                PatientID = data.PatientID;
                PatientName = data.PatientName;
                DateOfBirth = data.DateOfBirth;
                GenderId = data.GenderId;
                GenderName = data.Gender == null ? "" : data.Gender.GenderName;
                City = data.City;
                PostalCode = data.PostalCode;
                WardId = data.WardId;
                WardName = data.Ward == null ? "" : data.Ward.WardName;
                Bed = data.Bed;
                HospitalDeptUnitId = data.HospitalDeptUnitId;
                HospitalDeptUnitName = data.HospitalDeptUnit == null ? "" : data.HospitalDeptUnit.HospitalDeptUnitName;
                AdmissionDate = data.AdmissionDate;
                DischargedDate = data.DischargedDate;
                DoctorId = data.DoctorId;
                DoctorName = data.Doctor == null ? "" : data.Doctor.DoctorName;
                return this;
            }
            else
            {
                return null;
            }
        }

        public List<PatientDTO> getDTOs(List<Patient> list)
        {
            List<PatientDTO> dtos = new List<PatientDTO>();
            foreach (Patient item in list)
            {
                dtos.Add(new PatientDTO().getDTO(item));
            }
            dtos = dtos.OrderBy(p => p.PatientName).ToList();
            return dtos;
        }

        public Patient getDA()
        {
            return new Patient
            {
                PatientID = this.PatientID,
                PatientName = this.PatientName,
                DateOfBirth = this.DateOfBirth,
                GenderId = this.GenderId,
                City = this.City,
                PostalCode = this.PostalCode,
                WardId = this.WardId,
                Bed = this.Bed,
                HospitalDeptUnitId = this.HospitalDeptUnitId,
                AdmissionDate = this.AdmissionDate,
                DischargedDate = this.DischargedDate,
                DoctorId = this.DoctorId
            };
        }

        public void setLinks(UrlHelper url)
        {
            var idObj = new { id = PatientID };
            links.Add(new Link(url.Link("Get", idObj), "self", "GET"));
            links.Add(new Link(url.Link("Get", idObj), "Update-Patient", "PUT"));
            links.Add(new Link(url.Link("Get", idObj), "delete-Patient", "DELETE"));
        }
    }
}