using AppBancoADO;
using AppBancoDominio;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace AppBancoDLL.FuncionarioDAO
{
    public class FuncionarioDAO
    {
        private Banco db;
        public void Insert(Funcionario funcionario)
        {
            string strQuery = string.Format("Insert into tbl_funcionario(nm_func, cg_func, email_func, cpf_func, end_func, tel_func)" +
                    "values('{0}', '{1}','{2}', '{3}', '{4}', '{5}');", funcionario.nm_func, funcionario.cg_func, funcionario.email_func, funcionario.cpf_func.Replace(".", string.Empty).Replace("-", string.Empty), funcionario.tel_func); ;
            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Atualizar(Funcionario funcionario)
        {
            var stratualiza = "";
            stratualiza += "update tbl_funcionario set ";
            stratualiza += string.Format(" nm_func = '{0}', ", funcionario.nm_func);
            stratualiza += string.Format(" cg_func = '{0}', ", funcionario.cg_func);
            stratualiza += string.Format(" email_func = '{0}', ", funcionario.cg_func);
            stratualiza += string.Format(" cpf_func = '{0}' ", funcionario.cpf_func.ToString().Replace(".", string.Empty).Replace("-", string.Empty));
            stratualiza += string.Format(" end_func = '{0}', ", funcionario.end_func);
            stratualiza += string.Format(" tel_func = '{0}', ", funcionario.tel_func);

            using (db = new Banco())
            {
                db.ExecutaComando(stratualiza);
            }
        }

        public void Excluir(Funcionario funcionario)
        {
            var stratualiza = "";
            stratualiza += "delete from tbl_funcionario";
            stratualiza += string.Format(" Where id_func = {0};", funcionario.id_func);
            using (db = new Banco())
            {
                db.ExecutaComando(stratualiza);
            }
        }
        public void Salvar(Funcionario funcionario)
        {
            if (funcionario.id_func > 0)
            {
                Atualizar(funcionario);
            }
            else
            {
                Insert(funcionario);
            }
        }
        public List<Funcionario> Listar()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_funcionario";
            var retorno = db.retornaComando(strQuery);
            return listaFuncionario(retorno);
        }
        public Funcionario ListarId(int id)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from tbl_funcionario where id_func = {0} ", id);
                var retorno = db.retornaComando(strQuery);
                return listaFuncionario(retorno).FirstOrDefault();
            }
        }
        private List<Funcionario> listaFuncionario(MySqlDataReader retorno)
        {
            var funcionarios = new List<Funcionario>();
            while (retorno.Read())
            {
                var TempFuncionario = new Funcionario()
                {
                    nm_func = retorno["nm_func"].ToString(),
                    cg_func = retorno["cg_func"].ToString(),
                    email_func = retorno["email_func"].ToString(),
                    cpf_func = retorno["cpf_func"].ToString().Replace(".", string.Empty).Replace("-", string.Empty),
                    end_func = retorno["end_func"].ToString(),
                    tel_func = retorno["tel_func"].ToString(),
                };
                funcionarios.Add(TempFuncionario);
            }
            return funcionarios;
        }
    }
}