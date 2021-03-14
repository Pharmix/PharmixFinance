using Pharmix.Data.Entities.Context;
using Pharmix.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Web.Finance.Services.Mappers
{
    public class CustomerMapper
    {
        public static GridViewModel CreateGridViewModel()
        {
            var gridModel = new GridViewModel
            {
                GridName = "GridServiceResult",
                PagingRoute = "Customers",
                PagingAction = "search"
            };
            gridModel.AddColumn("Name", true, "Name");
            gridModel.AddColumn("District", true, "District");
            gridModel.AddColumn("Town", true, "Town");
            gridModel.AddColumn("Loans", true, "Loans");
            gridModel.AddColumn("Actions");

            return gridModel;
        }

        public static GridRow BindGridData(Customer source)
        {
            var row = new GridRow { IdentityValue = source.Id };
            row.AddCell(source.Name);
            row.AddCell(source.District);
            row.AddCell(source.Town);
            row.AddCell(source.Loans?.Count().ToString());
            row.AddActionIcon("fa fa-eye text-success", "Click to View loans");
            row.AddActionIcon("fa fa-upload text-info", "Click Upload documents");
            row.AddActionIcon("fa fa-edit text-success", "Click to view/edit");
            row.AddActionIcon("fa fa-trash text-danger", "Click to delete");
            return row;
        }
    }
}
