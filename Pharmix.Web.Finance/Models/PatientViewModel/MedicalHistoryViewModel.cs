using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Web.Models.PatientViewModel
{
    public class MedicalHistoryViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Admission to ITU/HDU")]
        public bool ITUorHDU { get; set; }

        [Display(Name = "Admission to A & E in last 12 month")]
        public bool AandE { get; set; }

        [Display(Name = "Anaesthetic Problem")]
        public bool AnaestheticProblem { get; set; }

        [Display(Name = "Allergies (inc. latex)")]
        public bool Allergies { get; set; }

        [Display(Name = "Asthma or chest problem")]
        public bool AsthmaChestProblem { get; set; }

        [Display(Name = "Autoimmune Disease")]
        public bool AutoimmuneDisease { get; set; }

        [Display(Name = "Back Problem")]
        public bool BackProblem { get; set; }

        [Display(Name = "Blood Clotting Disorder")]
        public bool BloodClottingDisorder { get; set; }

        [Display(Name = "Blood Transfution")]
        public bool BloodTransfution { get; set; }

        [Display(Name = "Cancer")]
        public bool Cancer { get; set; }

        [Display(Name = "Cervical Smear")]
        public bool CervicalSmear { get; set; }

        [Display(Name = "Diabetes")]
        public bool Diabetes { get; set; }

        [Display(Name = "Epilepsy / Neurogical Problem")]
        public bool EpilepsyNeurogicalProblem { get; set; }

        [Display(Name = "Exposure to Toxic Substance")]
        public bool ExposureToxicSubstance { get; set; }

        [Display(Name = "Fertility Problem (this pregnancy)")]
        public bool FertilityProblem { get; set; }

        [Display(Name = "Female Circumcision")]
        public bool FemaleCircumcision { get; set; }

        [Display(Name = "Gastro-Intestinal Problem (eg Crohns)")]
        public bool GastroIntestinalProblem { get; set; }

        [Display(Name = "Genetic Inherited Disorder")]
        public bool GeneticInheritedDisorder { get; set; }

        [Display(Name = "Genital Infection (e.g. Chlamydia, Herpes)")]
        public bool GenitalInfection { get; set; }

        [Display(Name = "Gynae History / Operations (excl. caesarean)")]
        public bool GynaeHistory { get; set; }

        [Display(Name = "Heart Problem")]
        public bool HeartProblem { get; set; }

        [Display(Name = "High Blood Preassure")]
        public bool HighBloodPreassure { get; set; }

        [Display(Name = "Incontinence (urinary/ faecal)")]
        public bool Incontinence { get; set; }

        [Display(Name = "Infection (e.g. MRSA, GBS)")]
        public bool Infection { get; set; }

        [Display(Name = "Kidney or Urinary Problem")]
        public bool KidneyUrinaryProblem { get; set; }

        [Display(Name = "Liver Diseas (inc. hepatitis)")]
        public bool LiverDiseas { get; set; }

        [Display(Name = "Migraine or Severe Headache")]
        public bool MigraineSevereHeadache { get; set; }

        [Display(Name = "Musculo-Skeletal Problem")]
        public bool MusculoSkeletalProblem { get; set; }

        [Display(Name = "Operations")]
        public bool Operations { get; set; }

        [Display(Name = "Pelvic Injury")]
        public bool PelvicInjury { get; set; }

        [Display(Name = "Sickle Cell / Thalassaemia")]
        public bool SickleCellThalassaemia { get; set; }

        [Display(Name = "TB Exposur")]
        public bool TBExposur { get; set; }

        [Display(Name = "Thrombosis")]
        public bool Thrombosis { get; set; }

        [Display(Name = "Thyroid / Other Endocrine Problem")]
        public bool ThyroidEndocrineProblem { get; set; }

        [Display(Name = "Medication in the last 6 months")]
        public bool MedicationLastSixMonth { get; set; }

        [Display(Name = "Vaginal bleeding in this pregnancy")]
        public bool VaginalBleeding { get; set; }

        [Display(Name = "Other (provide details)")]
        public bool Other { get; set; }

        [Display(Name = "Folic Acid Tablet")]
        public bool FolicAcidTablet { get; set; }

        [Display(Name = "Physical examination performed")]
        public bool PhysicalExamination { get; set; }
        
        public string ITUorHDUDetail { get; set; }

        public string AandEDetail { get; set; }

        public string AnaestheticProblemDetail { get; set; }

        public string AllergiesDetail { get; set; }

        [Display(Name = "Asthma")]
        public string AsthmaChestProblemDetail { get; set; }

        public string AutoimmuneDiseaseDetail { get; set; }

        public string BackProblemDetail { get; set; }

        public string BloodClottingDisorderDetail { get; set; }

        public string BloodTransfutionDetail { get; set; }

        public string CancerDetail { get; set; }

        [Display(Name = "Result")]
        public string CervicalSmearResult { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime? CervicalSmearDate { get; set; }

        public string DiabetesDetail { get; set; }

        [Display(Name = "On epilepsy medication?")]
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

        [Display(Name = "Hepatitis")]
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

        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        public DateTime? FolicAcidTabletDate { get; set; }

        public float? FolicAcidTabletDose { get; set; }

        [Display(Name = "Dose changed?")]
        public bool? FolicAcidTabletDoseChanged { get; set; }

        public string PhysicalExaminationDetail { get; set; }

        public int PregnancyId { get; set; }

        public bool IsAdmin { get; set; }

        public int PatientId { get; set; }
    }
}
