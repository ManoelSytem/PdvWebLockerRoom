using Dominio;
using InfraEstrutura.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Servico
{
    public class MesaService : IDisposable
    {
        UnitOfWork _uow;
        public MesaService(UnitOfWork uow)
        {
            _uow = uow;
        }

        public MesaService()
        {
            _uow = new UnitOfWork();
        }
        public void Adicionar(Mesa mesa)
        {
            _uow.MesaRepository.Add(mesa);
            _uow.Commit();
        }

        public IEnumerable<Mesa> Listar()
        {
            return _uow.MesaRepository.Get();
        }


        public Mesa ObterMesaPorcodigo(int codigoMesa)
        {
            return _uow.MesaRepository.GetById(p => p.codigo == codigoMesa);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
    
}
