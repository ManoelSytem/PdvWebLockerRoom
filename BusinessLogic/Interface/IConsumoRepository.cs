using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Interface
{
    public interface IConsumoRepository
    {
        public void Add(Consumo consumo);
        public List<Produto> ObterListaDeProdutoPorConsumoMesa(string seqAbreMesa);
        public void DeleteProdutoConsumoMesa(string codigoItemConsumo);
        public List<Consumo> ObterListarConsumoMesa(string seqAbreMesa);
        public List<Consumo> ObterListarConsumoMesaFechamento(string seqAbreMesa);
        public void Update(Consumo consumo);
    }
}
