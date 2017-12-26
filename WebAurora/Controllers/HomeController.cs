using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAurora.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Partida partida = new Partida(5);

            List<int> lstRolagens = partida.RolarDados();

            string melhorPontuacao = partida.PontuarRolagem(lstRolagens);

            ViewBag.Rolagens = lstRolagens;
            ViewBag.Pontuacao = melhorPontuacao;

            return View();
        }

    }
}