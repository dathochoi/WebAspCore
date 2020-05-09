using System;
using System.Collections.Generic;
using System.Text;
using WebAspCore.Data.Enums;

namespace WebAspCore.ViewModel.ViewModels.Account
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public bool IsClockOut { get; set; }
        public string FullName { get; set; }
        public Status Status { get; set; }
    }
}
