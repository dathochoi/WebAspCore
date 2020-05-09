using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WebAspCore.Data.Context;
using WebAspCore.Data.Entities;
using WebAspCore.Services.AutoMapper;
using WebAspCore.Services.Interfaces;
using WebAspCore.ViewModel.ViewModels.Systems;

namespace WebAspCore.Services.Implementation
{
    public class SystemsService : ISystemsService
    {
        private readonly WebDbContext _context;
        public SystemsService(WebDbContext context)
        {
            _context = context;
        }
        public async Task<ImageViewModel> GetImage()
        {
            var item = await _context.Systems.FirstAsync();
            ImageViewModel vm = new ImageViewModel();
            if (item != null)
            {
               
                vm.Logo = item.IconLogo;
                vm.Background = item.ImageCover;
            }
            return vm;
        }

        public async Task<NameWebSiteViewModel> GetNameWebSite()
        {
            var item = await _context.Systems.FirstAsync();
            NameWebSiteViewModel name = new NameWebSiteViewModel();
            name.Name = item.NameWebsite;
            name.Phone = item.PhongNumber;
            return name;
        }

        public ConntactViewModel GetContact()
        {
            var item =  _context.Systems.FirstOrDefault();
            ConntactViewModel vm = new ConntactViewModel();
            vm.Name = item.Name;
            
            vm.Address = item.Address;
            vm.Email = item.Email;
            vm.PhoneNumber = item.PhongNumber;
            vm.LinkFB = item.LinkFaceBook;
            vm.NameWebsite = item.NameWebsite;
          
            vm.Lag = item.Lng;
            vm.Lat = item.Lat;
            vm.Description = item.Descaription;

            return vm;

        }

        public async Task<SystemsViewModel> GetSystems()
        {
            var item = await _context.Systems.FirstAsync();
            var vm = MapperExtend.SystemsToVM(item);
            return vm;
        }

        public void UpdateSystem(SystemsViewModel systems)
        {
            var item = MapperExtend.VMToSystems(systems);
              _context.Systems.Update(item);
             _context.SaveChangesAsync();
        }
    }
}
