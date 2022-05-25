﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Interface;
using Aplication.Model;
using Aplication.Servico;
using Aplication.Util;
using Dominio;
using FoodServiceApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaixaController : ControllerBase
    {
        public readonly IContaRepository _ContaRepository;
        private readonly IJsonAutoMapper _JsonAutoMapper;
        private readonly ProdutoService _ProdutoService;
        private readonly IConsumoRepository _ConsumoRepository;

        public CaixaController(IContaRepository _contaRepository, IJsonAutoMapper _jsonAutoMapper,
             ProdutoService  produtoService, IConsumoRepository consumoRepository)
        {
            _ContaRepository = _contaRepository;
            _JsonAutoMapper = _jsonAutoMapper;
            _ProdutoService = produtoService;
            _ConsumoRepository = consumoRepository;
        }

        [Route("ObterContaPendente")]
        [HttpGet]
        public ContaModel ObterContaPendente(string seqAbreMesa)
        {
            var conta = _ContaRepository.ObterContaPendente(seqAbreMesa);
            var contaModel = _JsonAutoMapper.ConvertAutoMapperJson<ContaModel>(conta);
            return contaModel;
        }

        [Route("ObterListaDeContaPendente")]
        [HttpGet]
        public IEnumerable<string> ObterListaDeContaPendente(string seqAbreMesa)
        {
            return new string[] { "value1", "value2" };
        }

        [Route("ObterListaFormaPagamento")]
        [HttpGet]
        public IEnumerable<FormaPagamentoModel> ObterListaFormaPagamento()
        {
            var listaFormaPagamento = _ContaRepository.ObterListaFormaPagamento();
            var listaFormaPagamentoModel = _JsonAutoMapper.ConvertAutoMapperJson<List<FormaPagamentoModel>>(listaFormaPagamento);
            return listaFormaPagamentoModel;
        }

        [Route("BaixaConta")]
        [HttpPost]
        public ActionResultado BaixaConta(decimal valorEntrada, string formaPgto, int codigoConta)
        {
            try
            {
                var conta = _ContaRepository.ObterContaPorCondigo(codigoConta);
                conta.valorEntrada = valorEntrada;
                conta.formaPagamento = formaPgto;
                conta.dataBaixaConta = DateTime.Now;
                conta.status = "F";
                var listproduto = _ConsumoRepository.ObterListaDeProdutoPorConsumoMesa(conta.seqAbreMesa);
                foreach (var item in listproduto)
                {
                    _ProdutoService.RealizarBaixaEstoque(item.codigo);
                }

                _ContaRepository.Update(conta);

                return _JsonAutoMapper.Resposta("Baixa realizada com sucesso!");
            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }
        }
    }
}
