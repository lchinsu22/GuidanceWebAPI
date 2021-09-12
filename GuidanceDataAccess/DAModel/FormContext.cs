using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using GuidanceDataAccess.DAModel.Form;

namespace GuidanceDataAccess.DAModel
{
    public class FormContext : GuidanceContext, IFormContext
    {
        //public List<PatientSearchResult> SearchPatient(PatientSearchFilter patientSearchFilter)
        //{
        //    try
        //    {
        //        List<PatientSearchResult> patientInfoes =
        //            (from apd in AFNAPSPatientDetails
        //             join ew in EntityWards on apd.EntityWardID equals ew.EntityWardID into EntityWardsjoin
        //             from ewj in EntityWardsjoin.DefaultIfEmpty()

        //             join hc in HealthCareEntities on apd.HealthCareEntityID equals hc.HealthCareEntityID into HealthCareEntitiesjoin
        //             from hcj in HealthCareEntitiesjoin.DefaultIfEmpty()

        //             join sp in Specialties on apd.SpecialtyID equals sp.SpecialtyID into Specialtiesjoin
        //             from spj in Specialtiesjoin.DefaultIfEmpty()

        //             where apd.HealthCareEntityID.Equals(patientSearchFilter.HealthCareFacilityId)
        //                   && (patientSearchFilter.SurveyId == null || apd.NamedSurveyID == patientSearchFilter.SurveyId)
        //                   && (patientSearchFilter.PatientIdentifyingNo == null || apd.MedicalRecordNumber.Equals(patientSearchFilter.PatientIdentifyingNo))
        //                   && (patientSearchFilter.GenderCode == null || apd.Gender.Equals(patientSearchFilter.GenderCode))
        //                   && (patientSearchFilter.WardId == null || apd.EntityWardID == patientSearchFilter.WardId)
        //                   && (patientSearchFilter.SpecialtyId == null || apd.SpecialtyID == patientSearchFilter.SpecialtyId)
        //                   && (patientSearchFilter.ShowCompleted == null
        //                      || ((patientSearchFilter.ShowCompleted == true && apd.CompletedDate != null) || (patientSearchFilter.ShowCompleted == false && apd.CompletedDate == null)))
        //                   && (patientSearchFilter.AuditDateFrom == null || apd.AuditDate >= patientSearchFilter.AuditDateFrom)
        //                   && (patientSearchFilter.AuditDateTo == null || apd.AuditDate <= patientSearchFilter.AuditDateTo)
        //                   && (patientSearchFilter.BirthDateFrom == null || apd.DateOfBirth >= patientSearchFilter.BirthDateFrom)
        //                   && (patientSearchFilter.BirthDateTo == null || apd.DateOfBirth >= patientSearchFilter.BirthDateTo)
        //             orderby apd.CreatedDate descending

        //             select new PatientSearchResult
        //             {
        //                 PatientId = apd.PatientID,
        //                 PatientIdentifyingNo = apd.MedicalRecordNumber,
        //                 NamedSurvey = apd.NamedSurvey,
        //                 AuditDate = apd.AuditDate,
        //                 IsCompleted = apd.CompletedDate != null ? true : false,
        //                 Specialty = spj,
        //                 HealthCareEntity = hcj,
        //                 EntityWard = ewj,
        //                 CreatedDate = apd.CreatedDate
        //             }).ToList();
        //        return patientInfoes;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public Patient SavePatient(Patient patient)
        {
            if (patient != null)
            {
                try
                {
                    Set<Patient>().AddOrUpdate(patient);
                    SaveChanges();
                    return patient;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return null;

        }

        public int DeletePatient(long Id)
        {
            try
            {
                Patient entity = Set<Patient>().Find(Id);
                Set<Patient>().Remove(entity);
                SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Patient FindPatient(long Id)
        {
            return Set<Patient>().Find(Id);
        }

    }
}

