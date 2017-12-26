using Dominio.Enums;
using Dominio.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Partida
    {
        IDados dado = new Dado();
        IRolagens rolar = new Rolagem();
        private int qtdeRolagens;

        public Partida(int qtdeDados)
        {
            qtdeRolagens = qtdeDados;
        }

        public List<int> RolarDados()
        {
            List<int> lstValores = new List<int>();

            for (int i = 0; i < qtdeRolagens; i++)
            {
                var valor = rolar.LancarDados(dado);
                lstValores.Add(valor);
            }
            return lstValores;
        }

        public string PontuarRolagem(List<int> rolagem)
        {
            int pontuacao = 0;
            Categorias categoria = Categorias.Nenhum;

            var rolagens = rolagem
                .GroupBy(s => s)
                .Select(group => new { Word = group.Key, Count = group.Count() });


            foreach (var item in rolagens.OrderByDescending(x => x.Count).ToList())
            {
                //pontuando paridades
                if(item.Count == 5)
                {
                    categoria = Categorias.Aurora;
                    pontuacao += item.Count * item.Word;
                }
                //pontuacao quadra
                if (item.Count == 4)
                {
                    categoria = Categorias.Quadra;
                    pontuacao += item.Count * item.Word;
                }
                //pontuacao trio
                if (item.Count == 3)
                {
                    categoria = Categorias.Trio;
                    pontuacao += item.Count * item.Word;
                }
                //pontuacao pares
                if (item.Count == 2)
                {
                    if (categoria == Categorias.Trio)
                    {
                        categoria = Categorias.FullHouse;
                        pontuacao += item.Count * item.Word;
                    }
                    else if (categoria == Categorias.Par)
                    {
                        categoria = Categorias.DoisPares;
                        pontuacao += item.Count * item.Word;
                    }
                    else
                    {
                        categoria = Categorias.Par;
                        pontuacao += item.Count * item.Word;
                    }
                }
                  
            }
            //caso nenhuma paridade tenha pontuado
            if (pontuacao == 0)
            {
                rolagem.Sort();
                if (!rolagem.Select((i, j) => i - j).Distinct().Skip(1).Any())
                {
                    categoria = Categorias.SequenciaMaior;
                    pontuacao = 20;
                }
                else if (!rolagem.Select((i, j) => i - j - 1).Distinct().Skip(1).Any())
                {
                    categoria = Categorias.SequenciaMenor;
                    pontuacao = 15;
                }
                else
                {
                    pontuacao = rolagem.Max();
                    categoria = (Categorias)pontuacao;
                }
            }

            return String.Format("Sua melhor pontuação foi: {0} na categoria: {1}", pontuacao, categoria);

        }
    }
}
