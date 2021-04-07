using Locadora.Domain.Entities;
using Locadora.Infra.Context;
using Locadora.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Repositories
{
    public class CarroRepository : BaseRepository<Carro>, ICarroRepository
    {
        private readonly LocadoraContext _context;

        public CarroRepository(LocadoraContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task Cancelar(long id)
        {
            var obj = await ObterPorId(id);

            if (obj != null)
            {
                var carro = _context.Carros.SingleOrDefault(x => x.Id == id);
                carro.Ativo = false;
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<Carro> ObterPorAno(int ano)
        {
            var anoCarro = await _context.Carros
                                   .Where
                                   (
                                        x =>
                                            x.Ano == ano
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();

            return anoCarro.FirstOrDefault();
        }

        public virtual async Task<Carro> ObterPorMarca(string marca)
        {
            var marcaCarro = await _context.Carros
                                   .Where
                                   (
                                        x =>
                                            x.Marca.ToLower() == marca.ToLower()
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();

            return marcaCarro.FirstOrDefault();
        }

        public virtual async Task<Carro> ObterPorModelo(string modelo)
        {
            var modeloCarro = await _context.Carros
                                   .Where
                                   (
                                        x =>
                                            x.Modelo.ToLower() == modelo.ToLower()
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();

            return modeloCarro.FirstOrDefault();
        }

        public virtual async Task<Carro> ObterPorPlaca(string placa)
        {
            var modeloCarro = await _context.Carros
                                   .Where
                                   (
                                        x =>
                                            x.Placa.ToLower() == placa.ToLower()
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();

            return modeloCarro.FirstOrDefault();
        }

        public virtual async Task<List<Carro>> PesquisarPorModelo(string modelo)
        {
            var modelos = await _context.Carros
                                   .Where
                                   (
                                        x =>
                                            x.Modelo.ToLower().Contains(modelo.ToLower())
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();

            return modelos;
        }
    }
}
