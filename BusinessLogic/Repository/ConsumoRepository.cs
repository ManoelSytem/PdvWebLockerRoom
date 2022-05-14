using Aplication.Interface;
using Dominio;
using InfraEstrutura;
using InfraEstrutura.Interface;
using InfraEstrutura.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Aplication.Repository
{
    public class ConsumoRepository : IConsumoRepository
    {
        RepositoryGeneric<Consumo> _repositoryGeneric;
        AplicationDbContext _context;
        public ConsumoRepository()
        {
            _context = new AplicationDbContext();
            _repositoryGeneric = new RepositoryGeneric<Consumo>(_context);
        }

        public void Add(Consumo consumo)
        {
            _repositoryGeneric.Add(consumo);
        }
        
        public List<Produto> ObterListaDeProdutoPorConsumoMesa(string seqAbreMesa)
        {

            var listaProdutoConsumo = (from prod in _context.Produto
                                       join itemConsumo in _context.Consumo on prod.codigo 
                                       equals Convert.ToInt32(itemConsumo.codProduto) 
                                       where itemConsumo.seqAbreMesa == seqAbreMesa && itemConsumo.delete != "1"
                                       select prod).ToList();

            return listaProdutoConsumo;
        }

        public List<Consumo> ObterListarConsumoMesa(string seqAbreMesa)
        {
            var listaConsumo = (from Consumo in _context.Consumo
                                       where Consumo.seqAbreMesa == seqAbreMesa && Consumo.delete != "1" 
                                       && Consumo.status != "F"
                                       select Consumo).ToList();

            return listaConsumo;
        }

        public List<Consumo> ObterListarConsumoMesaFechamento(string seqAbreMesa)
        {
            var listaConsumo = (from Consumo in _context.Consumo
                                where Consumo.seqAbreMesa == seqAbreMesa && Consumo.delete != "1"
                                && Consumo.status == "F"
                                select Consumo).ToList();

            return listaConsumo;
        }


        public void DeleteProdutoConsumoMesa(string codigoItemConsumo)
        {
            (from consumo in _context.Consumo
             where consumo.codigo == Convert.ToInt32(codigoItemConsumo) && consumo.delete != "1"
             select consumo).ToList().ForEach(c => c.delete = "1");
            _context.SaveChanges();
        }

        public void Update(Consumo consumo)
        {
            _context.Consumo.Update(consumo);
            _context.SaveChanges();
        }
    }
}
