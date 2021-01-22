using AppBancoDLL;
using AppBancoDominio;
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
        public ActionResult Esqueceu_Senha(int id)
        {
            var metodoUsuario = new CriaContaDAO();
            var usuarios = metodoUsuario.ListarId(id);
            if(usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }
        [HttpPost]
        public ActionResult Esqueceu_Senha(Conta conta)
        {
            if (ModelState.IsValid)
            {
                var metodoUsuario = new CriaContaDAO();
                metodoUsuario.Atualizar(conta);
                return RedirectToAction("Login_Home");
            }
            return View(conta);
        }

    }
}