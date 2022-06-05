using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CleanArch.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetProducts();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Name, Description, Price")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var result = await _productService.GetById(id);
            if (result == null) return NotFound();
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id, Name, Description, Price")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Update(product);
                }
                catch(Exception)
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var result = await _productService.GetById(id);
            if (result == null) return NotFound();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var result = await _productService.GetById(id);
            if (result == null) return NotFound();
            return View(result);
        }
        [HttpPost(), ActionName("Delete")]
        public IActionResult DeleteConfirmed(ProductViewModel product)
        {
            _productService.Remove(product);
            return RedirectToAction("Index");
        }
    }
}
