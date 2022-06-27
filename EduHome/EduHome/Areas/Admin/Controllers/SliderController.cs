using Business.Services;
using DAL.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        public SliderController(ISliderService service)
        {
            _sliderService = service;
        }

        // GET: SliderController
        public async Task<ActionResult> Index()
        {
            List<Slider> datas = new List<Slider>();
            try
            {
                datas = await _sliderService.GetAll();
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 405,
                    message = ex.Message
                });
            }
            return View(datas);
        }

        // GET: SliderController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            Slider data = new Slider();
            try
            {
                data = await _sliderService.Get(id);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 405,
                    message = ex.Message
                });
            }
            return View(data);
        }

        // GET: SliderController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SliderCreate data)
        {
            Slider slider = new Slider()
            {
                Title = data.Title,
                Body = data.Body,
                ImageUrl = data.ImageUrl
            };

            try
            {
                await _sliderService.Create(slider);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 405,
                    message = ex.Message
                });
            }
        }

        // GET: SliderController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var data = await _sliderService.Get(id);
            return View(data);
        }

        // POST: SliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Slider data)
        {
            try
            {
                await _sliderService.Update(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 405,
                    message = ex.Message
                });
            }
        }

        // GET: SliderController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: SliderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                await _sliderService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 405,
                    message = ex.Message
                });
            }
        }
    }
}
