using Pharmix.Data.Entities.Context;
using Pharmix.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmix.Web.Finance.Services.Mappers
{
    public class LoanMapper
    {
        public static GridViewModel CreateGridViewModel()
        {
            var gridModel = new GridViewModel
            {
                GridName = "GridServiceResult",
                PagingRoute = "Loans",
                PagingAction = "search"
            };
            gridModel.AddColumn("Name", true, "Abbriviation");
            gridModel.AddColumn("Customer", true, "Abbriviation");
            gridModel.AddColumn("Actions");

            return gridModel;
        }

        public static GridRow BindGridData(Loan source)
        {
            var row = new GridRow { IdentityValue = source.Id };
            row.AddCell(source.Name);
            row.AddCell(source.Customer?.Name);
            row.AddActionIcon("fa fa-upload text-info", "Click Upload documents");
            row.AddActionIcon("fa fa-edit text-success", "Click to view/edit");
            row.AddActionIcon("fa fa-trash text-danger", "Click to delete");
            row.AddActionIcon("fa fa-file-pdf-o text-danger", "Click to download application");
            return row;
        }
    }
}
