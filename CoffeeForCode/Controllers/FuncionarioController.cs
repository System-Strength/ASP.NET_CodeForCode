using AppBancoADO;
using AppBancoDLL;
using AppBancoDominio;
using MySql.Data.MySqlClient;
using System.Web.Mvc;

namespace CoffeeForCode.Controllers
{
    public class FuncionarioController : Controller
    {
        Banco con = new Banco();
        Conta conta = new Conta();
        CriaContaDAO criaConta = new CriaContaDAO();

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
        MySqlDataReader dataReaderRG;
        public void buscarCliente(Conta conta)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbl_conta where rg_usu = @rg_usu", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@rg_usu", conta.rg_usu);
            dataReaderRG = cmd.ExecuteReader();

            while (dataReaderRG.Read())
            {
                conta.id_usu = int.Parse(dataReaderRG[1].ToString());
                conta.user_login = dataReaderRG[2].ToString();
                conta.rg_usu = dataReaderRG[3].ToString();
                conta.senha_login = dataReaderRG[4].ToString();
            }

            con.MyDesConectarBD();

        }
        public ActionResult ClientesCadastrados()
        {
            
            var metodoCliente = new CriaContaDAO();
            var todosClientes = metodoCliente.Listar();
            return View(todosClientes);
            
        }

        public ActionResult BuscaCliente(string btn, FormCollection frm)
        {
            if (btn == "Buscar")
            {
                conta.rg_usu = frm["txtRg"];
                buscarCliente(conta);
                ViewBag.id_usu = conta.id_usu;
                ViewBag.user_login = conta.user_login;
                ViewBag.senha_login = conta.senha_login;
                ViewBag.rg_usu = conta.rg_usu;
                return View();
            }

            return View();
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