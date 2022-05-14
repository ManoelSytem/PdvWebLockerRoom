using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Aplication.Enum
{
    public enum Status
    {
        [Description("1")]
        Ativado = 1,
        [Description("0")]
        Desativado = 2
    }
}
