using Aplication.InterfaceNegocio;
using Aplication.Util;
using Dominio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Aplication.Negocio
{
    public class MesaNegocio : IMesaNegocio
    {

        public void VerificarMesaAberta(Mesa mesa)
        {
            if(mesa.status != StatusMesa.Aberto.Value)
                throw new Exception("Mesa se encontra fechada. Não é possivel adicionar consumo");
        }
    }
}
