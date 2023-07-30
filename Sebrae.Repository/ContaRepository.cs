using Microsoft.EntityFrameworkCore;
using Sebrae.Domain.Entities;
using Sebrae.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sebrae.Repository
{
    public class ContaRepository: IContaRepository
    {
        private readonly ApplicationDbContext _context;
        public ContaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Conta> Consultar(int? id)
        {
            var _contas = await _context.Contas
                .FirstOrDefaultAsync(m => m.Id == id);

            return _contas;
        }
        public async Task Create(Conta contas)
        {
            _context.Add(contas);
            await _context.SaveChangesAsync();
        }     

        public async Task Edit(Conta _contas)
        {
            _context.Update(_contas);
            await _context.SaveChangesAsync();
        }        

        public async Task Delete(int id)
        {
            var _contas = await _context.Contas.FindAsync(id);
            _context.Contas.Remove(_contas);
            await _context.SaveChangesAsync();
        }       

        public async Task<IList<Conta>> ListContas()
        {
            var lista = await _context.Contas.ToListAsync();

            return lista;
        }
    }
}
