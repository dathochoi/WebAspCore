using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAspCore.Data.Entities;
using WebAspCore.ViewModel.ViewModels.Products;

namespace WebAspCore.Services.Interfaces
{
    public interface IMakeInService
    {
        MakeIn Add(MakeInViewModel makeInVM);

        void Update(MakeInViewModel makeInVM);

        void Delete(int id);

        Task<List<MakeInViewModel>> GetAll();

       // Task<List<MakeInViewModel>> GetAllVC();

        List<MakeInViewModel> GetAll(string keyword);

        List<MakeInViewModel> GetAllByParentId(int parentId);

        MakeInViewModel GetById(int id);

        List<MakeInViewModel> GetHomeMakeIn(int top);
    }
}
