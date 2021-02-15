using AppBancoDLL;
using AppBancoDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeForCode.Controllers
{
    public class ClienteController : Controller    
    { 
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Sobre()
        {
            return View();
        }
        public ActionResult Cardapio()
        {
            return View();
        }
        public ActionResult Cardapio_Cafe()
        {
            return View();
        }
        public ActionResult Cardapio_Choco()
        {
            return View();
        }
        public ActionResult Cardapio_MilkShake()
        {
            return View();
        }
        public ActionResult Cardapio_Sanduiche()
        {
            return View();
        }
        public ActionResult Cardapio_Doces()
        {
            return View();
        }
        public ActionResult Cardapio_Burguer()
        {
            return View();
        }
        public ActionResult Compra()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Compra(Compras compra)
        {
            if (ModelState.IsValid)
            {
                var metodoUsuario = new ComprasDAO();
                metodoUsuario.Insert(compra);
                return RedirectToAction("Home", "Cliente");
            }
            return View(compra);
        }
        public ActionResult Parceiro()
        {
            return View();
        }
        public ActionResult ParceiroForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ParceiroForm(Parceiro parceiro)
        {
            if (ModelState.IsValid)
            {
                var metodoParceiro = new ParceiroDAO();
                metodoParceiro.Insert(parceiro);
                return RedirectToAction("Home", "Cliente");
            }
            return View(parceiro);
        }
        public ActionResult TrabalheConosco()
        {
            return View();
        }
    }
}