using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeForCode.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult VerificaGer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VerificaGer()
        {
            if (ModelState.IsValid)
            {
                if(gerente.senha_ger == "GerFunc2021")
                {
                    var metodoGer = new GerenteDAO();
                    return RedirectToAction("CadastrarFunc", "Funcionario");
                }
                else
                {
                    ModelState.AddModelError("senha_ger", "Senha de Gerente Inválida!");
                }
            }
            return View();
        } 
    }
}