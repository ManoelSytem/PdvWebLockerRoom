using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Enum;
using Aplication.Interface;
using Aplication.InterfaceNegocio;
using Aplication.Model;
using Aplication.Repository;
using Aplication.Util;
using Dominio;
using FoodServiceApi.Model;
using Microsoft.AspNetCore.Mvc;


namespace FoodServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {

        private readonly IJsonAutoMapper _JsonAutoMapper;
        private readonly IMesaNegocio _IMesaNegocio;
        private readonly IConsumoRepository _ConsumoRepository;
        private readonly ProdutoRepository _ProdutoRepository;
        public readonly IContaRepository _ContaRepository;
        private readonly MesaRepository _MesaRepository;

        public MesaController(IJsonAutoMapper jsonAutoMapper, IMesaNegocio _imesaNegocio,
            IConsumoRepository IConsumoRepository, IContaRepository _contaRepository,
            MesaRepository mesaRepository, ProdutoRepository _produtoRepository)
        {
            _JsonAutoMapper = jsonAutoMapper;
            _MesaRepository = mesaRepository;
            _ConsumoRepository = IConsumoRepository;
            _IMesaNegocio = _imesaNegocio;
            _ContaRepository = _contaRepository;
            _ProdutoRepository = _produtoRepository;
        }

        [Route("Create")]
        [HttpPost]
        public ActionResultado Post(MesaModel mesaModel)
        {
            try
            {
                Mesa mesa = _JsonAutoMapper.ConvertAutoMapperJson<Mesa>(mesaModel);
                mesa.status = StatusMesa.Fechado.Value;
                _MesaRepository.Add(mesa);
                return _JsonAutoMapper.Resposta("Caixa criado com sucesso");
            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }
        }

        [Route("AbrirMesa")]
        [HttpPost]
        public ActionResultado AbrirMesa(int codMesa, int numeroMesa)
        {
            try
            {
                var mesa = _MesaRepository.GetbyId(codMesa);
                mesa.status = StatusMesa.Aberto.Value;
                mesa.seqAbreMesa = _MesaRepository.ObterUltimaSeqAbreMesa(codMesa, numeroMesa);
                mesa.statusCaixa = "A";
                _MesaRepository.update(mesa);
                var novaConta = new Conta()
                {
                    dataAbertura = DateTime.Now,
                    seqAbreMesa = mesa.seqAbreMesa,
                    numeroMesa = mesa.numero,
                    status = "A", //Mesa aberta,
                };
                _ContaRepository.Add(novaConta);
                return _JsonAutoMapper.Resposta("Caixa aberto com sucesso! Caixa disponível para venda.");
            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }
        }


        [Route("FechamentoMesa")]
        [HttpPost]
        public ActionResultado FechamentoMesa(int codMesa, string seqAbreMesa, decimal totalFechamento)
        {
            try
            {
                var contaPendente = _ContaRepository.ObterConta(seqAbreMesa);
                _IMesaNegocio.VerificarContaFechada(contaPendente);
                var mesa = _MesaRepository.GetbyId(codMesa);
                mesa.status = StatusMesa.Fechado.Value;
                var listConsumo = _ConsumoRepository.ObterListarConsumoMesa(seqAbreMesa);
                foreach (Consumo consumo in listConsumo)
                {
                    consumo.status = "F";
                    _ConsumoRepository.Update(consumo);
                }

                mesa.seqAbreMesa = _MesaRepository.NovaSeqCaixa();

                var conta = _ContaRepository.ObterConta(mesa.seqAbreMesa);

                if (conta == null)
                {
                    var novaConta = new Conta()
                    {
                        dataAbertura = DateTime.Now,
                        seqAbreMesa = mesa.seqAbreMesa,
                        numeroMesa = mesa.numero,
                        status = "A", //Conta aberta devido caixa se encontra aberto.
                    };
                    _ContaRepository.Add(novaConta);
                }

                _MesaRepository.update(mesa);

                var contaAberta = _ContaRepository.ObterConta(seqAbreMesa);
                contaAberta.status = "P"; //Pendente de pagamento e baixa no Finaceiro
                contaAberta.total = totalFechamento;
                contaAberta.dataFechamento = DateTime.Now;
                contaAberta.seqAbreMesa = seqAbreMesa;
                _ContaRepository.Update(contaAberta);

                return _JsonAutoMapper.Resposta("Venda realizada com sucesso! " + "\r\n" + " Realize a Baixa da Venda informando o número do Pedido : " + seqAbreMesa + ". " + "\r\n" + "Para gerar novamente cupom não fiscal, consulte no Modulo do Sistema em: Caixa>Cupom fiscal informado número do pedido.");
            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }
        }

