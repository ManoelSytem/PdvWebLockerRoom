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
            if(mesa.statusCaixa != StatusMesa.Aberto.Value)
                throw new Exception("Caixa se encontra fechado. Não é possivel adicionar produtos");
        }

        public void VerificarContaFechada(Conta conta)
        {
            if (conta.status == "P")
                throw new Exception($"Este pedido de número: {conta.seqAbreMesa} se encontra pedente de baixa. Não é possivel adicionar mais produtos, verifique em Financiero>Conta à Receber.");
        }
    }
}
