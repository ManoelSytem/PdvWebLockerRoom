using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Interface
{
    public interface IContaRepository
    {
        public void Add(Conta conta);
        public Conta ObterContaPendente(string seqAbreMesa);
        public IEnumerable<FormaPagamento> ObterListaFormaPagamento();
        public Conta ObterContaAberta(string seqAbreMesa);
        public void Update(Conta conta);
        public Conta ObterContaPorCondigo(int codigo);
        public Conta ObterConta(string seqAbreMesa);
    }
}
