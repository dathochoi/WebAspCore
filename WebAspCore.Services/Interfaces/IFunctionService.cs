using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAspCore.ViewModel.ViewModels.Systems;

namespace WebAspCore.Services.Interfaces
{
    public interface IFunctionService
    {
        Task<List<FunctionViewModel>> GetAll();

        List<FunctionViewModel> GetAllByPermission(Guid userId);
    }
}
