using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Model;
using Aplication.Negocio;
using Aplication.Repository;
using Aplication.Servico;
using Aplication.Util;
using Dominio;
using FoodServiceApi.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IJsonAutoMapper _JsonAutoMapper;
        private readonly ProdutoService _ProdutoService;
        private readonly ProdutoItemRepository _ProdutoItemRepository;
        private readonly ProdutoRepository _ProdutoRepository;

        public ProdutoController(IJsonAutoMapper JsonAutoMapper)
        {
            _JsonAutoMapper = JsonAutoMapper;
            _ProdutoService = new ProdutoService();
            _ProdutoItemRepository = new ProdutoItemRepository();
            _ProdutoRepository = new ProdutoRepository();
        }
        // GET: api/<ProdutoController>
        [HttpGet]
        [Route("GetListProduto")]
        public List<ProdutoModel> Get(string cliente)
        {
           var listProduto =  _ProdutoService.Listar(cliente);
           var listProdutoModel = _JsonAutoMapper.ConvertAutoMapperListJson<ProdutoModel>(listProduto);
           return listProdutoModel;
        }

        [HttpPost]
        [Route("GetListProdutoPorListaProduto")]
        public List<ProdutoModel> GetListProdutoPorListProduto(List<int> listProduto)
        {
            var listProdutos = _ProdutoService.ObterListaProdutoPorIdProduto(listProduto);
            var listProdutoModel = _JsonAutoMapper.ConvertAutoMapperListJson<ProdutoModel>(listProdutos);
            return listProdutoModel;
        }

        // GET api/<ProdutoController>/5
        [HttpGet]
        [Route("ObterProduto")]
        public ProdutoModel Get(int id)
        {
            var produto = _ProdutoService.ObterProdutoPorId(id);
            var produtoModel = _JsonAutoMapper.ConvertAutoMapperJson<ProdutoModel>(produto);
            return produtoModel;
        }

        [HttpGet]
        [Route("VerificaProdutoEmMenu")]
        public ActionResultado VerificaProdutoEmMenu(int id, string cliente)
        {
            try
            {
                ProdutoNegocio produtoNegocio = new ProdutoNegocio();
                var listaItemProduto = _ProdutoItemRepository.ObterProdutoClienteAssociadoCardapio(id, cliente);
                var result = produtoNegocio.VerificaSeProdutoExisteMenu(listaItemProduto);
                return _JsonAutoMapper.Resposta(result);
            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }

            return _JsonAutoMapper.Resposta("Contatar Administrador!");
         
        }

        [HttpDelete]
        [Route("DeleteProdutoCliente")]
        public ActionResultado DeleteProdutoCliente(int id, string cliente)
        {
            try
            {
                ProdutoNegocio produtoNegocio = new ProdutoNegocio();
                var listaItemProduto = _ProdutoItemRepository.ObterProdutoClienteAssociadoCardapio(id, cliente);
                _ProdutoRepository.DeleteProdutoPorCliente(id, cliente);
                var listaMenuItemProduto = _ProdutoItemRepository.ObterProdutoClienteAssociadoCardapio(id, cliente);
                _ProdutoItemRepository.DeleteProdutoAssociadoALista(listaMenuItemProduto);
                return _JsonAutoMapper.Resposta("Produto excluído com sucesso!");
            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }

            return _JsonAutoMapper.Resposta("Contatar Administrador!");

        }

        // POST api/<ProdutoController>
        [HttpPost]
        [Route("Create")]
        public ActionResultado Post(ProdutoModel produtoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                     Produto produto = _JsonAutoMapper.ConvertAutoMapperJson<Produto>(produtoModel);
                    _ProdutoService.Adicionar(produto);
                    return _JsonAutoMapper.Resposta("Produto criado com sucesso!");
                }
            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }

            return _JsonAutoMapper.Resposta("Contatar Administrador!");
        }

        [HttpPost]
        [Route("Edit")]
        public ActionResultado Edit(int codProdutoAnterior, ProdutoModel produtoModel)
        {
            try
            {
                    Produto produto = _JsonAutoMapper.ConvertAutoMapperJson<Produto>(produtoModel);
                   _ProdutoRepository.AtualizarProduto(codProdutoAnterior, produto);
                    return _JsonAutoMapper.Resposta("Produto alterado com sucesso!");
            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }

            return _JsonAutoMapper.Resposta("Contatar Administrador!");
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
