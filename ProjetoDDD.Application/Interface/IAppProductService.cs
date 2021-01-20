using System.Collections.Generic;
using ProjetoDDD.Domain.Entities;

namespace ProjetoDDD.Application.Interface
{
    public interface IProdutoAppService : IAppServiceBase<Product>
    {
        IEnumerable<Product> BuscarPorNome(string nome);
    }
}
