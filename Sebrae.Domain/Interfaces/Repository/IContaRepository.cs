using Sebrae.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sebrae.Domain.Interfaces.Repository
{
    public interface IContaRepository
    {
        Task<Conta> Consultar(int? id);
        Task Create(Conta contas);
        Task Edit(Conta _contas);
        Task Delete(int id);
        Task<IList<Conta>> ListContas();
    }
}
