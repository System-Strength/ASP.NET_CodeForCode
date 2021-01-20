using AppBancoDLL;
using AppBancoDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeForCode.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login_Home()
        {
            return View();
        }
        public ActionResult Cria_Conta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cria_Conta(Conta conta)
        {
            if (ModelState.IsValid)
            {
                var metodoUsuario = new CriaContaDAO();
                metodoUsuario.Insert(conta);
            }
            return View(conta);
        }
    }
}