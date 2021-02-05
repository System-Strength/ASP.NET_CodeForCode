using AppBancoADO;
using AppBancoDLL;
using AppBancoDominio;
using System.Web.Mvc;

namespace CoffeeForCode.Controllers
{
    public class LoginController : Controller
    {
        //    // GET: Login
        public ActionResult Login_Home()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login_Home(Conta conta)
        {           
            var db = new Banco();
            var strQuery = "select * from tbl_conta";
            var retorno = db.retornaComando(strQuery);
            while (retorno.Read())
            {
                var user_login = retorno["user_login"].ToString();
                var senha_login = retorno["senha_login"].ToString();
            
                if (conta.user_login == "FuncCFC2021" && conta.senha_login == "FuncDS2021")
                {
                    var metodoLogin = new LoginDAO();
                    return RedirectToAction("Home", "Funcionario");
                }
                else if (user_login == conta.user_login && senha_login == conta.senha_login)
                {
                    return RedirectToAction("Home", "Cliente");
                }
                else
                {
                    ModelState.AddModelError("senha_login", "Usuário ou Senha inválidos!");
                }
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
                return RedirectToAction("Home", "Cliente");
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
            var db = new Banco();
            var strQuery = "select * from tbl_conta";
            var retorno = db.retornaComando(strQuery);
            while (retorno.Read())
            {
                var rg_usu = retorno["rg_usu"].ToString().Replace(".", string.Empty).Replace("-", string.Empty);
                if (rg_usu == conta.rg_usu)
                {
                    metodoUsuario.Atualizar(conta);
                    return RedirectToAction("Login_Home", "Login");
                }
            }                                    
            return View(conta);
        }
    }
}