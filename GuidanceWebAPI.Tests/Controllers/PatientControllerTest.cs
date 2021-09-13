using GuidanceDataAccess.DAModel.Form;
using GuidanceWebAPI.Controllers.Form;
using GuidanceWebAPI.DAService.Entity_Framework;
using GuidanceWebAPI.DTOModel.Form;
using GuidanceWebAPI.DTOService;
using GuidanceWebAPI.Tests.TestContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace GuidanceWebAPI.Tests.Controllers
{
    [TestClass]
    public class PatientControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void PostPatient_ShouldReturnSamePatient()
        {
            var controller = new PatientController(new FormDTOService(new EFFormDAService(new TestPatientContext())));

            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost/api/Patient")
            };
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
                name: "AddPatient",
                routeTemplate: "api/Patient",
                defaults: new { id = RouteParameter.Optional });

            PatientDTO item = GetDemoPatient();

            var result =
                controller.AddPatient(item) as OkNegotiatedContentResult<PatientDTO>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.PatientName, item.PatientName);
        }

        //[TestMethod]
        //public void PutPatient_ShouldReturnModifiedData()
        //{
        //    var controller = new PatientController(new FormDTOService(new EFFormDAService(getPatientContext())));
        //    controller.Request = new HttpRequestMessage
        //    {
        //        RequestUri = new Uri("http://localhost/api/Patient")
        //    };
        //    controller.Configuration = new HttpConfiguration();
        //    controller.Configuration.Routes.MapHttpRoute(
        //        name: "AddPatient",
        //        routeTemplate: "api/Patient",
        //        defaults: new { id = RouteParameter.Optional });

        //    var item = GetDemoPatient();

        //    var result = controller.AddPatient(item) as IHttpActionResult;
        //    Assert.IsNotNull(result);
        //    Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        //}


        [TestMethod]
        public void GetPatient_ShouldReturnPatientWithSameID()
        {


            var controller = new PatientController(new FormDTOService(new EFFormDAService(getPatientContext())));
            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost/api/Patient/{id}")
            };
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
                name: "FindPatient",
                routeTemplate: "api/Patient/{id}",
                defaults: new { id = RouteParameter.Optional });

            var result = controller.FindPatient(3) as OkNegotiatedContentResult<PatientDTO>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.PatientID);
        }

        [TestMethod]
        public void GetPatients_ShouldReturnAllPatients()
        {
            var controller = new PatientController(new FormDTOService(new EFFormDAService(getPatientContext())));

            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost/api/Patient")
            };
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
                name: "GetAllPatient",
                routeTemplate: "api/Patient",
                defaults: new { id = RouteParameter.Optional });

            var result = controller.GetAllPatient() as OkNegotiatedContentResult<List<PatientDTO>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Count());
        }

        [TestMethod]
        public void DeleteProduct_ShouldReturnOK()
        {
            var controller = new PatientController(new FormDTOService(new EFFormDAService(getPatientContext())));
            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost/api/Patient/{id}")
            };
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
                name: "Delete",
                routeTemplate: "api/Patient/{id}",
                defaults: new { id = RouteParameter.Optional });

            var result = controller.Delete(3);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);

            result = controller.Delete(4);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);
        }

        PatientDTO GetDemoPatient()
        {

            return new PatientDTO() {
                PatientName = "Patient99",
                DateOfBirth = new DateTime(1988, 11, 22),
                WardId = 3,
                HospitalDeptUnitId = 2,
                DoctorId = 4,
                GenderId = 2,
                City = "Melbounre",
                AdmissionDate = new DateTime()

            };
        }

        PatientDTO GetDemoPutPatient()
        {

            return new PatientDTO()
            {
                PatientID = 1,
                PatientName = "PatientChanged",
                DateOfBirth = new DateTime(1972, 10, 2),
                WardId = 1,
                HospitalDeptUnitId = 4,
                DoctorId = 3,
                GenderId = 1,
                City = "Melbounre",
                AdmissionDate = new DateTime(2021, 9, 1)

            };
        }

        TestPatientContext getPatientContext()
        {
            var context = new TestPatientContext();
            List<Patient> patients = new List<Patient>();
            context.patients.Add(new Patient()
            {
                PatientID = 1,
                PatientName = "Patient1",
                DateOfBirth = new DateTime(1972, 10, 2),
                WardId = 1,
                HospitalDeptUnitId = 4,
                DoctorId = 3,
                GenderId = 1,
                City = "Melbounre",
                AdmissionDate = new DateTime(2021, 9, 1)

            });
            context.patients.Add(new Patient()
            {
                PatientID = 2,
                PatientName = "Patient2",
                DateOfBirth = new DateTime(2000, 1, 5),
                WardId = 5,
                HospitalDeptUnitId = 3,
                DoctorId = 7,
                GenderId = 2,
                City = "Sydney",
                AdmissionDate = new DateTime()

            });
            context.patients.Add(new Patient()
            {
                PatientID = 3,
                PatientName = "Patient3",
                DateOfBirth = new DateTime(2004, 5, 16),
                WardId = 2,
                HospitalDeptUnitId = 8,
                DoctorId = 10,
                GenderId = 3,
                City = "Melbounre",
                AdmissionDate = new DateTime(2021,1,1)

            });
            return context;
        }
    }
}
