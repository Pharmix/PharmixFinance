using Pharmix.Data.Entities.Context;
using Pharmix.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Web.Entities
{
    [Table("Pregnancy", Schema = "PREG")]
    public class Pregnancy : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(25)]
        public string NHSNumber { get; set; }

        [MaxLength(25)]
        public string MaternityUnit { get; set; }

        public DateTime? EDD { get; set; }

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

    }

    [Table("CommunicationNeed", Schema = "PREG")]
    public class CommunicationNeed : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool AssistanceRequired { get; set; }

        public string AssistanceRequiredDetail { get; set; }

        public string PreferredAssistance { get; set; }

        public bool SpeakEnglish { get; set; }

        public string FirstLanguage { get; set; }

        public string PreferedLanguage { get; set; }

        public string InterpreterPhone { get; set; }

        public int PregnancyId { get; set; }
        [ForeignKey("PregnancyId")]
        public virtual Pregnancy Pregnancy { get; set; }
    }

    [Table("PlanOfCare", Schema = "PREG")]
    public class PlanOfCare : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PlannedPlaceOfBirth { get; set; }

        public string LeadProfessional { get; set; }

        public string JobTitle { get; set; }

        public string ReasonIfChanged { get; set; }

        public int PregnancyId { get; set; }
        [ForeignKey("PregnancyId")]
        public virtual Pregnancy Pregnancy { get; set; }
    }

    [Table("MaternityContact", Schema = "PREG")]
    public class MaternityContact : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Midwife { get; set; }

        public string MidwifePhone { get; set; }

        public string MaternityUnit { get; set; }

        public string MaternityUnitPhone { get; set; }

        public string AntenatalClinicPhone { get; set; }

        public string CommunityOfficePhone { get; set; }

        public string DeliverySuitePhone { get; set; }

        public string AmbulancePhone { get; set; }

        public int PregnancyId { get; set; }
        [ForeignKey("PregnancyId")]
        public virtual Pregnancy Pregnancy { get; set; }
    }

    [Table("PrimaryCareContact", Schema = "PREG")]
    public class PrimaryCareContact : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Centre { get; set; }

        public string GPInitial { get; set; }

        public string GPSurname { get; set; }

        public string GPPostcode { get; set; }

        public string HealtVisitor { get; set; }

        public string PhoneNumber1 { get; set; }

        public string PhoneNumber2 { get; set; }

        public string PhoneNumber3 { get; set; }

        public string PhoneNumber4 { get; set; }

        public int PregnancyId { get; set; }
        [ForeignKey("PregnancyId")]
        public virtual Pregnancy Pregnancy { get; set; }
    }

    [Table("NextOfKin", Schema = "PREG")]
    public class NextOfKin : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Relation { get; set; }

        public int PregnancyId { get; set; }
        [ForeignKey("PregnancyId")]
        public virtual Pregnancy Pregnancy { get; set; }
    }

    [Table("EmergencyContact", Schema = "PREG")]
    public class EmergencyContact : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber1 { get; set; }

        public string PhoneNumber2 { get; set; }

        public int PregnancyId { get; set; }
        [ForeignKey("PregnancyId")]
        public virtual Pregnancy Pregnancy { get; set; }
    }

    [Table("YourDetail", Schema = "PREG")]
    public class YourDetail : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public MarriageStatusEnum? MarriageStatus { get; set; }

        public string FamilyName { get; set; }

        public string CountryOfBirth { get; set; }

        public int? YearOfEntry { get; set; }

        public string Faith { get; set; }

        public string CitizenshipStatus { get; set; }

        public bool Disability { get; set; }

        public string Details { get; set; }

        public int PregnancyId { get; set; }
        [ForeignKey("PregnancyId")]
        public virtual Pregnancy Pregnancy { get; set; }
    }

    [Table("PartnerDetail", Schema = "PREG")]
    public class PartnerDetail : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public string Postcode { get; set; }

        public DateTime? DOB { get; set; }

        public string PhoneNumber { get; set; }

        public bool Employed { get; set; }

        public string Occupation { get; set; }

        public string UKCitizenshipStatus { get; set; }

        public int? YearOfEntry { get; set; }

        public int PregnancyId { get; set; }
        [ForeignKey("PregnancyId")]
        public virtual Pregnancy Pregnancy { get; set; }
    }

    [Table("EthnicOrigin", Schema = "PREG")]
    public class EthnicOrigin : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public EthnicOriginOwnEnum? NorthAfrica { get; set; }

        public EthnicOriginOwnEnum? SubSahara { get; set; }

        public EthnicOriginOwnEnum? Bangladesh { get; set; }

        public EthnicOriginOwnEnum? India { get; set; }

        public EthnicOriginOwnEnum? Pakistan { get; set; }
        
        public EthnicOriginOwnEnum? FarEastAsia { get; set; }

        public EthnicOriginOwnEnum? SouthEastAsia { get; set; }

        public EthnicOriginOwnEnum? Caribean { get; set; }

        public EthnicOriginOwnEnum? European { get; set; }

        public EthnicOriginOwnEnum? MidleEast { get; set; }

        public string OtherYou { get; set; }

        public string OtherBabysFather { get; set; }
        
        public int PregnancyId { get; set; }
        [ForeignKey("PregnancyId")]
        public virtual Pregnancy Pregnancy { get; set; }
    }

    [Table("MedicalHistory", Schema = "PREG")]
    public class MedicalHistory : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool ITUorHDU { get; set; }

        public bool AandE { get; set; }

        public bool AnaestheticProblem { get; set; }

        public bool Allergies { get; set; }

        public bool AsthmaChestProblem { get; set; }

        public bool AutoimmuneDisease { get; set; }

        public bool BackProblem { get; set; }

        public bool BloodClottingDisorder { get; set; }

        public bool BloodTransfution { get; set; }

        public bool Cancer { get; set; }

        public bool CervicalSmear { get; set; }

        public bool Diabetes { get; set; }

        public bool EpilepsyNeurogicalProblem { get; set; }

        public bool ExposureToxicSubstance { get; set; }

        public bool FertilityProblem { get; set; }

        public bool FemaleCircumcision { get; set; }

        public bool GastroIntestinalProblem { get; set; }

        public bool GeneticInheritedDisorder { get; set; }

        public bool GenitalInfection { get; set; }

        public bool GynaeHistory { get; set; }

        public bool HeartProblem { get; set; }

        public bool HighBloodPreassure { get; set; }

        public bool Incontinence { get; set; }

        public bool Infection { get; set; }

        public bool KidneyUrinaryProblem { get; set; }

        public bool LiverDiseas { get; set; }

        public bool MigraineSevereHeadache { get; set; }

        public bool MusculoSkeletalProblem { get; set; }

        public bool Operations { get; set; }

        public bool PelvicInjury { get; set; }

        public bool SickleCellThalassaemia { get; set; }

        public bool TBExposur { get; set; }

        public bool Thrombosis { get; set; }

        public bool ThyroidEndocrineProblem { get; set; }

        public bool MedicationLastSixMonth { get; set; }

        public bool VaginalBleeding { get; set; }

        public bool Other { get; set; }

        public bool FolicAcidTablet { get; set; }

        public bool PhysicalExamination { get; set; }

        public string ITUorHDUDetail { get; set; }

        public string AandEDetail { get; set; }

        public string AnaestheticProblemDetail { get; set; }

        public string AllergiesDetail { get; set; }

        public string AsthmaChestProblemDetail { get; set; }

        public string AutoimmuneDiseaseDetail { get; set; }

        public string BackProblemDetail { get; set; }

        public string BloodClottingDisorderDetail { get; set; }

        public string BloodTransfutionDetail { get; set; }

        public string CancerDetail { get; set; }

        public string CervicalSmearResult { get; set; }

        public DateTime? CervicalSmearDate { get; set; }

        public string DiabetesDetail { get; set; }

        public bool OnEpilepsyNeurogicalProblemMedication { get; set; }

        public string ExposureToxicSubstanceDetail { get; set; }

        public string FertilityProblemDetail { get; set; }

        public string FemaleCIrcumcisionDetail { get; set; }

        public string GastroIntestinalProblemDetail { get; set; }

        public string GeneticInheritedDisorderDetail { get; set; }

        public string GenitalInfectionDetail { get; set; }

        public string GynaeHistoryDetail { get; set; }

        public string HeartProblemDetail { get; set; }

        public string HighBloodPreassureDetail { get; set; }

        public string IncontinenceDetail { get; set; }

        public string InfectionDetail { get; set; }

        public string KidneyUrinaryProblemDetail { get; set; }
        
        [MaxLength(1)]
        public string LiverDiseasLevel { get; set; }

        public string MigraineSevereHeadacheDetail { get; set; }

        public string MusculoSkeletalProblemDetail { get; set; }

        public string OperationsDetail { get; set; }

        public string PelvicInjuryDetail { get; set; }

        public string SickleCellThalassaemiaDetail { get; set; }

        public string TBExposurDetail { get; set; }

        public string ThrombosisDetail { get; set; }

        public string ThyroidEndocrineProblemDetail { get; set; }

        public string MedicationLastSixMonthDetail { get; set; }

        public string VaginalBleedingDetail { get; set; }

        public string OtherDetail { get; set; }

        public DateTime? FolicAcidTabletDate { get; set; }
        
        public float FolicAcidTabletDose { get; set; }

        public bool? FolicAcidTabletDoseChanged { get; set; }

        public string PhysicalExaminationDetail { get; set; }
        
        public int PregnancyId { get; set; }
        [ForeignKey("PregnancyId")]
        public virtual Pregnancy Pregnancy { get; set; }
    }

    [Table("MentalHealth", Schema = "PREG")]
    public class MentalHealth : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool MentalIllness { get; set; }

        public bool PreviousTreatment { get; set; }

        public bool FamilyHistory { get; set; }

        public bool PartnerHasHistory { get; set; }

        public bool Depressed1st { get; set; }

        public bool Depressed2nd { get; set; }

        public bool Interest1st { get; set; }

        public bool Interest2nd { get; set; }

        public bool Anxious1st { get; set; }

        public bool Anxious2nd { get; set; }

        public bool NeedSomething1st { get; set; }

        public bool NeedSomething2nd { get; set; }

        public bool RefferalRequired1st { get; set; }

        public bool RefferalRequired2nd { get; set; }

        public string Detail { get; set; }

        public int PregnancyId { get; set; }
        [ForeignKey("PregnancyId")]
        public virtual Pregnancy Pregnancy { get; set; }
    }
}
