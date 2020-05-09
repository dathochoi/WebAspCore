using System;
using System.Collections.Generic;
using System.Text;
using WebAspCore.Data.Entities;
using WebAspCore.ViewModel.ViewModels.Account;

namespace WebAspCore.Services.Interfaces
{
    public interface IUserService
    {
        public List<UserViewModel> getAllUser();
        public void Update(UserViewModel vms);
        public UserViewModel getById(string username);

    }
}