        [HttpGet]
        [Route("ObterListaMesa")]
        public List<MesaModel> ObterListaMesa()
        {
            var listMesa = _MesaRepository.GetAll();
            var listaMesaModel = _JsonAutoMapper.ConvertAutoMapperListJson<MesaModel>(listMesa);
            return listaMesaModel;
        }

        [Route("AdicionaConsumoMesa")]
        [HttpPost]
        public ActionResultado AdicionaConsumoMesa(ConsumoModel consumoModel)
        {
            try
            {
                var mesa = _MesaRepository.GetbyId(Convert.ToInt32(consumoModel.codMesa));
                _IMesaNegocio.VerificarMesaAberta(mesa);

                Consumo consumo = _JsonAutoMapper.ConvertAutoMapperJson<Consumo>(consumoModel);
                consumo.horaPedido = DateTime.Now;
                consumo.seqAbreMesa = mesa.seqAbreMesa;

                _ConsumoRepository.Add(consumo);
                return _JsonAutoMapper.Resposta("Item produto adicionado com sucesso Caixa " + mesa.numero + ".");
            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }
        }

        [Route("AdicionaConsumoMesaPWA")]
        [HttpPost]
        public ActionResultado AdicionaConsumoMesaPWA(string codMesa, string codProduto)
        {
            try
            {
                var consumoModel = new ConsumoModel
                {
                    codMesa = codMesa,
                    codProduto = codProduto,
                    horaPedido = DateTime.Now,

                };
                var mesa = _MesaRepository.GetbyId(Convert.ToInt32(consumoModel.codMesa));
                _IMesaNegocio.VerificarMesaAberta(mesa);

                Consumo consumo = _JsonAutoMapper.ConvertAutoMapperJson<Consumo>(consumoModel);
                consumo.horaPedido = DateTime.Now;
                consumo.seqAbreMesa = mesa.seqAbreMesa;

                _ConsumoRepository.Add(consumo);
                return _JsonAutoMapper.Resposta("Item produto adicionado com sucesso Caixa " + mesa.numero + ".");
            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }
        }



        [Route("ObterConsumoDaMesa")]
        [HttpGet]
        public List<ConsumoModel> ObterConsumoDaMesa(string seqAbreMesa, bool EcupomFiscal)
        {
            List<Consumo> listConsumo;
            if (EcupomFiscal)
            { listConsumo = _ConsumoRepository.ObterListarConsumoMesaFechamento(seqAbreMesa); }
            else { listConsumo = _ConsumoRepository.ObterListarConsumoMesa(seqAbreMesa); }

            var listaConsumoModel = _JsonAutoMapper.ConvertAutoMapperListJson<ConsumoModel>(listConsumo);
            List<ConsumoModel> listConsumoProduto = new List<ConsumoModel>();
            foreach (ConsumoModel consumo in listaConsumoModel)
            {
                var produto = _ProdutoRepository.GetById(Convert.ToInt32(consumo.codProduto));
                consumo.produto = _JsonAutoMapper.ConvertAutoMapperJson<ProdutoModel>(produto);
                listConsumoProduto.Add(consumo);
            }

            return listConsumoProduto;
        }

        [Route("DeleteProdutoConsumoMesa")]
        [HttpDelete]
        public ActionResultado DeleteProdutoConsumoMesa(string codigoItemConsumo, int codMesa)
        {
            try
            {
                var mesa = _MesaRepository.GetbyId(codMesa);
                _ConsumoRepository.DeleteProdutoConsumoMesa(codigoItemConsumo);
                return _JsonAutoMapper.Resposta("Produto excluído do Caixa " + mesa.numero + ".");

            }
            catch (Exception ex)
            {
                return _JsonAutoMapper.Resposta("Falha!", ex);
            }

        }

        [HttpPost]
        [Route("Edit")]
        public ActionResultado Edit(Mesa mesaModel)
        {
            try
            {
                Mesa mesa = _JsonAutoMapper.ConvertAutoMapperJson<Mesa>(mesaModel);
                return _JsonAutoMapper.Resposta("Caixa alterado com sucesso!");
            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }

            return _JsonAutoMapper.Resposta("Contatar Administrador!");
        }

    }
}
