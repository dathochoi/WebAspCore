using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAspCore.Data.Context;
using WebAspCore.Data.Entities;
using WebAspCore.Services.Interfaces;
using WebAspCore.ViewModel.ViewModels.Account;

namespace WebAspCore.Services.Implementation
{
    public class UserService : IUserService
    {
        WebDbContext _context;
        public UserService(WebDbContext contex)
        {
            _context = contex;
        }
        public List<UserViewModel> getAllUser()
        {
            var list = _context.AppUsers.OrderByDescending(x => x.LockoutEnabled).ToList();
            List<UserViewModel> vmList = new List<UserViewModel>();
            foreach( var item in list)
            {
                UserViewModel vm = new UserViewModel();
                vm.FullName = item.FullName;
                vm.UserName = item.UserName;
                vm.IsClockOut = item.LockoutEnabled;
                vm.Status = item.Status;
                vmList.Add(vm);
            }
            return vmList;

        }

        public UserViewModel getById(string username)
        {
            var item = _context.AppUsers.Where(x => x.UserName == username).FirstOrDefault();
            UserViewModel vm = new UserViewModel();
            if (item !=null)
            {
                //UserViewModel vm = new UserViewModel();
                vm.FullName = item.FullName;
                vm.UserName = item.UserName;
                vm.IsClockOut = item.LockoutEnabled;
                vm.Status = item.Status;
            }
            return vm;
        }

        public void Update(UserViewModel vm)
        {
            var item = _context.AppUsers.Where(x=>x.UserName ==vm.UserName).FirstOrDefault();
            if (item !=null)
            {
                item.LockoutEnabled = vm.IsClockOut;
                _context.AppUsers.Update(item);
                _context.SaveChanges();
            }
        }
    }
}
