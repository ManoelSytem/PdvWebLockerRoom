using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Interface
{
    interface IProduto
    {
        Produto GetById(int codigoProduto);
    }
}
