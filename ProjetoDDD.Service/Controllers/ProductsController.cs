using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoDDD.Application.Interface;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.MVC.ViewModels;

namespace ProjetoDDD.service.Controllers
{
    public class ProductsController : Controller
    {
       
        private readonly IProductAppService _productApp;
        private readonly IClientAppService _clientApp;

        public ProductsController(IProductAppService productApp, IClientAppService clientApp)
        {
            _productApp = productApp;
            _clientApp = clientApp;
        }

        
        public ActionResult Index()
        {
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(_productApp.GetAll());

            return View(productViewModel);
        }


        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(_clientApp.GetAll(), "ClientID", "Nome");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productDomain = Mapper.Map<ProductViewModel, Product>(product);
                _productApp.Add(productDomain);

                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(_clientApp.GetAll(), "ClientId", "Nome", product.ClientId);
            return View(product);
        }

        
        public ActionResult Edit(int id)
        {
            var product = _productApp.GetById(id);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(product);

            ViewBag.ClientId = new SelectList(_clientApp.GetAll(), "ClientId", "Nome", productViewModel.ClientId);
            
            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productDomain = Mapper.Map<ProductViewModel, Product>(product);
                    _productApp.Add(productDomain);
                
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(_clientApp.GetAll(), "ClientId", "Nome", product.ClientId);
            return View(product);
        }


       
        public ActionResult Delete(int id)
        {
            var product = _productApp.GetById(id);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(product);

            return View(productViewModel);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _productApp.GetById(id);
            _productApp.Remover(product);

            return RedirectToAction("Index");
        }
    }
}