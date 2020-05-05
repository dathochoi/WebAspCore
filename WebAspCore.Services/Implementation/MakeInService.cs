using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAspCore.Data.Context;
using WebAspCore.Data.Entities;
using WebAspCore.Services.Interfaces;
using WebAspCore.ViewModel.ViewModels.Products;

namespace WebAspCore.Services.Implementation
{
    public class MakeInService : IMakeInService
    {
        private readonly WebDbContext _context;
        public MakeInService(WebDbContext context)
        {
            _context = context;
        }
        public MakeIn Add(MakeInViewModel makeInVM)
        {
            var makeIn = new MakeIn();
            makeIn.Id = makeInVM.Id;
            makeIn.Name = makeInVM.Name;
            makeIn.CheckMenu = makeInVM.CheckMenu;
            _context.MakeIns.Add(makeIn);
            _context.SaveChanges();
            return makeIn;
        }

        public void Delete(int id)
        {
            var item = _context.MakeIns.Find(id);
            if(item ==null)
            {
                throw new Exception("Xuất xứ không tìm thấy");

            }
            _context.MakeIns.Remove(item);
            _context.SaveChanges();
        }

        public async Task<List<MakeInViewModel>> GetAll()
        {
            var list = await _context.MakeIns.ToListAsync();
            List<MakeInViewModel> listVM =  new List<MakeInViewModel>();
            if(list != null)
            {
                foreach( var item in list)
                {
                    var vm = new MakeInViewModel();
                    vm.Id = item.Id;
                    vm.Name = item.Name;
                    vm.CheckMenu = item.CheckMenu;
                    listVM.Add(vm);
                }
            }
            return listVM;
        }

        public List<MakeInViewModel> GetAll(string keyword)
        {
            throw new NotImplementedException();
        }

        public List<MakeInViewModel> GetAllByParentId(int parentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<MakeInViewModel>> GetAllVC()
        {
            throw new NotImplementedException();
        }

        public MakeInViewModel GetById(int id)
        {
            var item = _context.MakeIns.Find(id);
            if(item ==null)
            {
                throw new Exception("Không có xuất xứ nước này");
            }
            MakeInViewModel vm = new MakeInViewModel();
            vm.Id = item.Id;
            vm.Name = item.Name;
            vm.CheckMenu = item.CheckMenu;
            return vm;
        }

        public List<MakeInViewModel> GetHomeMakeIn(int top)
        {
            throw new NotImplementedException();
        }

        public void Update(MakeInViewModel makeInVM)
        {
            MakeIn item = new MakeIn();
            item.Id = makeInVM.Id;
            item.Name = makeInVM.Name;
            item.CheckMenu = makeInVM.CheckMenu;
            _context.MakeIns.Update(item);
            _context.SaveChanges();

        }
    }
}
