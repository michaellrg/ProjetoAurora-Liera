using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Rolagem : IRolagens
    {
        public int LancarDados(IDados dados)
        {
            return dados.Rolar();
        }
    }
}
