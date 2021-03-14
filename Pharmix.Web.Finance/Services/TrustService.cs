using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmix.Data.Entities.Context;
using Pharmix.Web.Entities;
using Pharmix.Web.Entities.ViewModels;
using Pharmix.Web.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pharmix.Data.Entities.ViewModels;
using Pharmix.Web.Models;
using Pharmix.Web.Models.DepartmentViewModels;
using Pharmix.Web.Services.Mappers;
using X.PagedList;

namespace Pharmix.Web.Services
{
    public class TrustService: ITrustService
    {
        private readonly IRepository repository;
        private readonly PharmixEntityContext _context;


        public TrustService(IRepository repository)
        {
            this.repository = repository;
            _context = repository.GetContext();
        }

        public List<TrustViewModel> GetAllTrusts()
        {
            var trusts= repository.GetAll<Trust>().Where(e => !e.IsArchived).ToList();
            return AutoMapper.Mapper.Map<List<Trust>, List<TrustViewModel>>(trusts);
        }

        public Trust GetTrustById(int id)
        {
            return repository.GetById<Trust>(id);
        }

        public SelectList GetTrustSelectList(string selectedValue = "")
        {
            SelectList roles = null;
            var roleViewModelList = GetAllTrusts();
            if (roleViewModelList != null)
            {
                if (!string.IsNullOrEmpty(selectedValue))
                    roles = new SelectList(roleViewModelList, "Id", "Name", selectedValue);
                else
                    roles = new SelectList(roleViewModelList, "Id", "Name");
            }
            else
                roles = new SelectList(Enumerable.Empty<SelectListItem>());
            return roles;
        }

        public int GetTrustIdByUser(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var trustId=(from ut in _context.UserTrusts
                 join usr in _context.Users on ut.UserId equals usr.Id
                 where usr.UserName.Equals(userName)
                 select ut.TrustId).FirstOrDefault();
                return trustId;
            }
            else return 0;
        }

        public IEnumerable<Department> GetUserDepartments(string userId)
        {
            return _context.UserDepartments
                .Include(p => p.Department)
                .Where(p => p.ApplicationUserId == userId && !p.IsArchived && !p.Department.IsArchived).Select(p => p.Department);
        }

        #region Department

        public IEnumerable<Department> GetAllDepartmentsByTrustId(int trustId)
        {
            return repository.GetContext().Departments.Where(p => p.TrustId == trustId && !p.IsArchived);
        }

        public GridViewModel GetDepartmentSearchResult(SearchRequest request, int trustId)
        {
            var model = UserMapper.CreateDepartmentGridViewModel();

            var pageResult = QueryListHelper.SortResults(GetAllDepartmentsByTrustId(trustId), request);
            var serviceRows = pageResult
                .Where(p => string.IsNullOrEmpty(request.SearchText) || p.DepartmentName.StartsWith(request.SearchText, StringComparison.CurrentCultureIgnoreCase))
                .Select(UserMapper.BindDepartmentGridData);
            model.Rows = serviceRows.ToPagedList(request.Page ?? 1, request.PageSize);

            return model;
        }

        public DepartmentViewModel CreateDepartmentViewModel(int id)
        {
            var dept = repository.GetById<Department>(id);
            var model = dept == null ? new DepartmentViewModel() : Mapper.Map<Department, DepartmentViewModel>(dept);

            return model;
        }

        public int MapViewModelToDepartemnt(DepartmentViewModel model, string user)
        {
            var dept = repository.GetById<Department>(model.DepartmentId);

            dept = dept == null ? Mapper.Map<DepartmentViewModel, Department>(model) : Mapper.Map(model, dept);

            if (dept.DepartmentId > 0)
            {
                dept.SetUpdateDetails(user);
                repository.SaveExisting(dept);
            }
            else
            {
                dept.SetCreateDetails(user);
                repository.SaveNew(dept);
            }

            return dept.DepartmentId;
        }

        public BaseResultViewModel<string> ArchiveDepartment(int id, string user)
        {
            var hasActiveApts = repository.GetContext().PatientAppointments
                .Any(p => p.DepartmentId == id && !p.IsArchived);

            if (hasActiveApts)
                return new BaseResultViewModel<string>
                {
                    IsSuccess = false,
                    Message = "One or more Patient appointment(s) have been active in this department, It can not be deleted when there are active appointments."
                };

            var dept = repository.GetById<Department>(id);

            dept.SetArchiveDetails(user);
            repository.SaveExisting(dept);

            return new BaseResultViewModel<string>
            {
                IsSuccess = true,
                Message = "Department has been deleted successfully."
            }; ;
        }

        public bool CheckDuplicateDepartment(int id, string name, int trustId)
        {
           return repository.GetContext().Departments.Any(p =>
                p.TrustId == trustId && p.DepartmentName.Equals(name, StringComparison.InvariantCultureIgnoreCase) && p.DepartmentId != id);
        }

        #endregion
    }
}
