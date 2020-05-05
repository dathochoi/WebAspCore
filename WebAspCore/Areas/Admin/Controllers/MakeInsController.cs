using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAspCore.Services.Interfaces;
using WebAspCore.ViewModel.ViewModels.Products;

namespace WebAspCore.Areas.Admin.Controllers
{
    public class MakeInsController : AdminController
    {
        // GET: MakeIns
        private readonly IMakeInService _makeInService;
        public MakeInsController(IMakeInService makeInService)
        {
            _makeInService = makeInService;
        }
        public async Task<ActionResult> Index()
        {
            List<MakeInViewModel> listModel = await _makeInService.GetAll();
            return View(listModel);
        }

        // GET: MakeIns/Details/5
        //public ActionResult Details(int id)
        //{
        //    var item = _makeInService.GetById(id);
        //    return View(item);
        //}

        // GET: MakeIns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MakeIns/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MakeInViewModel vm)
        {
            try
            {
                //collection.
                // TODO: Add insert logic here
               _makeInService.Add(vm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MakeIns/Edit/5
        public ActionResult Edit(int id)
        {
            var item = _makeInService.GetById(id);
            return View(item);
        }

        // POST: MakeIns/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MakeInViewModel vm)
        {
            try
            {
                // TODO: Add update logic here
                _makeInService.Update(vm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MakeIns/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var item = _makeInService.GetById(id);
            return View(item);
        }

        // POST: MakeIns/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Deleted(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _makeInService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    
    }
}