﻿using AppBancoDLL;
using AppBancoDominio;
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
        public ActionResult VerificaGer(Gerente gerente)
        {
            if (ModelState.IsValid)
            {
                if (gerente.senha_ger == "GerFunc2021")
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
        public ActionResult CadastrarFunc()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarFunc(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var metodoFuncionario = new FuncionarioDAO();
                metodoFuncionario.Insert(funcionario);
                return RedirectToAction("FuncCadastrados");
            }
            return View(funcionario);
        }
        public ActionResult FuncCadastrados()
        {
            var metodoFuncionario = new FuncionarioDAO();
            var todosFuncionarios = metodoFuncionario.Listar();
            return View(todosFuncionarios);
        }
    }
}