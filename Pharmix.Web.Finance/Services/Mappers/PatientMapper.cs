using Pharmix.Web.Models;
using Pharmix.Web.Entities;

namespace Pharmix.Web.Services.Mappers
{
    public class PatientMapper
    {
        public static GridViewModel CreateGridViewModel()
        {
            var gridModel = new GridViewModel
            {
                GridName = "divPatientGrid",
                PagingRoute = "Patient",
                PagingAction = "search"
            };
            gridModel.AddColumn("First Name", true, "FirstName");
            gridModel.AddColumn("Surname", true, "Surname");
            gridModel.AddColumn("Day of Birth", true, "DOB");
            gridModel.AddColumn("Gender", true, "Gender");
            gridModel.AddColumn("Email", true, "Email");
            gridModel.AddColumn("Phone", true, "Phone");
            gridModel.AddColumn("NHS Number", true, "NhsNumber");
            gridModel.AddColumn("PAS Number", true, "PasNumber");
            
            gridModel.AddColumn("Actions");
            return gridModel;
        }

        public static GridRow BindGridData(Patient source)
        {
            var row = new GridRow { IdentityValue = source.Id };
            row.AddCell(source.FirstName);
            row.AddCell(source.Surname);
            row.AddCell(source.DateOfBirth == null ? "N/A" : source.DateOfBirth.Value.ToString("dd/MM/yyyy"));
            row.AddCell(source.Gender == null ? "N/A" : source.Gender.Name);
            row.AddCell(source.EmailAddress);
            row.AddCell(source.MobileNumber);
            row.AddCell(source.NhsNumber);
            row.AddCell(source.PasNumber);

            row.AddActionIcon("fa fa-pencil-square text-priamry", "View/edit", "/patient/detail?patientid="+source.Id+"");

            return row;
        }
    }
}
