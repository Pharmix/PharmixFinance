using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmix.Data.Entities.Context;
using Pharmix.Web.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmix.Data.Entities.ViewModels;
using Pharmix.Web.Entities;
using Pharmix.Web.Models;
using Pharmix.Web.Models.DepartmentViewModels;

namespace Pharmix.Web.Services
{
    public interface ITrustService
    {
        List<TrustViewModel> GetAllTrusts();
        Trust GetTrustById(int id);
        SelectList GetTrustSelectList(string selectedValue = "");
        int GetTrustIdByUser(string userName);
        IEnumerable<Department> GetUserDepartments(string userId);

        #region Department
        IEnumerable<Department> GetAllDepartmentsByTrustId(int trustId);
        GridViewModel GetDepartmentSearchResult(SearchRequest request, int trustId);
        DepartmentViewModel CreateDepartmentViewModel(int id);
        int MapViewModelToDepartemnt(DepartmentViewModel model, string user);
        BaseResultViewModel<string> ArchiveDepartment(int id, string user);
        bool CheckDuplicateDepartment(int id, string name, int trustId);

        #endregion
    }
}
