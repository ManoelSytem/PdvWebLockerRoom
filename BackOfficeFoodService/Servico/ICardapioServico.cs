using BackOfficeFoodService.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Servico
{
    public interface ICardapioServico
    {
        [Post("/Cardapio/Create")]
        Task<ActionResultado> Post(CardapioModel cardapioModel);
        [Get("/Cardapio/GetListCardapio")]
        Task<List<CardapioModel>> GetListCardapioPorCliente(string cliente);
        [Get("/Cardapio/ObterCardapioPorId")]
        Task<CardapioModel> ObterCardapioPorId(int id);
        [Post("/Cardapio/CreateListaCardapio")]
        Task<ActionResultado> PostListCardapio(MenuModel listModel);
        [Get("/Cardapio/GetListMenuCardapioPorId")]
        Task<List<MenuModel>> GetListMenuCardapioPorId(int IdCardapio);
        [Get("/Cardapio/ObterCardapioPrincipal")]
        Task<CardapioModel> ObterCardapioPrincipal();
        [Delete("/Cardapio/DeleteListMenu")]
        Task<ActionResultado> DeleleteListaMenu(string codMenuSeq);
        [Post("/Cardapio/UpdateListMenu")]
        Task<ActionResultado> UpdateListaMenu(MenuModel listModel);
        [Delete("/Cardapio/DeleteCardapio")]
        Task<ActionResultado> DeleteCardapio(int id, string cliente);
        [Put("/Cardapio/AtualizaCardapio")]
        Task<ActionResultado> AtualizaCardapio(int id, string titulo);
        [Post("/Cardapio/DefinirCardapioPrincipal")]
        Task<ActionResultado> DefinirCardapioPrincipal(int codCardapio);
    }
}
