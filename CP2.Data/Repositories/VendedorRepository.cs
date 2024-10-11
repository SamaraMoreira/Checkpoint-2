﻿using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;

namespace CP2.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public VendedorEntity DeletarDados(int id)
        {
            var entity = _context.Vendedor.Find(id);

            if (entity is not null)
            {
                _context.Vendedor.Remove(entity);
                _context.SaveChanges();

                return entity;
            }

            return null;
        }

        public VendedorEntity EditarDados(VendedorEntity entity)
        {
            var vendedor = _context.Vendedor.Find(entity.Id);

            if (vendedor is not null)
            {
                vendedor.Nome = entity.Nome;
                vendedor.Email = entity.Email;
                vendedor.Telefone = entity.Telefone;
                vendedor.DataNascimento = entity.DataNascimento;
                vendedor.ComissaoPercentual = entity.ComissaoPercentual;
                vendedor.Endereco = entity.Endereco;
                vendedor.DataContratacao = entity.DataContratacao;
                vendedor.MetaMensal = entity.MetaMensal;
                vendedor.CriadoEm = entity.CriadoEm;


                _context.Vendedor.Update(vendedor);
                _context.SaveChanges();

                return entity;
            }

            return null;
        }

        public VendedorEntity ObterPorId(int id)
        {
            var vendedor = _context.Vendedor.Find(id);

            if (vendedor is not null)
            {
                return vendedor;
            }

            return null;
        }

        public IEnumerable<VendedorEntity> ObterTodos()
        {
            var vendedores = _context.Vendedor.ToList();

            return vendedores;
        }

        public VendedorEntity SalvarDados(VendedorEntity entity)
        {
            _context.Vendedor.Add(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
