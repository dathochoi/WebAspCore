using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAspCore.Data.Context;
using WebAspCore.Data.Entities;
using WebAspCore.Services.Interfaces;
using WebAspCore.ViewModel.ViewModels.Systems;

namespace WebAspCore.Services.Implementation
{
    public class FunctionService : IFunctionService
    {
        private readonly WebDbContext _context;
        private readonly IMapper _mapper;
        public FunctionService (WebDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<FunctionViewModel>> GetAll()
        {
            List<Function> items = await _context.Functions.ToListAsync();
            List<FunctionViewModel> listFunctionViewModel = new List<FunctionViewModel>();
          
            for (int i = 0; i < items.Count; i++)
            {
                //FunctionViewModel vm = new FunctionViewModel();
                //vm = _mapper.Map<FunctionViewModel>(items[i]);
                FunctionViewModel vm = new FunctionViewModel();
                vm.Name = items[i].Name;
                vm.Id = items[i].Id;
                vm.ParentId = items[i].ParentId;
                vm.URL = items[i].URL;
                vm.IconCss = items[i].IconCss;
                vm.SortOrder = items[i].SortOrder;
                vm.Status = items[i].Status;
                listFunctionViewModel.Add(vm);
            }
            return listFunctionViewModel;
        }

        public List<FunctionViewModel> GetAllByPermission(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
