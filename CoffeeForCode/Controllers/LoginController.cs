using AppBancoDLL;
using AppBancoDominio;
using MySql.Data.MySqlClient;
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
        [HttpPost]
        public ActionResult Login_Home(Conta conta)
        {
            if (conta.user_login == "FuncCFC2021" && conta.senha_login == "FuncDS2021")
            {
                var metodoLogin = new LoginDAO();
                return RedirectToAction("Home", "Funcionario");
            }
            else
            {
                ModelState.AddModelError("senha_login", "Usuário ou Senha inválidos!");
            }               

            return View(conta);
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
        public ActionResult Esqueceu_Senha()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Esqueceu_Senha(Conta conta)
        {
            var metodoUsuario = new CriaContaDAO();
            if (ModelState.IsValid && conta.rg_usu == "59.437.356-6")
            {
                metodoUsuario.Atualizar(conta);
                return RedirectToAction("Login_Home");
            }
            return View(conta);
        }
    }
}