
using System.Collections.Generic;
using ProjetoDDD.Application.Interface;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Services;

namespace ProjetoDDD.Application
{
    public class ClienteAppService : AppServiceBase<Client>, IClientAppService
    {
        private readonly IClientService _clientService;

        public ClientAppService(IClientService clientService)
            : base(clientService)
        {
            _clientService = clientService;
        }

        public IEnumerable<Client> ObterClientsEspeciais()
        {
            return _clientService.ObterClientsEspeciais(_clientService.GetAll());
        }
    }
}
