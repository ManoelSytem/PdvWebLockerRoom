using Dominio;
using InfraEstrutura.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Servico
{
    public class ConsumoService :IDisposable
    {
        UnitOfWork _uow;
        public ConsumoService(UnitOfWork uow)
        {
            _uow = uow;
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
