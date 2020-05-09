using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAspCore.Data.Entities;
using WebAspCore.ViewModel.ViewModels.Systems;

namespace WebAspCore.Services.Interfaces
{
    public interface ISystemsService
    {
        public Task<ImageViewModel> GetImage();
        public Task<NameWebSiteViewModel> GetNameWebSite();
        public ConntactViewModel GetContact();
        public Task<SystemsViewModel> GetSystems();
        public void UpdateSystem(SystemsViewModel systems);
    }
}
