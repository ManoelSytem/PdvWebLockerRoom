using BackOfficeFoodService.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Servico
{
    public interface ILoginAPI
    {
        [Post("/Autoriza/login")]
        Task<Token> PostCredentials(LoginModel user);
        [Post("/Autoriza/register")]
        Task<Token> RegisterUser(LoginModel user);
        [Get("/Autoriza/Authenticated")]
        Task<Usuario> Get(string login, string password);
        [Post("/Autoriza/logout")]
        Task<Task> Logout();
    }
}
