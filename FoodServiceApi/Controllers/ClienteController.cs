using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Enum;
using Aplication.Interface;
using Aplication.Model;
using Aplication.Util;
using BusinessLogic.Servico;
using Dominio;
using FoodServiceApi.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IJsonAutoMapper _JsonAutoMapper;
        private readonly IClienteService _ClienteService;
        public ClienteController(IJsonAutoMapper jsonAutoMapper, IClienteService _clienteService)
        {
            _JsonAutoMapper = jsonAutoMapper;
            _ClienteService = _clienteService;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClienteController>
        [Route("Create")]
        [HttpPost]
        public ActionResultado Post(ClienteModel clienteModel)
        {
            try
            {
                Cliente Cliente = _JsonAutoMapper.ConvertAutoMapperJson<Cliente>(clienteModel);
                Cliente.dataEntrada = DateTime.Now;
                Cliente.dataUpdate = DateTime.Now;
                Cliente.status = Status.Ativado.ToDescriptionString();
                _ClienteService.Adicionar(Cliente);
                return _JsonAutoMapper.Resposta("Dados atualizado com sucesso");
            }
            catch (Exception e)
            {
                return _JsonAutoMapper.Resposta("Falha!", e);
            }
        }

        [Route("ObterClientePorEmail")]
        [HttpGet]
        public ClienteModel ObterClientePorEmail(string email)
        {
                var cliente =  _ClienteService.ObterClientePorEmail(email);
                var ClienteModel = _JsonAutoMapper.ConvertAutoMapperJson<ClienteModel>(cliente);
                return ClienteModel;
        }


        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
