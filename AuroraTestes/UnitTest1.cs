using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Collections.Generic;

namespace AuroraTestes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestarPontuacaoPar()
        {
            Partida partida = new Partida(5);

            //var dados = partida.RolarDados();
            List<int> lst = new List<int>();
            lst.Add(2);
            lst.Add(2);
            lst.Add(4);
            lst.Add(3);
            lst.Add(5);

            var result = partida.PontuarRolagem(lst);

            Assert.AreEqual(result, "Sua melhor pontuação foi: 4 na categoria: Par");
        }

        [TestMethod]
        public void TestarPontuacaoDoisPar()
        {
            Partida partida = new Partida(5);

            //var dados = partida.RolarDados();
            List<int> lst = new List<int>();
            lst.Add(2);
            lst.Add(2);
            lst.Add(4);
            lst.Add(3);
            lst.Add(3);

            var result = partida.PontuarRolagem(lst);

            Assert.AreEqual(result, "Sua melhor pontuação foi: 10 na categoria: DoisPares");
        }

        [TestMethod]
        public void TestarPontuacaoFullHouse()
        {
            Partida partida = new Partida(5);

            //var dados = partida.RolarDados();
            List<int> lst = new List<int>();
            lst.Add(2);
            lst.Add(2);
            lst.Add(3);
            lst.Add(3);
            lst.Add(3);

            var result = partida.PontuarRolagem(lst);

            Assert.AreEqual(result, "Sua melhor pontuação foi: 13 na categoria: FullHouse");
        }
    }
}
