using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Dado : IDados
    {
        public int lados { get; private set; }
        public int valorRolagem { get; set; }

        protected Random numAleatorio = new Random();

        public Dado()
        {
            this.lados = 6;
        }

        public int Rolar()
        {
            return this.valorRolagem = numAleatorio.Next(1, lados);
        }

    }
}
