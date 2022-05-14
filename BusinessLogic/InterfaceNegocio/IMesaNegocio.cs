using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.InterfaceNegocio
{
    public interface IMesaNegocio 
    {
        public void VerificarMesaAberta(Mesa mesa);
    }
}
