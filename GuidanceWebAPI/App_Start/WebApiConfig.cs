using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using GuidanceDataAccess.DAModel;
using GuidanceDataAccess.DAModel.MasterList;
using GuidanceWebAPI.App_Start;
using GuidanceWebAPI.DAService;
using GuidanceWebAPI.DAService.Entity_Framework;
using GuidanceWebAPI.DTOModel.MasterList;
using GuidanceWebAPI.DTOService;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Unity;
using Unity.Lifetime;

namespace GuidanceWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var container = new UnityContainer();

            //TO DO
            //httpactionresult return 
            //Mapper implementation
            //Patient Search Generalisation
            //Exception Handling
            //Routing - HATEOS
            //Concurency
            //security
            //content negotiation - optional
            //Open API and swagger - optional
            //In and oUt DTO - optional

            //Controller level dependency injection

            //Master List
            container.RegisterType<ICRUDDTOService<WardDTO, Ward>, CRUDDTOService<WardDTO, Ward>>(new HierarchicalLifetimeManager());
            container.RegisterType<ICRUDDTOService<GenderDTO, Gender>, CRUDDTOService<GenderDTO, Gender>>(new HierarchicalLifetimeManager());
            container.RegisterType<ICRUDDTOService<DoctorDTO, Doctor>, CRUDDTOService<DoctorDTO, Doctor>>(new HierarchicalLifetimeManager());
            container.RegisterType<ICRUDDTOService<HospitalDeptUnitDTO, HospitalDeptUnit>, CRUDDTOService<HospitalDeptUnitDTO, HospitalDeptUnit>>(new HierarchicalLifetimeManager());

            //Form
            container.RegisterType<IFormDTOService, FormDTOService>(new HierarchicalLifetimeManager());

            
            //DTO Service layer dependency injection
            container.RegisterType(typeof(ICRUDDAService<>), typeof(EFCRUDDAService<>), new HierarchicalLifetimeManager());
            container.RegisterType(typeof(IFormDAService), typeof(EFFormDAService), new HierarchicalLifetimeManager());

            //DA Service layer dependency injection
            container.RegisterType(typeof(ICRUDContext<>), typeof(CRUDContext<>), new HierarchicalLifetimeManager());
            container.RegisterType(typeof(IFormContext), typeof(FormContext), new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);


            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
