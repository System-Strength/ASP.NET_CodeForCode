using AppBancoADO;
using AppBancoDominio;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace AppBancoDLL
{
    public class CriaContaDAO
    {
        private Banco db;
        public void Insert(Conta conta)
        {
            string strQuery = string.Format("Insert into tbl_conta(user_login, rg_usu, senha_login)" +
                    "values('{0}', '{1}', '{2}');", conta.user_login, conta.rg_usu.Replace(".", string.Empty).Replace("-", string.Empty), conta.senha_login); ;
            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Atualizar(Conta conta)
        {
            var stratualiza = "";
            stratualiza += "update tbl_conta set ";
            stratualiza += string.Format(" user_login = '{0}', ", conta.user_login);
            stratualiza += string.Format(" rg_usu = '{0}', ", conta.rg_usu.ToString().Replace(".", string.Empty).Replace("-", string.Empty)););
            stratualiza += string.Format(" senha_login = '{0}', ", conta.senha_login);

            using (db = new Banco())
            {
                db.ExecutaComando(stratualiza);
            }
        }

        public void Excluir(Conta conta)
        {
            var stratualiza = "";
            stratualiza += "delete from tbl_conta";
            stratualiza += string.Format(" Where id_usu = {0};", conta.id_usu);
            using (db = new Banco())
            {
                db.ExecutaComando(stratualiza);
            }
        }
        public void Salvar(Conta conta)
        {
            if (conta.id_usu > 0)
            {
                Atualizar(conta);
            }
            else
            {
                Insert(conta);
            }
        }
        public List<Conta> Listar()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_conta";
            var retorno = db.retornaComando(strQuery);
            return listaConta(retorno);
        }
        public Conta ListarId(int id)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from tbl_conta where id_usu = {0} ", id);
                var retorno = db.retornaComando(strQuery);
                return listaConta(retorno).FirstOrDefault();
            }
        }
        private List<Conta> listaConta(MySqlDataReader retorno)
        {
            var contas = new List<Conta>();
            while (retorno.Read())
            {
                var TempConta = new Conta()
                {
                    id_usu = int.Parse(retorno["id_usu"].ToString()),
                    user_login = retorno["user_login"].ToString(),
                    rg_usu = retorno["rg_usu"].ToString().Replace(".", string.Empty).Replace("-", string.Empty),
                    senha_login = retorno["senha_login"].ToString(),
                };
                contas.Add(TempConta);
            }
            return contas;
        }
    }
}
}
