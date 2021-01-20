
using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repositories;
using ProjetoDDD.Domain.Interfaces.Services;

namespace ProjetoDDD.Domain.Services
{
    public class ClientService : ServiceBase<Client>, IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
            : base(clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IEnumerable<Client> BuscarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> ObterClientsEspeciais(IEnumerable<Client> clients)
        {
            return clients.Where(c => c.ClientEspecial(c));
        }
    }
}
