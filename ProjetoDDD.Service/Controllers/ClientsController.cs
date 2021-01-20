using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoDDD.Application.Interface;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.MVC.ViewModels;

namespace ProjetoDDD.service.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientAppService _clientApp;

        public ClientsController(IClientAppService clientApp)
        {
            _clientApp = clientApp;
        }

        
        public ActionResult Index()
        {
            var clientViewModel =
                Mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(_clientApp.GetAll());
            return View(clientViewModel);
        }

        public ActionResult Especiais()
        {
            var clientViewModel =
                Mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(_clientApp.ObterClientsEspeciais());

            return View(clientViewModel);
        }
        
        public ActionResult Details(int id)
        {
            var client = _clientApp.GetById(id);
            var clientViewModel = Mapper.Map<Client, ClientViewModel>(client);

            return View(clientViewModel);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                var clientDomain = Mapper.Map<ClientViewModel, Client>(client);
                _clientApp.Add(clientDomain);

                return RedirectToAction("Index");
            }

            return View(client);
        }

        
        public ActionResult Edit(int id)
        {
            var client = _clientApp.GetById(id);
            var clientViewModel = Mapper.Map<Client, ClientViewModel>(client);

            return View(clientViewModel);
        }

        
        [HttpPost]
        public ActionResult Edit(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                var clientDomain = Mapper.Map<ClientViewModel, Client>(client);
                _clientApp.Update(clientDomain);

                return RedirectToAction("Index");
            }

            return View(client);
        }

      
        public ActionResult Delete(int id)
        {
            var client = _clientApp.GetById(id);
            var clientViewModel = Mapper.Map<Client, ClientViewModel>(client);

            return View(clientViewModel);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var client = _clientApp.GetById(id);
            _clientApp.Remover(client);

            return RedirectToAction("Index");
        }
    }
}
