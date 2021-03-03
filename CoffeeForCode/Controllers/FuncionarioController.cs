using AppBancoDLL;
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
        public ActionResult EditarFunc(int id)
        {
            var metodoFuncionario = new FuncionarioDAO();
            var funcionarios = metodoFuncionario.ListarId(id);
            if (funcionarios == null)
            {
                return HttpNotFound();
            }
            return View(funcionarios);
        }
        [HttpPost]
        public ActionResult EditarFunc(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var metodoFuncionario = new FuncionarioDAO();
                metodoFuncionario.Atualizar(funcionario);
                return RedirectToAction("FuncCadastrados");
            }
            return View(funcionario);
        }
        public ActionResult DetalhesFunc(int id)
        {
            var metodoFuncionario = new FuncionarioDAO();
            var funcionario = metodoFuncionario.ListarId(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }
        public ActionResult ExcluirFunc(int id)
        {
            var metodoFuncionario = new FuncionarioDAO();
            var funcionario = metodoFuncionario.ListarId(id);

            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }
        [HttpPost, ActionName("ExcluirFunc")]
        public ActionResult ExcluirFuncConf(int id)
        {
            var metodoFuncionario = new FuncionarioDAO();
            Funcionario funcionario = new Funcionario();
            funcionario.id_func = id;
            metodoFuncionario.Excluir(funcionario);
            return RedirectToAction("FuncCadastrados");
        }
        public ActionResult ClientesCadastrados(string btn, FormCollection frm)
        {
            var metodoCliente = new CriaContaDAO();
            var todosClientes = metodoCliente.Listar();
            return View(todosClientes);
        }
        public ActionResult Categoria()
        {
            return View();
        }



        public ActionResult Info()
        {
            return View();
        }
    }
}